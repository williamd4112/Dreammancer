using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public delegate void HealthChangeEvent(int hp, int diff);
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private int m_MaxHealth;
        [SerializeField]
        private int m_Health; //
        public int HealthPoint
        {
            get { return m_Health; }
        }

        [SerializeField]
        private bool m_HasImmortalTime = false;
        [SerializeField]
        private float m_ImmortalPeriod = 0.1f;
        [SerializeField]
        private int m_ImmortalBlinkTimes = 4;
        [SerializeField]
        private bool m_IsImmortal = false;
        public bool Immortal
        {
            get { return m_IsImmortal; }
        }

        private HealthChangeEvent m_HealthEvents;

        public void increaseHealth(int hp)
        {
            m_Health = Mathf.Clamp(m_Health + hp, 0, m_MaxHealth);
            if (m_HealthEvents != null)
                m_HealthEvents.Invoke(m_Health, hp);
        }

        public void decreaseHealth(int hp)
        {
            if (m_IsImmortal) return;
            else if (m_HasImmortalTime) EnterImmortal();
   
            m_Health = Mathf.Clamp(m_Health - hp, 0, m_MaxHealth);
            if(m_HealthEvents != null)
                m_HealthEvents.Invoke(m_Health, -hp);
        }
        public void RegisterHealthEvent(HealthChangeEvent e)
        {
            m_HealthEvents += e;
        }

        public void EnterImmortal()
        {
            if (m_IsImmortal) return;
            m_IsImmortal = true;
            StartCoroutine(Blink(m_ImmortalPeriod, m_ImmortalBlinkTimes));
        }

        IEnumerator Blink(float period, int times)
        {
            SpriteRenderer[] rs = GetComponentsInChildren<SpriteRenderer>();
            Color[] ocolors = new Color[rs.Length];
            Color[] ncolors = new Color[rs.Length];
            for (int i = 0; i < rs.Length; i++)
            {
                Color nc = rs[i].color;
                nc.a = 0;
                ocolors[i] = rs[i].color;
                ncolors[i] = nc;
            }

            for (int i = 0; i < times; i++)
            {
                for (int j = 0; j < rs.Length; j++)
                {
                    rs[j].color = ncolors[j];
                }
                yield return new WaitForSeconds(period);
                for (int j = 0; j < rs.Length; j++)
                {
                    rs[j].color = ocolors[j];
                }
                yield return new WaitForSeconds(period);
            }

            m_IsImmortal = false;
        }
    }
}
