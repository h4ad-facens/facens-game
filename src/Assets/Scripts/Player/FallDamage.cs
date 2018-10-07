using Motherload.Factories;
using Motherload.Interfaces;
using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Script para lidar com o dano de queda do jogador
    /// </summary>
    public class FallDamage : MonoBehaviour
    {
        #region Services

        /// <summary>
        /// Instância do serviço que lida com o jogador
        /// </summary>
        private IPlayer m_Player;

        #endregion

        #region Unity

        /// <summary>
        /// Executado toda vez que inicia o jogo
        /// </summary>
        public void Start()
        {
            m_Player = DependencyInjector.Retrieve<IPlayer>();
        }

        /// <summary>
        /// Executado em cada colisão
        /// </summary>
        /// <param name="collision">Player na colisão</param>
        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (Math.Abs(collision.relativeVelocity.y) > 12f || Math.Abs(collision.relativeVelocity.x) > 14f)
            {
                var maxValue = 0f;

                if (collision.relativeVelocity.y > collision.relativeVelocity.x)
                    maxValue = Math.Abs(collision.relativeVelocity.y);
                else
                    maxValue = Math.Abs(collision.relativeVelocity.x * 0.6f);

                m_Player.Health -= (0.2f) * maxValue;
            }
        } 

        #endregion

    }
}
