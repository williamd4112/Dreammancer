using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MonsterCharacter : MonoBehaviour
    {
        [SerializeField]
        private float m_Speed = 3.0f;

        private Rigidbody2D m_Rigidbody;
        private bool m_FacingRight = true;

        // Use this for initialization
        void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Move(float h, bool jump)
        {
            // If the input is moving the player right and the player is facing left...
            if (h > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (h < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }

            m_Rigidbody.velocity = Vector2.right * h * m_Speed;
        }

        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
