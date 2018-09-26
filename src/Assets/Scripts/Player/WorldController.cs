using Assets.Scripts.Models;
using Motherload.Core.Enums;
using Motherload.Core.Helpers;
using Motherload.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using Assets.Scripts.Helpers;

/// <summary>
/// Classe que será responsável por lidar com o mundo, desde carregar, salvar e renderizar
/// </summary>
public class WorldController : MonoBehaviour
{
    /// <summary>
    /// o mundo que será salvo
    /// </summary>
    public Tilemap WorldMinerable;

    /// <summary>
    /// O jogador
    /// </summary>
    public GameObject Player;

    /// <summary>
    /// Configurações do jogo
    /// </summary>
    private Config Configs;

    public RuleTile OreTile;

    /// <summary>
    /// Altura máxima que ele começará a carregar e salvar o mundo.
    /// Tudo acima dessa altura será ignorado.
    /// </summary>
    public int MaxHeight = -7;

    /// <summary>
    /// Posição mínima em X que será gerado o mundo.
    /// </summary>
    public int MinX = -14;

    /// <summary>
    /// Posição máxima em X que será gerado o mundo.
    /// </summary>
    public int MaxX = 19;

    /// <summary>
    /// Layers deste mundo
    /// </summary>
    private List<Layer> Layers;

    /// <summary>
    /// Executado quando o script é carregado pela primeira vez.
    /// </summary>
    public void Start()
    {
        PlayerPrefs.DeleteAll();
        Player = GameObject.FindGameObjectWithTag("Player");
        Configs = Config.GetConfig();
        Layers = JsonConvert.DeserializeObject<List<Layer>>(File.ReadAllText(Configs.LayersFilePath));
    }

    /// <summary>
    /// Chamado a cada atualização de frame.
    /// </summary>
    public async void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            await new BaseTaskManager().Run(() => AsyncAwaiter.AwaitAsync(nameof(WorldController) + nameof(GenerateLayers), GenerateLayers));
        
        if (Input.GetKeyDown(KeyCode.O))
            await Task.Run(LoadLayers);
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
            await RenderLayer(Layers.Find(o => o.MinHeight == -7).Filename);
    }

    /// <summary>
    /// Gera as layers
    /// </summary>
    public async Task GenerateLayers()
    {
        foreach (FileInfo file in new DirectoryInfo(Path.GetFullPath(Configs.LayerTilesFolderPath)).GetFiles())
        {
            file.Delete();
        }

        UnityEngine.Debug.Log(Layers.Count);

        var writer = new BaseFileManager();

        foreach (var layer in Layers)
        {
            UnityEngine.Debug.Log($"Iniciando a geração da Layer: Min: {layer.MinHeight} - Max: {layer.MaxHeight}");
            var watch = new Stopwatch();
            watch.Start();

            if (layer.MinHeight > MaxHeight)
                continue;

            var random = new System.Random();
            var listTiles = new List<LayerTiles>();

            for (var y = layer.MinHeight; y >= layer.MaxHeight; y--)
            {
                for (var x = MinX; x <= MaxX; x++)
                {
                    listTiles.Add(new LayerTiles()
                    {
                        X = x,
                        Y = y,
                        Type = layer.LayerOres[random.Next(0, layer.LayerOres.Count - 1)]
                    });
                }
            }

            var filename = Path.GetFullPath($"{Configs.LayerTilesFolderPath}\\Layer_{DateTime.Now.Ticks}.json");

            Layers.Find((o) => o.MinHeight == layer.MinHeight).Filename = filename;
            await writer.WriteTextToFileAsync(JsonConvert.SerializeObject(listTiles, Formatting.None), filename);

            watch.Stop();
            UnityEngine.Debug.Log($"Layer gerada! Tempo levado: {watch.ElapsedMilliseconds} ms.");
        }
    }

    /// <summary>
    /// Carrega todas as layers
    /// </summary>
    public async Task LoadLayers()
    {
        foreach (FileInfo file in new DirectoryInfo(Path.GetFullPath(Configs.LayerTilesFolderPath)).EnumerateFiles())
        {
            using (var stream = file.OpenText())
            {
                var watch = new Stopwatch();
                watch.Start();

                Layers.Find(o => o.Filename == file.FullName).LayerTiles = JsonConvert.DeserializeObject<List<LayerTiles>>(await stream.ReadToEndAsync());

                watch.Stop();
                UnityEngine.Debug.Log($"Levou {watch.ElapsedMilliseconds} milisegundos para carregar o mapa.");
            }
        }
    }

    public async Task RenderLayer(string filename)
    {
        var watch = new Stopwatch();
        watch.Start();

        var positions = new List<Vector3Int>();
        var blocks = new List<RuleTile>();

        await Task.Factory.StartNew(() =>
        {
            foreach (var tile in Layers.Find(o => o.Filename == filename).LayerTiles)
            {
                if (tile.Y < -50)
                    break;

                positions.Add(new Vector3Int(tile.X, tile.Y, 0));

                blocks.Add(OreTile);
            }
        });

        // Consertar isso
        WorldMinerable.SetTiles(positions.ToArray(), blocks.ToArray());
        
        watch.Stop();
        UnityEngine.Debug.Log($"Levou {watch.ElapsedMilliseconds} milisegundos para renderizar o mapa.");
    }
}

