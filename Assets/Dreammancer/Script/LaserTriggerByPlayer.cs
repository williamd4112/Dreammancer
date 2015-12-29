using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Collider2D))]
    public class LaserTriggerByPlayer : MonoBehaviour
    {
        [SerializeField]
        public Transform[] m_ToTriggers;
        
        void Start()
        {
         
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                foreach(Transform g in m_ToTriggers)
                    g.gameObject.SetActive(true);
                Destroy(gameObject);
            }
        }
    }

}