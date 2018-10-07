using Motherload.Factories;
using Motherload.Interfaces;
using UnityEngine;

namespace Motherload.Core.Player
{
    /// <summary>
    /// Classe que realizará o movimento do jogador
    /// </summary>
    public class Movement : MonoBehaviour
    {
        #region Services
        
        /// <summary>
        /// Instância do serviço principal do jogo
        /// </summary>
        private IGameService m_GameService;

        /// <summary>
        /// Instância do serviço do jogador
        /// </summary>
        private IPlayer m_Player;

        #endregion

        #region Properties

        /// <summary>
        /// Força do Jetpack
        /// </summary>
        public float JetpackForce = 25.0f;

        /// <summary>
        /// Velocidade do jogador
        /// </summary>
        public float Speed = 15.0f;

        /// <summary>
        /// Velocidade máxima do jogador
        /// </summary>
        public float MaxSpeed = 30f;

        /// <summary>
        /// O jogador
        /// </summary>
        private Rigidbody2D Player;

        #endregion

        #region Unity

        /// <summary>
        /// Iniciliza
        /// </summary>
        public void Start()
        {
            Player = GetComponent<Rigidbody2D>();
            m_GameService = DependencyInjector.Retrieve<IGameService>();
            m_Player = DependencyInjector.Retrieve<IPlayer>();
        }

        /// <summary>
        /// Executado após um intervalo de tempo independente do FrameRate
        /// </summary>
        void FixedUpdate()
        {
            if (Player.position.y >= m_GameService.Configurations.MaxSpawnWorldHeight)
            {
                Player.velocity = Vector2.zero;
                return;
            }

            if (Player.position.x >= m_GameService.Configurations.MaxSpawnWorldX)
            {
                Player.velocity = Vector2.zero;
                Player.AddForce(new Vector2(-JetpackForce * 2, 0));
                return;
            }

            if (Player.position.x <= m_GameService.Configurations.MinSpawnWorldX)
            {
                Player.velocity = Vector2.zero;
                Player.AddForce(new Vector2(JetpackForce * 2, 0));
                return;
            }

            if (Input.GetKey(KeyCode.W))
            {
                Player.AddForce(new Vector2(0, JetpackForce));
                ReduceFuel(0.004f);
            }

            if(Input.GetAxis("Horizontal") != 0 && !Input.GetKey(KeyCode.W))
                ReduceFuel(0.004f);
            
            Player.AddForce(new Vector2(Input.GetAxis("Horizontal"), 0) * Speed);

            if (Player.velocity.magnitude > MaxSpeed)
                Player.velocity = Player.velocity.normalized * MaxSpeed;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Reduz a quantidade de combustivel do jogador
        /// </summary>
        /// <param name="value">Valor a ser diminuido</param>
        private void ReduceFuel(float value)
        {
            m_Player.Fuel -= 1 * value;
        }

        #endregion

    }
}
