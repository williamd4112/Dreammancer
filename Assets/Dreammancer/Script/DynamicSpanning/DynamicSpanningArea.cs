using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class DynamicSpanningArea : MonoBehaviour
    {
        private bool m_IsSpanning = false;
        private Transform m_PlayerPos;

        // Use this for initialization
        void Start()
        {
            m_PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        }

        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                
            }
        }

    }

}