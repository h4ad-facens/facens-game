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
        public float jetpackForce = 30.0f;
        
        /// <summary>
        /// Velocidade do jogador
        /// </summary>
        public float Speed = 30.0f;

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
            if (Input.GetKey(KeyCode.W))
                Player.AddForce(new Vector2(0, jetpackForce));


            //Use the two store floats to create a new Vector2 variable movement.
            Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), 0);

            //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
            Player.AddForce(movement * Speed);
        }

    }
}
