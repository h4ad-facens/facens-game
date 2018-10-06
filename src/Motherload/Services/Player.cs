using Motherload.Enums;
using Motherload.Factories;
using Motherload.Interfaces;
using Motherload.Interfaces.Unity;
using Motherload.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Motherload.Services
{
    /// <summary>
    /// Implementação de <see cref="IPlayer"/>
    /// </summary>
    public class Player : IPlayer
    {
        #region Constants

        /// <summary>
        /// Key usada para salvas as informações relativas ao jogador no PlayerPrefs
        /// </summary>
        private static readonly string PLAYER_PREFS_KEY = "PLAYER_PREFS_KEY";

        #endregion

        #region Services

        /// <summary>
        /// Instância do serviço de armazenamento de informações
        /// </summary>
        private IPlayerPrefs m_PlayerPrefs;

        /// <summary>
        /// Instância do serviço de interações com a UI
        /// </summary>
        private IGameUI m_GameUI;

        /// <summary>
        /// Instância do serviço principal do jogo
        /// </summary>
        private IGameService m_GameService;

        #endregion

        #region Stats

        /// <summary>
        /// Implementação de <see cref="IPlayer.Health"/>
        /// </summary>
        private float m_Health;
        public float Health
        {
            get => m_Health;
            set
            {
                if(value <= 0)
                    m_GameUI.EndGame();

                var maxHealth = Hull.GetAttributeValue<float>(Attribute.HEALTH);

                m_Health = value > maxHealth ? maxHealth : value;

                m_GameUI.LifeBar?.Refresh(m_Health / maxHealth);
            }
        }

        /// <summary>
        /// Implementação de <see cref="IPlayer.Fuel"/>
        /// </summary>
        private float m_Fuel;
        public float Fuel
        {
            get => m_Fuel;
            set
            {
                if (value <= 0)
                    m_GameUI.EndGame();

                var maxFuel = Tank.GetAttributeValue<float>(Attribute.CAPACITY);

                m_Fuel = value > maxFuel ? maxFuel : value;

                m_GameUI.FuelBar?.Refresh(m_Fuel / maxFuel);
            }
        }

        /// <summary>
        /// Implementação de <see cref="IPlayer.PositionX"/>
        /// </summary>
        public float PositionX
        {
            get => m_GameUI == null ? m_GameUI.GetPlayerX() : 0;
            set => m_GameUI?.SetPlayerX(value);
        }

        /// <summary>
        /// Implementação de <see cref="IPlayer.PositionY"/>
        /// </summary>
        public float PositionY
        {
            get => m_GameUI == null ? m_GameUI.GetPlayerY() : 0;
            set => m_GameUI.SetPlayerY(value);
        }

        #endregion

        #region Equipaments

        /// <summary>
        /// Implementação de <see cref="IPlayer.Drill"/>
        /// </summary>
        private Item m_Drill;
        public Item Drill
        {
            get => m_Drill;
            set
            {
                m_Drill = value;

                if (value == null)
                    return;

                m_GameUI.RefreshItemDrill();
            }
        }

        /// <summary>
        /// Implementação de <see cref="IPlayer.Engine"/>
        /// </summary>
        private Item m_Engine;
        public Item Engine
        {
            get => m_Engine;
            set
            {
                m_Engine = value;

                if (value == null)
                    return;
                
                m_GameUI.RefreshItemEngine();
            }
        }

        /// <summary>
        /// Implementação de <see cref="IPlayer.Radiator"/>
        /// </summary>
        private Item m_Radiator;
        public Item Radiator
        {
            get => m_Radiator;
            set
            {
                m_Radiator = value;

                if (value == null)
                    return;

                m_GameUI.RefreshItemRadiator();
            }
        }

        /// <summary>
        /// Implementação de <see cref="IPlayer.Hull"/>
        /// </summary>
        private Item m_Hull;
        public Item Hull
        {
            get => m_Hull;
            set
            {
                m_Hull = value;

                if (value == null)
                    return;

                m_GameUI.RefreshItemHull();
            }
        }

        /// <summary>
        /// Implementação de <see cref="IPlayer.Cargo"/>
        /// </summary>
        private Item m_Cargo;
        public Item Cargo
        {
            get => m_Cargo;
            set
            {
                m_Cargo = value;

                if (value == null)
                    return;
                
                m_GameUI.RefreshItemCargo();
            }
        }

        /// <summary>
        /// Implementação de <see cref="IPlayer.Tank"/>
        /// </summary>
        private Item m_Tank;
        public Item Tank
        {
            get => m_Tank;
            set
            {
                m_Tank = value;

                if (value == null)
                    return;
                
                m_GameUI.RefreshItemTank();
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gera as informações iniciais do jogador
        /// </summary>
        private void GeneratePlayer()
        {
            PositionX = 0;
            PositionY = -4.5f;

            Drill = m_GameService.Items.First(o => (int)o.Type == (int)ItemTypes.DRILL && o.HasKey(Attribute.DEFAULT));
            Engine = m_GameService.Items.First(o => (int)o.Type == (int)ItemTypes.ENGINE && o.HasKey(Attribute.DEFAULT));
            Radiator = m_GameService.Items.First(o => (int)o.Type == (int)ItemTypes.RADIATOR && o.HasKey(Attribute.DEFAULT));
            Hull = m_GameService.Items.First(o => (int)o.Type == (int)ItemTypes.HULL && o.HasKey(Attribute.DEFAULT));
            Cargo = m_GameService.Items.First(o => (int)o.Type == (int)ItemTypes.CARGO && o.HasKey(Attribute.DEFAULT));
            Tank = m_GameService.Items.First(o => (int)o.Type == (int)ItemTypes.TANK && o.HasKey(Attribute.DEFAULT));

            Health = 100;
            Fuel = 100;

            SavePlayer();
        }
        
        #endregion

        #region Public Methods

        /// <summary>
        /// Implementação de <see cref="IPlayer.Initialize"/>
        /// </summary>
        public void Initialize()
        {
            m_PlayerPrefs = DependencyInjector.Retrieve<IPlayerPrefs>();
            m_GameUI = DependencyInjector.Retrieve<IGameUI>();
            m_GameService = DependencyInjector.Retrieve<IGameService>();

            LoadPlayer();
        }

        /// <summary>
        /// Implementação de <see cref="IPlayer.LoadPlayer"/>
        /// </summary>
        public void LoadPlayer()
        {
            if (!m_PlayerPrefs.HasKey(PLAYER_PREFS_KEY))
                GeneratePlayer();

            var informations = JsonConvert.DeserializeObject<Dictionary<string, string>>(m_PlayerPrefs.GetString(PLAYER_PREFS_KEY));
            
            if (informations.TryGetValue(nameof(PositionX), out var positionX))
                PositionX = float.Parse(positionX);

            if (informations.TryGetValue(nameof(PositionY), out var positionY))
                PositionY = float.Parse(positionY);

            if (informations.TryGetValue(nameof(Drill), out var drillUid))
                Drill = m_GameService.Items.Find(o => o.UniqueID == int.Parse(drillUid));

            if (informations.TryGetValue(nameof(Engine), out var engineUid))
                Engine = m_GameService.Items.Find(o => o.UniqueID == int.Parse(engineUid));

            if (informations.TryGetValue(nameof(Radiator), out var radiatorUid))
                Radiator = m_GameService.Items.Find(o => o.UniqueID == int.Parse(radiatorUid));

            if (informations.TryGetValue(nameof(Hull), out var hullUid))
                Hull = m_GameService.Items.Find(o => o.UniqueID == int.Parse(hullUid));

            if (informations.TryGetValue(nameof(Cargo), out var cargoUid))
                Cargo = m_GameService.Items.Find(o => o.UniqueID == int.Parse(cargoUid));

            if (informations.TryGetValue(nameof(Tank), out var tankUid))
                Tank = m_GameService.Items.Find(o => o.UniqueID == int.Parse(tankUid));

            if (informations.TryGetValue(nameof(Health), out var health))
                Health = float.Parse(health);

            if (informations.TryGetValue(nameof(Fuel), out var fuel))
                Fuel = float.Parse(fuel);
        }

        /// <summary>
        /// Implementação de <see cref="IPlayer.SavePlayer"/>
        /// </summary>
        public void SavePlayer()
        {
            var informations = new Dictionary<string, string>();

            informations.Add(nameof(Health), Health.ToString());
            informations.Add(nameof(Fuel), Fuel.ToString());
            informations.Add(nameof(PositionX), PositionX.ToString());
            informations.Add(nameof(PositionY), PositionY.ToString());
            informations.Add(nameof(Drill), Drill.UniqueID.ToString());
            informations.Add(nameof(Engine), Engine.UniqueID.ToString());
            informations.Add(nameof(Radiator), Radiator.UniqueID.ToString());
            informations.Add(nameof(Hull), Hull.UniqueID.ToString());
            informations.Add(nameof(Cargo), Cargo.UniqueID.ToString());
            informations.Add(nameof(Tank), Tank.UniqueID.ToString());

            m_PlayerPrefs.SetString(PLAYER_PREFS_KEY, JsonConvert.SerializeObject(informations));

        } 

        #endregion
    }
}
