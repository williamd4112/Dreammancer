using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class CarryableObject : MonoBehaviour
    {
        [SerializeField]
        private Transform m_GroundCheck;

        [SerializeField]
        private float m_GroundCheckRadius;

        [SerializeField]
        private LayerMask m_WhatIsGround;

        private bool m_Grounded;

        private Vector2 m_CarrierVelocity = Vector2.zero;
        public Vector2 CarrierVelocity
        {
            get { return m_CarrierVelocity; }
            set { m_CarrierVelocity = value; }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            m_Grounded = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, m_GroundCheckRadius, m_WhatIsGround);
            Vector2 v = Vector2.zero;
            for (int i = 0; i < colliders.Length; i++)
            {
                GameObject obj = colliders[i].gameObject;
                if (colliders[i].gameObject != gameObject)
                {
                    m_Grounded = true;

                    Rigidbody2D rigidbody = obj.GetComponent<Rigidbody2D>();
                    if (rigidbody != null)
                    {
                        v += rigidbody.velocity;
                    }
                }
            }
            m_CarrierVelocity = v;
        }
    }
}
