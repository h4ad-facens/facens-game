using Motherload.Models;
using System.Collections.Generic;

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

        /// <summary>
        /// Chunks que foram carregados
        /// </summary>
        List<int[]> ChunksLoaded { get; set; }

        /// <summary>
        /// Todos os chunks gerados no jogo
        /// </summary>
        List<Chunk> Chunks { get; set; }

        /// <summary>
        /// Lista com todos os itens do jogo
        /// </summary>
        List<Item> Items { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Iniciliza o jogo
        /// </summary>
        void Initialize();

        #endregion

        #region Generators
        
        /// <summary>
        /// Gerá um arquivo de configuração padrão
        /// </summary>
        string GenerateConfig();

        #endregion

        #region Methods

        /// <summary>
        /// Salva os Chunks gerados
        /// </summary>
        void SaveChunks();

        /// <summary>
        /// Carrega os Chunks gerados e salvos no HD.
        /// </summary>
        void LoadChunks();

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
        void LoadLayers();

        /// <summary>
        /// Carrega os itens do jogo
        /// </summary>
        void LoadItems();

        #endregion

    }
}
