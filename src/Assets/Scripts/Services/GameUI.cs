using Assets.Scripts.Models;
using Motherload.Factories;
using Motherload.Interfaces;
using Motherload.Interfaces.Unity;
using System.Linq;
using UnityEngine;

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
        private IInventory Inventory;

        #endregion

        #region Private Properties

        /// <summary>
        /// Flag que indica se o inventário está aberto ou não
        /// </summary>
        private bool InventoryIsOpen = false;

        /// <summary>
        /// GameObject pai dos ItemSlots
        /// </summary>
        private GameObject InventorySlotsPanel;

        /// <summary>
        /// GameObject pai do inventário
        /// </summary>
        private GameObject InventoryPanel { get; set; }
        
        /// <summary>
        /// Lista com todos os ItemSlots
        /// </summary>
        private ItemSlot[] ItemSlots;

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
            
            Inventory = DependencyInjector.Retrieve<IInventory>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Implementação de <see cref="IGameUI.RefreshInventory"/>
        /// </summary>
        public void RefreshInventory()
        {
            if (ItemSlots == null)
                ItemSlots = InventorySlotsPanel.GetComponentsInChildren<ItemSlot>();

            var i = 0;
            for (; i < ItemSlots.Length && i < Inventory.InventoryItems.Count; i++)
            {
                ItemSlots[i].Item = Inventory.InventoryItems[i];
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

        #endregion
    }
}
