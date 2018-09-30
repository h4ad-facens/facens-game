using Newtonsoft.Json;

namespace Motherload.Models
{
    public class Chunk
    {
        /// <summary>
        /// Posição em X relativa ao mundo
        /// </summary>
        public int WX;

        /// <summary>
        /// Posicação em Y relativa ao mundo
        /// </summary>
        public int WY;

        /// <summary>
        /// Pisos do chunk
        /// </summary>
        public ChunkTiles[] WT;

        [JsonIgnore]
        public bool IsLoaded { get; set; }
    }
}
