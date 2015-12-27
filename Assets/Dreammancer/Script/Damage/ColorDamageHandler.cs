using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(ColorReactor))]
    [RequireComponent(typeof(Health))]
    public class ColorDamageHandler : MonoBehaviour
    {
        [SerializeField]
        private Color m_OnDamageColor;

        [SerializeField]
        private int m_DamageAmount = 10;

        private ColorReactor m_ColorReactor;
        private Health m_Health;

        // Use this for initialization
        void Start()
        {
            m_ColorReactor = GetComponent<ColorReactor>();
            m_Health = GetComponent<Health>();

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
