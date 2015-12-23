using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public delegate void HealthChangeEvent(int hp);
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private int m_MaxHealth;
        [SerializeField]
        private int m_Health;
        public int HealthPoint
        {
            get { return m_Health; }
        }

        private HealthChangeEvent m_HealthEvents;

        public void increaseHealth(int hp)
        {
            m_Health = Mathf.Clamp(m_Health + hp, 0, m_MaxHealth);
            m_HealthEvents.Invoke(m_Health);
        }

        public void decreaseHealth(int hp)
        {
            m_Health = Mathf.Clamp(m_Health - hp, 0, m_MaxHealth);
            InvokeOnHealthChangeEvent();
        }

        public void RegisterHealthChangeEvent(HealthChangeEvent e)
        {
            m_HealthEvents += e;
            InvokeOnHealthChangeEvent();
        }

        private void InvokeOnHealthChangeEvent()
        {
            if (m_HealthEvents != null)
                m_HealthEvents.Invoke(m_Health);
        }

        // Use this for initialization
        void Start()
        {
            m_Health = m_MaxHealth;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
