using Motherload.Models;
using System.Collections.Generic;

namespace Motherload.Interfaces
{
    /// <summary>
    /// Interface para gerenciar o invetário
    /// </summary>
    public interface IInventory
    {
        #region Constructors

        /// <summary>
        /// Inicializa o inventário
        /// </summary>
        void Initialize();

        #endregion

        #region Methods
        
        /// <summary>
        /// Salva as informações do inventário
        /// </summary>
        void SaveInventory();

        /// <summary>
        /// Carrega as informações do inventário
        /// </summary>
        void LoadInventory();
        
        #endregion

        #region Properties

        /// <summary>
        /// Lista de itens exibidos no inventário.
        /// </summary>
        List<Item> InventoryItems { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Adiciona um item ao inventário
        /// </summary>
        /// <param name="uid">UniqueID do item a ser adicionado ao inventário</param>
        /// <param name="amount">Quantidade do item a ser adicionada</param>
        void Add(int uid, int amount);
        
        /// <summary>
        /// Remove items do inventário
        /// </summary>
        /// <param name="uid">UniqueID do item a ser removido ao inventário</param>
        /// <param name="amount">Quantidade do item a ser removida</param>
        void Remove(int uid, int amount);

        /// <summary>
        /// Verifica se pode obter o item
        /// </summary>
        /// <param name="uid">UniqueID do item a ser pegado para o inventário</param>
        /// <param name="amount">Quantidade do item a ser pegado</param>
        /// <returns></returns>
        bool CanPick(int uid, int amount);

        /// <summary>
        /// Dropa o item no chão
        /// </summary>
        /// <param name="uid">UniqueID do item a ser dropado do inventário</param>
        /// <param name="amount">Quantidade do item a ser dropado</param>
        void DropItem(int uid, int amount);

        #endregion
    }
}
