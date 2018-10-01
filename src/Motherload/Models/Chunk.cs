namespace Motherload.Models
{
    /// <summary>
    /// Guarda as informações de uma àrea do mapa do jogo
    /// </summary>
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
    }
}
