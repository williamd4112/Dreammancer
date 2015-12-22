using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class PlayerCharacter : MonoBehaviour
    {
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded

        [SerializeField]
        private float m_Speed = 5.0f;

        [SerializeField]
        private float m_JumpForce = 300.0f;

        [SerializeField]
        private Transform m_GroundCheck;

        [SerializeField]
        private LayerMask m_WhatIsGround;

        private Rigidbody2D m_Rigidbody;
        private Animator m_Animator;
        private bool m_FacingRight = true;
        private bool m_Grounded = true;

        // Use this for initialization
        void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody2D>();
            m_Animator = GetComponent<Animator>();
        }

        void FixedUpdate()
        {
            m_Grounded = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    m_Grounded = true;
                }

            }

            m_Animator.SetBool("Grounded", m_Grounded);

            // Set the vertical animation
            //m_Animator.SetFloat("vSpeed", m_Rigidbody.velocity.y);
        }

        public void Move(float h, bool jump)
        {
            m_Rigidbody.velocity = transform.right * h * m_Speed;

            if(jump)
            {
                m_Rigidbody.AddForce(new Vector2(0.0f, m_JumpForce));
            }

            m_Animator.SetFloat("hSpeed", Mathf.Abs(h));

            if (h > 0 && !m_FacingRight)
            {
                Flip();
            }
            else if (h < 0 && m_FacingRight)
            {
                Flip();
            }

            // If the player should jump...
            if (m_Grounded && jump && m_Animator.GetBool("Grounded"))
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Animator.SetBool("Grounded", false);
                m_Rigidbody .AddForce(new Vector2(0f, m_JumpForce));
            }
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
