namespace Motherload.Models
{
    /// <summary>
    /// Atributos adicionais para os items
    /// </summary>
    public class Attribute
    {
        #region Constants
        
        /// <summary>
        /// Key para o atributo de peso
        /// </summary>
        public static readonly string WEIGHT = "Weight";

        /// <summary>
        /// Key para o atributo de quantidade
        /// </summary>
        public static readonly string AMOUNT = "Amount";

        /// <summary>
        /// Key para o atributo de empilhavel.
        /// </summary>
        public static readonly string STACKABLE = "Stackable";

        /// <summary>
        /// Key para o atributo da sprite.
        /// </summary>
        public static readonly string SPRITE = "Sprite";

        /// <summary>
        /// Key para o atributo do tipo de minério.
        /// </summary>
        public static readonly string ORETYPE = "OreType";

        #endregion

        #region Properties

        /// <summary>
        /// Key do atributo
        /// </summary>
        public string Key;

        /// <summary>
        /// Valor do atributo
        /// </summary>
        public string Value; 

        #endregion
    }
}
