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
        public Transform target;

        /// <summary>
        /// Distancia entre o jogador e a camera.
        /// </summary>
        public Vector3 offset;
        
        /// <summary>
        /// Velocidade de smooth
        /// </summary>
        public float smoothSpeed = 0.125f;

        /// <summary>
        /// É chamado a cada atualização de frame.
        /// </summary>
        void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed);
        }
    }
}