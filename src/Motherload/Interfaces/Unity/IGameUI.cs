namespace Motherload.Interfaces.Unity
{
    /// <summary>
    /// Lida com interações com a UI
    /// </summary>
    public interface IGameUI
    {
        #region Properties

        /// <summary>
        /// Atualiza a barra de vida do jogador
        /// </summary>
        IStatsbar LifeBar { get; set; }

        /// <summary>
        /// Atualiza a barra de combustivel do jogador
        /// </summary>
        IStatsbar FuelBar { get; set; }

        #endregion

        #region Construtors

        /// <summary>
        /// Inicializa a classe
        /// </summary>
        void Initialize();

        #endregion

        #region Methods

        /// <summary>
        /// Fim de jogo
        /// </summary>
        void EndGame();

        /// <summary>
        /// Atualiza o inventário
        /// </summary>
        void RefreshInventory();

        /// <summary>
        /// Abre o inventário para o player
        /// </summary>
        void OpenInventory();

        /// <summary>
        /// Fecha o inventário
        /// </summary>
        void CloseInventory();

        /// <summary>
        /// Abre ou fecha o inventário
        /// </summary>
        void ToggleInventory();

        #region Player

        /// <summary>
        /// Retorna a posição no eixo X do jogador
        /// </summary>
        /// <returns></returns>
        float GetPlayerX();

        /// <summary>
        /// Retorna a posição no eixo Y do jogador
        /// </summary>
        /// <returns></returns>
        float GetPlayerY();

        /// <summary>
        /// Seta a posição do jogador no eixo X
        /// </summary>
        /// <param name="x">Posição no eixo X</param>
        void SetPlayerX(float x);

        /// <summary>
        /// Seta a posição do jogador no eixo Y
        /// </summary>
        /// <param name="y">Posição no eixo Y</param>
        void SetPlayerY(float y);

        /// <summary>
        /// Atualiza a broca do jogador
        /// </summary>
        void RefreshItemDrill();

        /// <summary>
        /// Atualiza o casco do jogador
        /// </summary>
        void RefreshItemHull();

        /// <summary>
        /// Atualiza o radiador do jogador
        /// </summary>
        void RefreshItemRadiator();

        /// <summary>
        /// Atualiza o tanque do jogador
        /// </summary>
        void RefreshItemTank();

        /// <summary>
        /// Atualiza o armazenamento do jogador
        /// </summary>
        void RefreshItemCargo();

        /// <summary>
        /// Atualiza o motor do jogador
        /// </summary>
        void RefreshItemEngine();

        #endregion

        #endregion
    }
}
