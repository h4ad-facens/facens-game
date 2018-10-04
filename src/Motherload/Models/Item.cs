using Motherload.Enums;
using Newtonsoft.Json;

namespace Motherload.Models
{
    /// <summary>
    /// Classe base para todo item
    /// </summary>
    public class Item
    {
        /// <summary>
        /// ID único do item usado para identifica-lo
        /// </summary>
        public int UniqueID { get; set; }

        /// <summary>
        /// Nome do item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Preço do item no mercado
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Peso do item no inventário
        /// </summary>
        public float Weight { get; set; }
        
        /// <summary>
        /// Pontos obtidos ao pegar o item
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Quantidade do item existente
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Diz se o item é empilhavel
        /// </summary>
        public bool Stackable { get; set; }

        /// <summary>
        /// Caminho para a Sprite do item
        /// </summary>
        public string Sprite { get; set; }

        /// <summary>
        /// Raridade do minério
        /// </summary>
        public Raritys Rarity { get; set; }

        /// <summary>
        /// Tipo do minério
        /// </summary>
        public OresTypes OreType { get; set; }
    }
}
