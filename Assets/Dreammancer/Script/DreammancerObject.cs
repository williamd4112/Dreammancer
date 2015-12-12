using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Light2DEventListener))]
    public class DreammancerObject : MonoBehaviour
    {
        private Light2DEventListener m_LightListener;

        void Start()
        {
            m_LightListener = GetComponent<Light2DEventListener>();
        }

        void Update()
        {
            
        }

    }
}

