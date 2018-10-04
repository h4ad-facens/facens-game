using Motherload.Factories;
using Motherload.Interfaces.Unity;
using UnityEngine;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// Classe que serve para criar atalhos
    /// </summary>
    public class KeyboardShortcuts : MonoBehaviour
    {
        #region Services

        private IGameUI m_GameUI;

        #endregion
        
        #region Shortchuts

        /// <summary>
        /// Tecla para abrir o inventário
        /// </summary>
        public KeyCode ToggleInventory = KeyCode.E;

        #endregion

        #region Unity

        /// <summary>
        /// Executado quando a aplicação inicia
        /// </summary>
        public void Start()
        {
            m_GameUI = DependencyInjector.Retrieve<IGameUI>();
        }

        /// <summary>
        /// Executado a cada frame
        /// </summary>
        public void Update()
        {
            if (Input.GetKeyDown(ToggleInventory))
                m_GameUI.ToggleInventory();
        } 

        #endregion
    }
}
