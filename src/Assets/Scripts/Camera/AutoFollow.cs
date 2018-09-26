using UnityEngine;

namespace Motherload.Core.Camera
{
    /// <summary>
    /// Script de auto-follow da camera no jogador.
    /// </summary>
    public class AutoFollow : MonoBehaviour
    {
        /// <summary>
        /// O jogador.
        /// </summary>
        public GameObject player;

        /// <summary>
        /// Distancia entre o jogador e a camera.
        /// </summary>
        private Vector3 offset;

        /// <summary>
        /// Inicialização
        /// </summary>
        void Start()
        {
            offset = transform.position - player.transform.position;
        }

        /// <summary>
        /// É chamado a cada atualização de frame.
        /// </summary>
        void LateUpdate()
        {
            transform.position = player.transform.position + offset;
        }
    }
}