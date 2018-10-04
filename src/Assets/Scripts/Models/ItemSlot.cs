﻿using Assets.Scripts.Helpers;
using Motherload.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Models
{
    /// <summary>
    /// Script para lidar com a visualização do item no inventário
    /// </summary>
    public class ItemSlot : MonoBehaviour
    {
        #region Properties

        /// <summary>
        /// Item que ficará no Slot
        /// </summary>
        private Item m_Item;

        public Item Item
        {
            get { return m_Item; }
            set
            {
                m_Item = value;

                if (m_Item == null)
                {
                    GetComponent<Image>().enabled = false;
                }
                else
                {
                    GetComponent<Image>().sprite = new AtlasLoader("Tileset").getAtlas(m_Item.Sprite);
                    GetComponent<Image>().enabled = true;
                }
            }

        }

        /// <summary>
        /// Imagem usada para visualizar o item
        /// </summary>
        [SerializeField]
        Image image;

        #endregion
    }
}
