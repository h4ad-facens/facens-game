using Motherload.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Motherload.Interfaces
{
    /// <summary>
    /// Interface da classe que irá lidar com as informações relevantes ao jogo
    /// </summary>
    public interface IGameService
    {
        #region Properties

        /// <summary>
        /// Configurações do jogo
        /// </summary>
        Config Configurations { get; set; }

        /// <summary>
        /// Camadas do jogo
        /// </summary>
        List<Layer> Layers { get; set; }

        #endregion

        #region Constructors
        
        /// <summary>
        /// Iniciliza o jogo
        /// </summary>
        void Initilize();

        #endregion

        #region Generators

        /// <summary>
        /// Gera os pisos de cada camada
        /// </summary>
        Task GenerateLayerTiles();

        /// <summary>
        /// Gerá um arquivo de configuração padrão
        /// </summary>
        string GenerateConfig();

        #endregion

        #region Methods

        /// <summary>
        /// Retorna as configurações do jogo
        /// </summary>
        /// <returns></returns>
        Config GetConfig();

        /// <summary>
        /// Carrega as configurações do PlayerPrefs
        /// </summary>
        void LoadConfig();

        /// <summary>
        /// Carrega todas as layers
        /// </summary>
        Task LoadLayers();

        #endregion

    }
}
