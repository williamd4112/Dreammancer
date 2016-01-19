using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MonsterCharacter : MonoBehaviour
    {
        [SerializeField]
        private float m_Speed = 3.0f;
        [SerializeField]
        private float m_JumpForce = 400f;
        private Animator m_Anim;
        private Rigidbody2D m_Rigidbody;
        private bool m_FacingRight = true;

        void Awake()
        {
            m_Anim = GetComponent<Animator>();
        }
        // Use this for initialization
        void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Move(float h, bool jump)
        {
            m_Anim.SetFloat("Speed", Mathf.Abs(h));
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
            Vector2 velocity = m_Rigidbody.velocity;
            velocity.x = (Vector2.right * h * m_Speed).x;

            m_Rigidbody.velocity = velocity;

            // If the player should jump...
            if (jump)
            {
                // Add a vertical force to the player.
                m_Rigidbody.AddForce(new Vector2(0f, m_JumpForce));
            }


        }

        public void aimFly(float x, float y)
        {
           
            m_Anim.SetFloat("Speed", Mathf.Abs(x));
            // If the input is moving the player right and the player is facing left...
            if (x > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
             else if (x < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            m_Rigidbody.velocity = Vector2.right * x * m_Speed + Vector2.up * y * m_Speed;
            //m_Rigidbody.velocity = Vector2.up * y * m_Speed;

        }

        public void Fly(float h)
        {

            m_Anim.SetFloat("Speed", Mathf.Abs(h));
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

        public void drift(float x, float y)
        {

            m_Anim.SetFloat("Speed", Mathf.Abs(x));
            // If the input is moving the player right and the player is facing left...
            if (x > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (x < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            m_Rigidbody.velocity = Vector2.right * x * m_Speed + Vector2.up * y * m_Speed;
            


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
