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
        /// <summary>
        /// Serviço principal do jogo
        /// </summary>
        private IGameService m_GM;

        /// <summary>
        /// Mundo em que será minerado
        /// </summary>
        [SerializeField]
        private Tilemap m_World;

        /// <summary>
        /// Tempo para que seja possível realizar a próxima mineração.
        /// </summary>
        private float m_NextMining;

        /// <summary>
        /// Intervalo de tempo para que seja possível realizar a próxima mineração.
        /// </summary>
        public float m_MiningInterval;

        /// <summary>
        /// Executado quando o script é carregado pela primeira vez.
        /// </summary>
        public void Start()
        {
            m_GM = DependencyInjector.Retrieve<IGameService>();
        }

        /// <summary>
        /// Chamado a cada atualização de frame.
        /// </summary>
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.S) && Time.time > m_NextMining)
            {
                UpdateAndRemoveTile(0, -1);
            }

            if (Input.GetKeyDown(KeyCode.D) && Time.time > m_NextMining)
            {
                UpdateAndRemoveTile(1, 0);
            }

            if (Input.GetKeyDown(KeyCode.A) && Time.time > m_NextMining)
            {
                UpdateAndRemoveTile(-1, 0);
            }
        }

        /// <summary>
        /// Atualiza e remove o piso
        /// </summary>
        /// <param name="offsetX">Offset em X</param>
        /// <param name="offsetY">Offset em Y</param>
        public void UpdateAndRemoveTile(int offsetX, int offsetY)
        {
            var worldPlayerX = (int)Math.Ceiling(transform.position.x / 4);
            var worldPlayerY = (int)Math.Ceiling(transform.position.y / 4);
            var pos = new Vector3Int((int)Math.Floor(transform.position.x) + offsetX, (int)Math.Floor(transform.position.y) + offsetY, 0);

            if (m_GM.Configurations.MaxSpawnWorldHeight < transform.position.y)
                return;

            var tile = m_GM.Chunks.FirstOrDefault(o => o.WX == worldPlayerX && o.WY == worldPlayerY);

            if (tile == null)
                return;

            var tileIndex = m_GM.Chunks.IndexOf(tile);

            if (tileIndex == -1)
                return;

            tile.WT.ToList().RemoveAll(o => o.X == pos.x && o.Y == pos.y);
            m_GM.Chunks[tileIndex] = tile;

            m_World.SetTile(pos, null);
            m_NextMining = Time.time + m_MiningInterval;
        }

    }
}
