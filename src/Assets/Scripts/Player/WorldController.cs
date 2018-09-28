using Motherload.Factories;
using Motherload.Interfaces;
using Motherload.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

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
    /// Tile do minério
    /// </summary>
    public RuleTile OreTile;

    /// <summary>
    /// Serviço principal do jogo
    /// </summary>
    public IGameService GameService;

    /// <summary>
    /// Executado quando o script é carregado pela primeira vez.
    /// </summary>
    public void Start()
    {
        PlayerPrefs.DeleteAll();
        Player = GameObject.FindGameObjectWithTag("Player");
        GameService = DependencyInjector.Retrieve<IGameService>();
    }

    /// <summary>
    /// Chamado a cada atualização de frame.
    /// </summary>
    public async void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
            UnityEngine.Debug.Log(GameService.Configurations.BasePath);
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
            await RenderLayer(GameService.Layers.Find(o => o.MinHeight == -7).Filename);
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
            foreach (var tile in GameService.Layers.Find(o => o.Filename == filename).LayerTiles)
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

