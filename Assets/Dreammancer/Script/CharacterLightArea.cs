using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class CharacterLightArea : MonoBehaviour
    {
        [SerializeField]
        private Light2D m_LightArea;

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
    }
}

