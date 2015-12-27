using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class CharacterLightArea : MonoBehaviour
    {
        [SerializeField]
        private Light2D m_LightArea;
        public Light2D LightArea
        {
            get { return m_LightArea; }
        }

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void LateUpdate()
        {
            m_LightArea.transform.position = transform.position;
        }

        public void SwitchLightColor(Color c)
        {
            m_LightArea.LightColor = c;
        }

        public void SetColorEnergy(float a)
        {
            Color c = m_LightArea.LightColor;
            c.a = a;
            m_LightArea.LightColor = c;
        }
    }
}

