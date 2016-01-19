using UnityEngine;
using System.Collections;
using System;

namespace Dreammancer
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovingPlatform : MonoBehaviour
    {
        private float k_Epision = 0.3f;

        [SerializeField]
        Transform platform;

        [SerializeField]
        private Transform startTransform;

        [SerializeField]
        private Transform endTransform;

        [SerializeField]
        public float platformSpeed;

        private Vector3 direction;

        private Transform destination;
        private Rigidbody2D m_Rigidbody;

        void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody2D>();
            SetDestination(startTransform);
        }

        void FixedUpdate()
        {
            if (platformSpeed == 0) return;
            m_Rigidbody.velocity = direction * platformSpeed;

            if (Vector3.Distance(platform.position, destination.position) < platformSpeed)
            {
                SetDestination(destination == startTransform ? endTransform : startTransform);
            }
        }


        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(startTransform.position, platform.localScale);

            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(endTransform.position, platform.localScale);
        }

        void SetDestination(Transform dest)
        {
            destination = dest;
            direction = (destination.position - platform.position).normalized;
        }
    }

}