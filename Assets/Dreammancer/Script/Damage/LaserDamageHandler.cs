using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(Light2DEventListener))]
    public class LaserDamageHandler : MonoBehaviour
    {
        [SerializeField]
        private int m_DamageAmount = 10;
        [SerializeField]
        private Color m_DamageColor = Color.black;

        private Health m_Health;
        private Light2DEventListener m_LightEventListener;
        private SpriteRenderer m_Renderer;
        

        // Use this for initialization
        void Start()
        {
            m_Health = GetComponent<Health>();
            m_LightEventListener = GetComponent<Light2DEventListener>();
            m_LightEventListener.RegisterLaserEvent(OnLaserDamage);
            m_Renderer = GetComponent<SpriteRenderer>();
            
        }

        public void OnLaserDamage(Light2D l, GameObject g)
        {
           if (ColorUtil.colorCompareQuantRGB(l.LightColor, m_DamageColor, 127))
                m_Health.decreaseHealth(m_DamageAmount);
        }


    }
}
