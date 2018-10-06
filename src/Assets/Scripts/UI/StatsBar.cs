using Motherload.Factories;
using Motherload.Interfaces;
using Motherload.Interfaces.Unity;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// Atualiza a barra de status
    /// </summary>
    public class StatsBar : MonoBehaviour, IStatsbar
    {
        #region Properties

        /// <summary>
        /// Tipo de barra
        /// </summary>
        public TypeBar TypeBar;

        /// <summary>
        /// Imagem da barra
        /// </summary>
        public Image image; 

        #endregion

        #region Unity

        /// <summary>
        /// Executado quando o jogo é iniciado
        /// </summary>
        public void Start()
        {
            image = GetComponent<Image>();
            var gameUi = DependencyInjector.Retrieve<IGameUI>();
            var player = DependencyInjector.Retrieve<IPlayer>();

            if (TypeBar == TypeBar.LIFE) {
                gameUi.LifeBar = this;
                player.Health = player.Health;
            }

            if (TypeBar == TypeBar.FUEL) {
                gameUi.FuelBar = this;
                player.Fuel = player.Fuel;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Implementação de <see cref="IStatsbar.Refresh(float)"/>
        /// </summary>
        public void Refresh(float value)
        {
            image.fillAmount = value;
        } 

        #endregion
    }

    /// <summary>
    /// Tipo de barras
    /// </summary>
    public enum TypeBar
    {
        FUEL,
        LIFE,
    }
}
