using Motherload.Factories;
using Motherload.Interfaces;
using Motherload.Models;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;
using Motherload.Enums;
using Assets.Scripts.Player;

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
    /// Verifica se precisa carregar, remover ou criar um chunk.
    /// </summary>
    public void CheckChunk()
    {
        var worldPlayerX = (int)Math.Ceiling(transform.position.x / 4);
        var worldPlayerY = (int)Math.Ceiling(transform.position.y / 4);

        if (worldPlayerX == LastUpdate[0] && worldPlayerY == LastUpdate[1])
            return;

        LastUpdate[0] = worldPlayerX;
        LastUpdate[1] = worldPlayerY;

        m_GM.ChunksLoaded.ForEach(o => o[0] = (int)ChunkAction.DESTROY);

        for (var x = -3; x <= 2; x++)
        {
            for (var y = -1; y <= 1; y++)
            {
                var worldRenderX = worldPlayerX + x;
                var worldRenderY = worldPlayerY + y;

                var chunkLoaded = m_GM.ChunksLoaded.SingleOrDefault(o => (o[0] == (int)ChunkAction.UNLOADED || o[0] == (int)ChunkAction.LOADED) && o[1] == worldRenderX && o[2] == worldRenderY);
                
                // Caso não haja um chunk carregado para esse valor, ele vai e carrega.
                if (chunkLoaded == null) {
                    m_GM.ChunksLoaded.Add(new int[] { (int)ChunkAction.TO_LOAD, worldRenderX, worldRenderY });
                    continue;
                }
                
                // Se houver um chunk só que ele não esteja carregado, ele vai e 
                var chunkIndex = m_GM.ChunksLoaded.IndexOf(chunkLoaded);

                if (chunkLoaded[0] == (int)ChunkAction.UNLOADED)
                    chunkLoaded[0] = (int)ChunkAction.TO_LOAD;
                else
                    chunkLoaded[0] = (int)ChunkAction.DO_NOTHING;
                
                m_GM.ChunksLoaded[chunkIndex] = chunkLoaded;

            }
        }

        RemoveChunk();
        LoadChunk();

        RenderTilemap.gameObject.GetComponent<TilemapCollider2D>().enabled = false;
        RenderTilemap.gameObject.GetComponent<TilemapCollider2D>().enabled = true;
    }

    /// <summary>
    /// Carrega os chunks no mapa
    /// </summary>
    /// <param name="worldRenderX">Posição absoluta do mundo em X</param>
    /// <param name="worldRenderY">Posição absoluta do mundo em Y</param>
    public void LoadChunk()
    {
        var listTiles = new List<ChunkTiles>();

        m_GM.ChunksLoaded.Where(o => o[0] == (int)ChunkAction.TO_LOAD).ToList().ForEach(chunkLoaded =>
        {
            var chunk = m_GM.Chunks.SingleOrDefault(o => o.WX == chunkLoaded[1] && o.WY == chunkLoaded[2]);

            if (chunk == null)
                chunk = GenerateChunk(chunkLoaded[1], chunkLoaded[2]);

            listTiles.AddRange(chunk.WT);
            chunkLoaded[0] = (int)ChunkAction.LOADED;
        });

        m_GM.ChunksLoaded.Where(o => o[0] == (int)ChunkAction.DO_NOTHING).ToList().ForEach(chunkLoaded =>
        {
            chunkLoaded[0] = (int)ChunkAction.LOADED;
        });

        var listOre = new Oretile[listTiles.Count];
        var listPos = new Vector3Int[listTiles.Count];

        for (int i = 0; i < listTiles.Count; i++)
        {
            var oreClone = OreTile;
            oreClone.TileType = listTiles[i].T;

            listPos[i] = new Vector3Int(listTiles[i].X, listTiles[i].Y, 0);
            listOre[i] = oreClone;
        }
        RenderTilemap.SetTiles(listPos, listOre);
    }

    /// <summary>
    /// Remove um chunk do mapa
    /// </summary>
    /// <param name="worldRenderX">Posição absoluta do mundo em X</param>
    /// <param name="worldRenderY">Posição absoluta do mundo em Y</param>
    public void RemoveChunk()
    {
        var listTiles = new List<ChunkTiles>();

        m_GM.ChunksLoaded.Where(o => o[0] == (int)ChunkAction.DESTROY).ToList().ForEach(chunkLoaded =>
        {
            var chunk = m_GM.Chunks.SingleOrDefault(o => o.WX == chunkLoaded[1] && o.WY == chunkLoaded[2]);

            if (chunk != null)
            {
                listTiles.AddRange(chunk.WT);
                chunkLoaded[0] = (int)ChunkAction.UNLOADED;
            }
        });
        
        var listPos = new Vector3Int[listTiles.Count];
        var listOre = new TileBase[listTiles.Count];
        
        for (int i = 0; i < listTiles.Count; i++)
        {
            listOre[i] = null;
            listPos[i] = new Vector3Int(listTiles[i].X, listTiles[i].Y, 0);
        }

        RenderTilemap.SetTiles(listPos.ToArray(), listOre.ToArray());
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
        
        for(var y = -8; y <= 8; y++)
        {
            for (var x = -8; x <= 8; x++)
            {
                if (((worldRenderY * 4) + y) >= -7)
                    continue;


                list.Add(new ChunkTiles()
                {
                    X = (worldRenderX * 4) + x,
                    Y = (worldRenderY * 4) + y,
                    T = UnityEngine.Random.Range(0, 100) <= 6 ? OresTypes.COAL : OresTypes.NORMAL
                });
            }
        }

        chunk.WT = list.ToArray();
        m_GM.Chunks.Add(chunk);

        return chunk;
    }
}

