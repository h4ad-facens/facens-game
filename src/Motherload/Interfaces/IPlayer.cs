using Motherload.Models;

namespace Motherload.Interfaces
{
    /// <summary>
    /// Serviço que lida com o jogador
    /// </summary>
    public interface IPlayer
    {
        #region Stats

        /// <summary>
        /// Vida do jogador
        /// </summary>
        float Health { get; set; }

        /// <summary>
        /// Combustivel do jogador
        /// </summary>
        float Fuel { get; set; }

        /// <summary>
        /// Posição no eixo X do jogador
        /// </summary>
        float PositionX { get; set; }

        /// <summary>
        /// Posição no eixo Y do jogador
        /// </summary>
        float PositionY { get; set; }

        #endregion

        #region Equipaments

        /// <summary>
        /// Broca do robô
        /// </summary>
        Item Drill { get; set; }

        /// <summary>
        /// Motor do robô
        /// </summary>
        Item Engine { get; set; }
        
        /// <summary>
        /// Radiador do robô
        /// </summary>
        Item Radiator { get; set; }

        /// <summary>
        /// Proteção externa do robô
        /// </summary>
        Item Hull { get; set; }

        /// <summary>
        /// Armazenamento do robô
        /// </summary>
        Item Cargo { get; set; }

        /// <summary>
        /// Tanque de combustível do robô
        /// </summary>
        Item Tank { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Inicializa o serviço
        /// </summary>
        void Initialize();
        
        /// <summary>
        /// Carrega as informações do jogador
        /// </summary>
        void LoadPlayer();

        /// <summary>
        /// Salva as informações do jogador
        /// </summary>
        void SavePlayer();

        #endregion
    }
}
