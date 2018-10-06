using Assets.Scripts.Helpers;
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
                    image.enabled = false;
                }
                else
                {
                    image.sprite = new AtlasLoader("Tileset").getAtlas(m_Item.GetAttributeValue<string>(Attribute.SPRITE));
                    image.enabled = true;
                }
            }

        }

        /// <summary>
        /// Imagem usada para visualizar o item
        /// </summary>
        [SerializeField]
        Image image;

        #endregion

        #region Methods

        /// <summary>
        /// Executado a cada validação que a Unity faz
        /// </summary>
        private void OnValidate()
        {
            if (image == null)
                image = GetComponent<Image>();
        }


        #endregion
    }
}
