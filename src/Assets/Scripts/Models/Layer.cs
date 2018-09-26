using Motherload.Core.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Motherload.Core.Models
{
    /// <summary>
    /// Representa uma camada
    /// </summary>
    public class Layer
    {
        /// <summary>
        /// Nome da camada
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Altura minima
        /// </summary>
        public int MinHeight { get; set; }

        /// <summary>
        /// Altura máxima
        /// </summary>
        public int MaxHeight { get; set; }

        /// <summary>
        /// Broca mínima para se minerar na camada
        /// </summary>
        public Drills MinimiumDrill { get; set; }

        /// <summary>
        /// Minérios spawnados nesta camada
        /// </summary>
        public List<OresTypes> LayerOres { get; set; }

        /// <summary>
        /// Caminho para o arquivo de tiles desta camada
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Pisos que está camada possui
        /// </summary>
        [JsonIgnore]
        public List<LayerTiles> LayerTiles { get; set; }

    }
}
