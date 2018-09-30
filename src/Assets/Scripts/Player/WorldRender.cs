using Motherload.Factories;
using Motherload.Interfaces;
using Motherload.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;
using Motherload.Enums;
using System.Threading;
using Assets.Scripts.Player;
using Motherload.Helpers;

/// <summary>
/// Classe que será responsável por lidar com o renderizar do mundo
/// </summary>
public class WorldRender : MonoBehaviour
{
    /// <summary>
    /// O Tilemap em que será renderizado o mundo
    /// </summary>
    public Tilemap RenderTilemap;
    
    /// <summary>
    /// Tile do minério
    /// </summary>
    [SerializeField]
    private Oretile OreTile;

    /// <summary>
    /// Serviço principal do jogo
    /// </summary>
    private IGameService m_GM;

    /// <summary>
    /// Indica qual foi a ultima posição do jogador em que foi renderizado o mundos
    /// </summary>
    private int[] LastUpdate { get; set; } = new int[] { 0, 0 };

    /// <summary>
    /// Executado quando o script é carregado pela primeira vez.
    /// </summary>
    public void Start()
    {
        PlayerPrefs.DeleteAll();
        m_GM = DependencyInjector.Retrieve<IGameService>();
    }

    /// <summary>
    /// Chamado a cada atualização de frame.
    /// </summary>
    public async void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
            UnityEngine.Debug.Log(m_GM.Configurations.BasePath);
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
            await RenderLayer(m_GM.Layers.Find(o => o.MinHeight == -7).Filename);

