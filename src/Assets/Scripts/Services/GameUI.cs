using Assets.Scripts.Models;
using Motherload.Factories;
using Motherload.Interfaces.Unity;
using UnityEngine;

namespace Assets.Scripts.Services
{
    /// <summary>
    /// Implementação de <see cref="IGameUI"/>
    /// </summary>
    public class GameUI : IGameUI
    {
        #region Private Properties

        /// <summary>
        /// Instância de IInventory
        /// </summary>
        private IInventory Inventory;

        /// <summary>
        /// GameObject pai dos ItemSlosts
        /// </summary>
        private GameObject InventorySlot { get; set; }

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
            InventorySlot = GameObject.Find("Slots Panel");
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
                ItemSlots = InventorySlot.GetComponentsInChildren<ItemSlot>();

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

        #endregion
    }
}
