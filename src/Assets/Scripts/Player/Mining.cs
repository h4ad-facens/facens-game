using Motherload.Enums;
using Motherload.Factories;
using Motherload.Interfaces;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Script que lida com a mineração do jogo.
    /// </summary>
    public class Mining : MonoBehaviour
    {
        #region Services

        /// <summary>
        /// Serviço principal do jogo
        /// </summary>
        private IGameService m_GM;

        /// <summary>
        /// Serviço de inventário
        /// </summary>
        private IInventory m_Inventory;

        #endregion

        #region Private Properties

        /// <summary>
        /// Mundo em que será minerado
        /// </summary>
        [SerializeField]
        private Tilemap m_World;

        /// <summary>
        /// Tempo para que seja possível realizar a próxima mineração.
        /// </summary>
        private float m_NextMining;

        #endregion

        #region Public Properties

        /// <summary>
        /// Intervalo de tempo para que seja possível realizar a próxima mineração.
        /// </summary>
        public float m_MiningInterval;

        #endregion

        #region Unity

        /// <summary>
        /// Executado quando o script é carregado pela primeira vez.
        /// </summary>
        public void Start()
        {
            m_GM = DependencyInjector.Retrieve<IGameService>();
            m_Inventory = DependencyInjector.Retrieve<IInventory>();
        }

        /// <summary>
        /// Chamado a cada atualização de frame.
        /// </summary>
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.S) && Time.time > m_NextMining)
                UpdateAndRemoveTile(0, -1);

            if (Input.GetKeyDown(KeyCode.D) && Time.time > m_NextMining)
                UpdateAndRemoveTile(1, 0);

            if (Input.GetKeyDown(KeyCode.A) && Time.time > m_NextMining)
                UpdateAndRemoveTile(-1, 0);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Atualiza e remove o piso
        /// </summary>
        /// <param name="offsetX">Offset em X</param>
        /// <param name="offsetY">Offset em Y</param>
        public void UpdateAndRemoveTile(int offsetX, int offsetY)
        {
            var pos = new Vector3Int((int)Math.Floor(transform.position.x) + offsetX, (int)Math.Floor(transform.position.y) + offsetY, 0);

            if (Math.Floor(transform.position.y) > -5)
                return;

            if (Math.Floor(transform.position.y) > -7 && (pos.x < -1 || pos.x > 5))
                return;

            var tile = m_World.GetTile<Oretile>(pos);

            if (tile == null)
                return;

            var item = m_GM.Items.FirstOrDefault(o => o.GetAttributeValue<int>(Motherload.Models.Attribute.ORETYPE) == (int)tile.TileType);

            if (item == null)
                return;

            m_Inventory.Add(item.UniqueID, 1);
            m_World.SetTile(pos, null);
            m_NextMining = Time.time + m_MiningInterval;
        } 

        #endregion
    }
}
