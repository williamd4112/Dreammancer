using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MonsterCharacter : MonoBehaviour
    {
        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;            // Whether or not the player is grounded.
        [SerializeField]
        private LayerMask m_WhatIsGround;
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
            m_GroundCheck = transform.Find("GroundCheck");
        }
        // Use this for initialization
        void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FixedUpdate()
        {
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    m_Grounded = true;
                }
            }

            m_Anim.SetBool("Ground", m_Grounded);
        }

        public void Move(float h, bool jump)
        {
            if (m_Grounded)
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
            // If the player should jump...
            if (m_Grounded && jump && m_Anim.GetBool("Ground"))
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Anim.SetBool("Ground", false);
                m_Rigidbody.AddForce(new Vector2(0f, m_JumpForce));
            }


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
