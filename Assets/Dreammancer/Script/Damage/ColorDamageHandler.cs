using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(ColorReactor))]
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(Light2DEventListener))]
    public class ColorDamageHandler : MonoBehaviour
    {
        [SerializeField]
        private float m_DamageEnergyThreshold = 1.0f;

        [SerializeField]
        private Color m_OnDamageColor;

        [SerializeField]
        private int m_DamageAmount = 10;

        private ColorReactor m_ColorReactor;
        private Health m_Health;
        private Light2DEventListener m_LightEventListener;

        // Use this for initialization
        void Start()
        {
            m_ColorReactor = GetComponent<ColorReactor>();
            m_Health = GetComponent<Health>();
            m_LightEventListener = GetComponent<Light2DEventListener>();

            m_ColorReactor.RegistetColorEvent(OnColorDamage, m_OnDamageColor);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnColorDamage()
        {
            m_Health.decreaseHealth(m_DamageAmount);
        }

        
    }
}
