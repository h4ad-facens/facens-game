using Motherload.Enums;

namespace Motherload.Models
{
    /// <summary>
    /// Minério
    /// </summary>
    public class Ore
    {
        /// <summary>
        /// Nome do minério
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Raridade do minério
        /// </summary>
        public Raritys Rarity { get; set; }

        /// <summary>
        /// Preço do minério
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Peso do minério
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Pontos que o minério dá ao ser minerado
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Tipo do minério
        /// </summary>
        public OresTypes OreType { get; set; }
    }
}
