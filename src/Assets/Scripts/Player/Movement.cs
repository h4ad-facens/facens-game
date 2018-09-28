using UnityEngine;

namespace Motherload.Core.Player
{
    /// <summary>
    /// Classe que realizará o movimento do jogador
    /// </summary>
    public class Movement : MonoBehaviour
    {
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
        /// Altitude máxima que o jogador pode chegar
        /// </summary>
        public int MaxHeight = 60;

        /// <summary>
        /// Posição em X máxima no sentido esquerdo em que o jogador pode se mover
        /// </summary>
        public int MaxWidthLeft = -32;
        
        /// <summary>
        /// Posição em X máxima no sentido direito em que o jogador pode se mover
        /// </summary>
        public int MaxWidthRight = 64;

        /// <summary>
        /// O jogador
        /// </summary>
        private Rigidbody2D Player;
    
        /// <summary>
        /// Iniciliza
        /// </summary>
        public void Start()
        {
            Player = GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// Executado após um intervalo de tempo independente do FrameRate
        /// </summary>
        void FixedUpdate()
        {
            if (Player.position.y >= MaxHeight)
            {
                Player.velocity = Vector2.zero;
                return;
            }

            if(Player.position.x >= MaxWidthRight)
            {
                Player.velocity = Vector2.zero;
                Player.AddForce(new Vector2(-JetpackForce, 0));
                return;
            }

            if (Player.position.x <= MaxWidthLeft)
            {
                Player.velocity = Vector2.zero;
                Player.AddForce(new Vector2(JetpackForce, 0));
                return;
            }
            
            if (Input.GetKey(KeyCode.W))
                Player.AddForce(new Vector2(0, JetpackForce));

            //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
            Player.AddForce(new Vector2(Input.GetAxis("Horizontal"), 0) * Speed);

            if (Player.velocity.magnitude > MaxSpeed)
                Player.velocity = Player.velocity.normalized * MaxSpeed;
            
        }

    }
}
