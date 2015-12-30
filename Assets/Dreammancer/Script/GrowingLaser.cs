using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Light2D))]
    public class GrowingLaser : MonoBehaviour
    {
        [SerializeField]
        private float m_GrowingSpeed = 1.5f;

        private Light2D m_Light2D;
        [SerializeField]
        private float m_TargetRadius = 20.0f;

        // Use this for initialization
        void Start()
        {
            m_Light2D = GetComponent<Light2D>();
        }

        // Update is called once per frame
        void Update()
        {
            m_Light2D.LightBeamRange = Mathf.Lerp(m_Light2D.LightBeamRange, m_TargetRadius, Time.deltaTime * m_GrowingSpeed);
        }
    }

}