using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class DragonSpawningTrap : MonoBehaviour
    {
        [SerializeField]
        private Transform[] m_SpawnPoints;
        [SerializeField]
        private GameObject m_Template;
        [SerializeField]
        private GameObject m_SpawningEffect;
        [SerializeField]
        private float m_Period = 2.0f;
        private bool m_Expired = true;
        private bool m_PlayerIn = false;

        // Update is called once per frame
        void Update()
        {
            if (m_Expired && m_PlayerIn)
            {
                foreach (Transform sp in m_SpawnPoints)
                {
                    GameObject.Instantiate(m_SpawningEffect, sp.position, sp.rotation);
                    GameObject.Instantiate(m_Template, sp.position, sp.rotation);
                }
                m_Expired = false;
                StartCoroutine(Countdown(m_Period));
            }
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                m_PlayerIn = true;
        }

        IEnumerator Countdown(float t)
        {
            yield return new WaitForSeconds(t);
            m_Expired = true;
        }
    }
}
