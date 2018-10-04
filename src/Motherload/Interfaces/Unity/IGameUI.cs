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

        #endregion
    }
}