        await CheckChunk();
    }

    /// <summary>
    /// Verifica se precisa carregar, remover ou criar um chunk.
    /// </summary>
    public async Task CheckChunk()
    {
        var worldPlayerX = (int)Math.Ceiling(transform.position.x / 4);
        var worldPlayerY = (int)Math.Ceiling(transform.position.y / 4);

        if (worldPlayerX == LastUpdate[0] && worldPlayerY == LastUpdate[1])
            return;

        LastUpdate[0] = worldPlayerX;
        LastUpdate[1] = worldPlayerY;

        await Task.Factory.StartNew(() =>
        {
            var index = 0;
            var actions = new List<int[]>();

            for (var x = -2; x <= 2; x++)
            {
                for (var y = -2; y <= 2; y++)
                {
                    var worldRenderX = worldPlayerX + x;
                    var worldRenderY = worldPlayerY + y;

                    var chunkLoaded = m_GM.ChunksLoaded.Length >= (index + 1) ? m_GM.ChunksLoaded[index] : null;
                    UnityEngine.Debug.Log($"x: {x}, y: {y}");

                    index++;
                    if (chunkLoaded != null)
                    {
                        // Verifica se o chunk não foi carregado, se foi, ele continua a execução
                        if (chunkLoaded[0] == worldRenderX && chunkLoaded[1] == worldRenderY)
                            continue;
                        else
                        {
                            m_GM.Chunks.Single(o => o.WX == chunkLoaded[0] && o.WY == chunkLoaded[1]).IsLoaded = false;
                            m_GM.ChunksLoaded[index - 1] = null;
                        }
                    }

                    m_GM.ChunksLoaded[index - 1] = new int[] { worldRenderX, worldRenderY };
                    actions.Add(new int[] { worldRenderX, worldRenderY });
                }
            }

            return actions.ToArray();

        }).ContinueWith(async (actions) =>
        {
            var things = await actions;

            for (var i = 0; i < things.Length; i++)
            {
                await LoadChunk(things[i][0], things[i][1]);
            }

            await RemoveChunk();

            RenderTilemap.gameObject.GetComponent<TilemapCollider2D>().enabled = false;
            RenderTilemap.gameObject.GetComponent<TilemapCollider2D>().enabled = true;
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    /// <summary>
    /// Carrega os chunks no mapa
    /// </summary>
    /// <param name="worldRenderX">Posição absoluta do mundo em X</param>
    /// <param name="worldRenderY">Posição absoluta do mundo em Y</param>
    public async Task LoadChunk(int worldRenderX, int worldRenderY)
    {
        await Task.Factory.StartNew(() =>
        {
            var chunk = m_GM.Chunks.FirstOrDefault(o => o.WX == worldRenderX && o.WY == worldRenderY);

            if (chunk == null)
                chunk = GenerateChunk(worldRenderX, worldRenderY);

            var listOre = new Oretile[chunk.WT.Length];
            var listPos = new Vector3Int[chunk.WT.Length];

            for (int i = 0; i < chunk.WT.Length; i++)
            {
                var oreClone = OreTile;
                oreClone.TileType = chunk.WT[i].T;

                listPos[i] = new Vector3Int(chunk.WT[i].X, chunk.WT[i].Y, 0);
                listOre[i] = oreClone;
            }

            return new object[] { listPos, listOre };

        }).ContinueWith(async (lists) =>
        {
            var result = await lists;
            RenderTilemap.SetTiles(result[0] as Vector3Int[], result[1] as TileBase[]);
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    /// <summary>
    /// Remove um chunk do mapa
    /// </summary>
    /// <param name="worldRenderX">Posição absoluta do mundo em X</param>
    /// <param name="worldRenderY">Posição absoluta do mundo em Y</param>
    public async Task RemoveChunk()
    {
        await Task.Factory.StartNew(() =>
        {
            var listPos = new List<Vector3Int>();
            var listOre = new List<TileBase>();

            var chunk = m_GM.Chunks.Where(o => o.IsLoaded == false).SelectMany(o => o.WT).ToArray();

            for (int i = 0; i < chunk.Length; i++)
            {
                listOre.Add(null);
                listPos.Add(new Vector3Int(chunk[i].X, chunk[i].Y, 0));
            }

            return new object[] { listPos, listOre };

        }).ContinueWith(async (lists) =>
        {
            var result = await lists;

            if (result.Length == 0)
                return;

            RenderTilemap.SetTiles(result[0] as Vector3Int[], result[1] as TileBase[]);
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    /// <summary>
    /// Gera um chunk.
    /// </summary>
    /// <param name="worldRenderX">Posição absoluta do mundo em X</param>
    /// <param name="worldRenderY">Posição absoluta do mundo em Y</param>
    /// <returns></returns>
    public Chunk GenerateChunk(int worldRenderX, int worldRenderY)
    {
        var chunk = new Chunk() { WX = worldRenderX, WY = worldRenderY };
        var list = new List<ChunkTiles>();

        var index = 0;
        for(var y = -8; y <= 7; y++)
        {
            for (var x = -8; x <= 7; x++)
            {
                if (((worldRenderY * 4) + y) >= -7)
                    continue;


                list.Add(new ChunkTiles()
                {
                    X = (worldRenderX * 4) + x,
                    Y = (worldRenderY * 4) + y,
                    T = OresTypes.COAL
                });

                index++;
            }
        }

        chunk.WT = list.ToArray();

        UnityEngine.Debug.Log($"Tiles gerados: {chunk.WT.Length}");

        chunk.IsLoaded = true;
        m_GM.Chunks.Add(chunk);
        return chunk;
    }


    /// <summary>
    /// Renderiza o mundo
    /// </summary>
    /// <param name="filename">Arquivo com os pisos a serem renderizados</param>
    /// <returns></returns>
    public async Task RenderLayer(string filename)
    {
        var watch = new Stopwatch();
        watch.Start();

        var positions = new List<Vector3Int>();
        var blocks = new List<RuleTile>();

        await Task.Factory.StartNew(() =>
        {
            foreach (var tile in m_GM.Layers.Find(o => o.Filename == filename).LayerTiles)
            {
                if (tile.Y < -50)
                    break;

                positions.Add(new Vector3Int(tile.X, tile.Y, 0));

                blocks.Add(OreTile);
            }
        });

        // Consertar isso
        RenderTilemap.SetTiles(positions.ToArray(), blocks.ToArray());
        
        watch.Stop();
        UnityEngine.Debug.Log($"Levou {watch.ElapsedMilliseconds} milisegundos para renderizar o mapa.");
    }
}

