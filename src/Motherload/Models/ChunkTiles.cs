using Motherload.Enums;

namespace Motherload.Models
{
    /// <summary>
    /// Model usada para salvar informações sobre os tiles.
    /// </summary>
    public class ChunkTiles
    {
        /// <summary>
        /// Posição em X do tile.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Posição em Y do tile.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Tipo do tile.
        /// </summary>
        public OresTypes T { get; set; }
    }
}
