using Assets.Scripts.Models;
using Motherload.Factories;
using Motherload.Interfaces;
using Motherload.Interfaces.Unity;
using Motherload.Models;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Services
{
    /// <summary>
    /// Implementação de <see cref="IGameUI"/>
    /// </summary>
    public class GameUI : IGameUI
    {
        #region Services
        
        /// <summary>
        /// Instância de IInventory
        /// </summary>
        private IInventory m_Inventory;

        /// <summary>
        /// Instância do IPlayer
        /// </summary>
        private IPlayer m_Player;

        #endregion

        #region Private Properties

        /// <summary>
        /// Flag que indica se o inventário está aberto ou não
        /// </summary>
        private bool InventoryIsOpen = false;

        /// <summary>
        /// GameObject pai do inventário
        /// </summary>
        private GameObject InventoryPanel { get; set; }

        /// <summary>
        /// GameObject pai dos ItemSlots
        /// </summary>
        private GameObject InventorySlotsPanel;

        /// <summary>
        /// Lista com todos os ItemSlots
        /// </summary>
        private ItemSlot[] ItemSlots;

        /// <summary>
        /// GameObject pai dos itens do player
        /// </summary>
        private GameObject PlayerSlots;

        /// <summary>
        /// Lista com todos os itens do jogador
        /// </summary>
        private ItemSlot[] PlayerItemSlots;
        
        /// <summary>
        /// GameObject do jogador
        /// </summary>
        private GameObject Player { get; set; }
        
        /// <summary>
        /// Barra de vida do jogador
        /// </summary>
        private Image Lifebar;

        /// <summary>
        /// Barra de combustivel do jogador
        /// </summary>
        private Image Fuelbar;

        #endregion

        #region Public Properties

        /// <summary>
        /// Implementação de <see cref="IGameUI.LifeBar"/>
        /// </summary>
        public IStatsbar LifeBar { get; set; }

        /// <summary>
        /// Implementação de <see cref="IGameUI.FuelBar"/>
        /// </summary>
        public IStatsbar FuelBar { get; set; }

        #endregion

        #region Construtors

        /// <summary>
        /// Implementação de <see cref="IGameUI.Initialize"/>
        /// </summary>
        public void Initialize()
        {
            var objects = Resources.FindObjectsOfTypeAll<GameObject>();

            InventoryPanel = objects.FirstOrDefault(g => g.name == "Inventory Panel");
            InventorySlotsPanel = objects.FirstOrDefault(g => g.name == "Slots Panel");
            PlayerSlots = objects.FirstOrDefault(g => g.name == "Player Slots");
            Player = objects.FirstOrDefault(g => g.name == "Player");
            
            m_Inventory = DependencyInjector.Retrieve<IInventory>();
            m_Player = DependencyInjector.Retrieve<IPlayer>();

            RefreshInventory();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Implementação de <see cref="IGameUI.EndGame"/>
        /// </summary>
        public void EndGame()
        {
            // TODO: Implentar método de fim de jogo
        }

        /// <summary>
        /// Implementação de <see cref="IGameUI.RefreshInventory"/>
        /// </summary>
        public void RefreshInventory()
        {
            if (ItemSlots == null)
                ItemSlots = InventorySlotsPanel.GetComponentsInChildren<ItemSlot>();

            var i = 0;
            for (; i < ItemSlots.Length && i < m_Inventory.InventoryItems.Count; i++)
            {
                ItemSlots[i].Item = m_Inventory.InventoryItems[i];
            }

            for (; i < ItemSlots.Length; i++)
            {
                ItemSlots[i].Item = null;
            }
        }

        /// <summary>
        /// Implementação de <see cref="IGameUI.OpenInventory"/>
        /// </summary>
        public void OpenInventory()
        {
            if (InventoryIsOpen)
                return;

            InventoryIsOpen = true;
            InventoryPanel.SetActive(InventoryIsOpen);
        }

        /// <summary>
        /// Implementação de <see cref="IGameUI.CloseInventory"/>
        /// </summary>
        public void CloseInventory()
        {
            if (!InventoryIsOpen)
                return;

            InventoryIsOpen = false;
            InventoryPanel.SetActive(InventoryIsOpen);
        }

        /// <summary>
        /// Implementação de <see cref="IGameUI.ToggleInventory"/>
        /// </summary>
        public void ToggleInventory()
        {
            InventoryIsOpen ^= true;

            InventoryPanel.SetActive(InventoryIsOpen);
        }

        #region Player

        /// <summary>
        /// Implementação de <see cref="IGameUI.GetPlayerX"/>
        /// </summary>
        public float GetPlayerX()
        {
            return Player.transform.position.x;
        }

        /// <summary>
        /// Implementação de <see cref="IGameUI.GetPlayerY"/>
        /// </summary>
        public float GetPlayerY()
        {
            return Player.transform.position.y;
        }

        /// <summary>
        /// Implementação de <see cref="IGameUI.SetPlayerX(float)"/>
        /// </summary>
        public void SetPlayerX(float x)
        {
            Player.transform.position = new Vector3(x, Player.transform.position.y);
        }

        /// <summary>
        /// Implementação de <see cref="IGameUI.SetPlayerY(float)"/>
        /// </summary>
        public void SetPlayerY(float y)
        {
            Player.transform.position = new Vector3(Player.transform.position.x, y);
        }

        /// <summary>
        /// Implementação de <see cref="IGameUI.RefreshItemDrill"/>
        /// </summary>
        public void RefreshItemDrill()
        {
            if (PlayerItemSlots == null)
                PlayerItemSlots = PlayerSlots.GetComponentsInChildren<ItemSlot>();
            
            // TODO: Implementar troca de Skin do jogador
        }

        /// <summary>
        /// Implementação de <see cref="IGameUI.RefreshItemHull"/>
        /// </summary>
        public void RefreshItemHull()
        {
            if(PlayerItemSlots == null)
                PlayerItemSlots = PlayerSlots.GetComponentsInChildren<ItemSlot>();

            PlayerItemSlots[1].Item = m_Player.Hull;
        }

        /// <summary>
        /// Implementação de <see cref="IGameUI.RefreshItemRadiator"/>
        /// </summary>
        public void RefreshItemRadiator()
        {
            if (PlayerItemSlots == null)
                PlayerItemSlots = PlayerSlots.GetComponentsInChildren<ItemSlot>();

            PlayerItemSlots[4].Item = m_Player.Radiator;
        }

        /// <summary>
        /// Implementação de <see cref="IGameUI.RefreshItemTank"/>
        /// </summary>
        public void RefreshItemTank()
        {
            if (PlayerItemSlots == null)
                PlayerItemSlots = PlayerSlots.GetComponentsInChildren<ItemSlot>();

            PlayerItemSlots[3].Item = m_Player.Tank;
        }

        /// <summary>
        /// Implementação de <see cref="IGameUI.RefreshItemCargo"/>
        /// </summary>
        public void RefreshItemCargo()
        {
            if (PlayerItemSlots == null)
                PlayerItemSlots = PlayerSlots.GetComponentsInChildren<ItemSlot>();

            PlayerItemSlots[0].Item = m_Player.Cargo;
        }

        /// <summary>
        /// Implementação de <see cref="IGameUI.RefreshItemEngine"/>
        /// </summary>
        public void RefreshItemEngine()
        {
            if (PlayerItemSlots == null)
                PlayerItemSlots = PlayerSlots.GetComponentsInChildren<ItemSlot>();

            PlayerItemSlots[2].Item = m_Player.Engine;
        }
        
        #endregion

        #endregion
    }
}
