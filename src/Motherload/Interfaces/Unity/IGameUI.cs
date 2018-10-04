namespace Motherload.Interfaces.Unity
{
    /// <summary>
    /// Lida com interações com a UI
    /// </summary>
    public interface IGameUI
    {
        #region Construtors

        /// <summary>
        /// Inicializa a classe
        /// </summary>
        void Initialize();

        #endregion

        #region Methods

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

        #endregion
    }
}
