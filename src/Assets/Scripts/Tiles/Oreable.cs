using Motherload.Core.Enums;
using Motherload.Core.Helpers;
using Motherload.Core.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Motherload.Core.Tiles
{
    /// <summary>
    /// Permite um piso possuir minérios.
    /// </summary>
    public class Oreable : MonoBehaviour
    {
        private static readonly string TILES_DATA_PATH = "tiles.json";

        /// <summary>
        /// Asset base para adicionar minérios.
        /// </summary>
        [SerializeField]
        private RuleTile OreBlock;

        /// <summary>
        /// Tilemap para adicionar os minérios.
        /// </summary>
        [SerializeField]
        private Tilemap Tilemap;

        /// <summary>
        /// Lista com os minérios
        /// </summary>
        private List<LayerTiles> ListTiles;

        /// <summary>
        /// Método executado quando a cena inicia.
        /// </summary>
        public void Start()
        {
            var random = new System.Random();

            var watch = new Stopwatch();
            watch.Start();
            ListTiles = GameJson.Deserialize<List<LayerTiles>>(TILES_DATA_PATH);
            watch.Stop();

            UnityEngine.Debug.Log($"Levou {watch.ElapsedMilliseconds} milisegundos para carregar o mapa.");

            watch.Start();
            var positions = new List<Vector3Int>();
            var blocks = new List<Tile>();
            
            foreach (var tile in ListTiles)
            {
                positions.Add(new Vector3Int(tile.X, tile.Y, 0));
                

                if (tile.Y < -100)
                    break;
            }

            Tilemap.SetTiles(positions.ToArray(), blocks.ToArray());
            
            watch.Stop();
            UnityEngine.Debug.Log($"Levou {watch.ElapsedMilliseconds} milisegundos para carregar renderizar o mapa.");
        }
    }
}
