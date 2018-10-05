using Motherload.Factories;
using Motherload.Interfaces.Unity;
using UnityEngine;

namespace Assets.Scripts.UI.Buttons
{
    /// <summary>
    /// Lida com os botões do inventário
    /// </summary>
    public class InventoryHandler : MonoBehaviour
    {
        #region Services

        /// <summary>
        /// Instância do serviço de UI
        /// </summary>
        private IGameUI m_GameUI;

        #endregion
        
        #region Unity

        /// <summary>
        /// Executado quando o jogo inicia
        /// </summary>
        public void Start()
        {
            m_GameUI = DependencyInjector.Retrieve<IGameUI>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Método que fecha o inventário
        /// </summary>
        public void OnCloseInventory()
        {
            m_GameUI.CloseInventory();
        }

        #endregion
    }
}
