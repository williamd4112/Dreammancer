using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Collider2D))]
    public class LaserTriggerByPlayer : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_ToTrigger;
        
        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                m_ToTrigger.SetActive(true);
            }
        }
    }

}