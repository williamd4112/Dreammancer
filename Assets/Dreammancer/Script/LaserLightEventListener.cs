using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Health))]
    public class LaserLightEventListener : MonoBehaviour
    {
        [SerializeField]
        private Color m_DamageColor;
        [SerializeField]
        private int m_DamageAmount = 10;

        private int id;
        private Health m_Health;

        // Use this for initialization
        void Start()
        {
            id = gameObject.GetInstanceID();
            m_Health = GetComponent<Health>();
        
            Light2D.RegisterEventListener(LightEventListenerType.OnStay, OnLightStay);
            Light2D.RegisterEventListener(LightEventListenerType.OnEnter, OnLightEnter);
            Light2D.RegisterEventListener(LightEventListenerType.OnExit, OnLightExit);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnLightEnter(Light2D l, GameObject g)
        {
            if (g.GetInstanceID() == id && l.CompareTag("Laser"))
            {
                if (ColorUtil.colorCompareQuantRGB(l.LightColor, m_DamageColor, 127))
                    m_Health.decreaseHealth(m_DamageAmount);
            }
        }

        void OnLightStay(Light2D l, GameObject g)
        {
            if (g.GetInstanceID() == id && l.CompareTag("Laser"))
            {
                if(ColorUtil.colorCompareQuantRGB(l.LightColor, m_DamageColor, 127))
                {
                    m_Health.decreaseHealth(m_DamageAmount);
                }
                    
            }
        }

        void OnLightExit(Light2D l, GameObject g)
        {
            if (g.GetInstanceID() == id)
            {

            }
        }

		public void ChangeDamageColor(Color newColor)
		{
			m_DamageColor = newColor;
		}
    }
}
