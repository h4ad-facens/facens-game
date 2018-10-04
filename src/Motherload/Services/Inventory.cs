using Motherload.Factories;
using Motherload.Interfaces;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using Motherload.Models;
using Motherload.Interfaces.Unity;

namespace Motherload.Services
{
    /// <summary>
    /// Classe que implementa <see cref="IInventory"/>
    /// </summary>
    public class Inventory : IInventory
    {
        #region Constants

        /// <summary>
        /// Constante usada para obter e salvar informações no PlayerPrefs
        /// </summary>
        private static readonly string INVENTORY_KEY = "INVENTORY_KEY_PREFS";

        /// <summary>
        /// Constante usada para setar capacidade máxima de itens no inventário
        /// </summary>
        private static readonly int INVENTORY_CAPACITY = 15;

        #endregion

        #region Services

        /// <summary>
        /// Instância de PlayerPrefs
        /// </summary>
        private IPlayerPrefs PlayerPrefs;

        /// <summary>
        /// Instância de GameService
        /// </summary>
        private IGameService GameService;

        /// <summary>
        /// Instância de GameUI
        /// </summary>
        private IGameUI GameUI;

        #endregion

        #region Public Properties

        /// <summary>
        /// Implementação de <see cref="IInventory.InventoryItems"/>
        /// </summary>
        public List<Item> InventoryItems { get; set; }

        /// <summary>
        /// Peso atual dos itens no inventário
        /// </summary>
        public float Weight => InventoryItems.Sum(o => o.Weight * o.Amount);


        public float MaxWeight = 100f;

        #endregion

        #region Constructors

        /// <summary>
        /// Implementação de <see cref="IInventory.Initialize"/>
        /// </summary>
        public void Initialize()
        {
            PlayerPrefs = DependencyInjector.Retrieve<IPlayerPrefs>();
            GameService = DependencyInjector.Retrieve<IGameService>();
            GameUI = DependencyInjector.Retrieve<IGameUI>();

            LoadInventory();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Implementação de <see cref="IInventory.SaveInventory"/>
        /// </summary>
        public void SaveInventory()
        {
            PlayerPrefs.SetString(INVENTORY_KEY, JsonConvert.SerializeObject(InventoryItems));
        }

        /// <summary>
        /// Implementação de <see cref="IInventory.LoadInventory"/>
        /// </summary>
        public void LoadInventory()
        {
            if (PlayerPrefs.HasKey(INVENTORY_KEY))
                InventoryItems = JsonConvert.DeserializeObject<List<Item>>(PlayerPrefs.GetString(INVENTORY_KEY));
            else
                InventoryItems = new List<Item>();
        }

        #endregion
        
        #region Public Methods

        /// <summary>
        /// Implementação de <see cref="IInventory.Add(int, int)"/>
        /// </summary>
        public void Add(int uid, int amount)
        {
            var item = GameService.Items.FirstOrDefault(o => o.UniqueID == uid);

            // TODO: Pensar em uma forma melhor de lidar com esses casos
            if (item == null)
                return;

            if (item.Stackable)
            {
                var itemInventory = InventoryItems.FirstOrDefault(o => o.UniqueID == uid);

                if(itemInventory == null)
                {
                    item = AddAmount(item, amount);

                    if (item.Amount == 0)
                        return;

                    InventoryItems.Add(item);
                    GameUI.RefreshInventory();
                    return;
                }
                
                var itemInventoryIndex = InventoryItems.IndexOf(itemInventory);
                InventoryItems[itemInventoryIndex] = AddAmount(itemInventory, amount);
                
                GameUI.RefreshInventory();
                return;
            }

            if (!CanPick(uid, amount))
                return;

            for (var i = 0; i < amount; i++)
            {
                if (!CanPick(uid, 1))
                    continue;

                var nonStack = AddAmount(item, 1);

                if (nonStack.Amount == 0)
                    continue;

                InventoryItems.Add(nonStack);
            }

            GameUI.RefreshInventory();
        }
        
        /// <summary>
        /// Adiciona uma quantidade <see cref="amount"/> no item verificando também se é possível carregar eles.
        /// Se não for possível, ele dropa o item.
        /// </summary>
        /// <param name="item">Item usado de referência</param>
        /// <param name="amount">Quantidade do item a ser adicionada</param>
        /// <returns></returns>
        private Item AddAmount(Item item, int amount)
        {
            var newWeight = Weight;

            for (var i = 0; i < amount; i++)
            {
                if ((newWeight + item.Weight) > MaxWeight)
                {
                    DropItem(item.UniqueID, amount - i);
                    break;
                }

                item.Amount++;
                newWeight += item.Weight;
            }

            return item;
        }

        /// <summary>
        /// Implementação de <see cref="IInventory.Remove(int, int)"/>
        /// </summary>
        public void Remove(int uid, int amount)
        {
            InventoryItems.ForEach(o => 
            {
                if (o.UniqueID == uid)
                    o.Amount -= amount;
            });

            GameUI.RefreshInventory();
        }

        /// <summary>
        /// Implementação de <see cref="IInventory.CanPick(int, int)"/>
        /// </summary>
        public bool CanPick(int uid, int amount)
        {
            if (InventoryItems.Count < INVENTORY_CAPACITY)
                return true;

            DropItem(uid, amount);
            return false;
        }

        /// <summary>
        /// Implementação de <see cref="IInventory.DropItem(int, int)"/>
        /// </summary>
        public void DropItem(int uid, int amount)
        {
            
        }

        #endregion
    }
}
