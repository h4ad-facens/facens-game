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

        /// <summary>
        /// Key para o atributo de velocidade de mineração.
        /// </summary>
        public static readonly string VELOCITY_MINING = "VelocityMining";

        /// <summary>
        /// Key para o atributo da potencia do motor.
        /// </summary>
        public static readonly string HORSE_POWER = "HorsePower";

        /// <summary>
        /// Key para o atributo de vcapacidade.
        /// </summary>
        public static readonly string CAPACITY = "Capacity";

        /// <summary>
        /// Key para o atributo de tamanho.
        /// </summary>
        public static readonly string SIZE = "Size";
        
        /// <summary>
        /// Key para o atributo de efetividade.
        /// </summary>
        public static readonly string EFFECTIVENESS = "Effectiveness";

        /// <summary>
        /// Key para o atributo de vida.
        /// </summary>
        public static readonly string HEALTH = "Health";

        /// <summary>
        /// Key para o atributo "padrão".
        /// </summary>
        public static readonly string DEFAULT = "Default";

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
