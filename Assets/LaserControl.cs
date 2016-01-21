using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Light2D))]
    [RequireComponent(typeof(AudioSource))]
    public class LaserControl : MonoBehaviour
    {
        [SerializeField]
        private float m_LaserRange = 10.0f;
        [SerializeField]
        private float m_ChargeRate = 1.2f;
        [SerializeField]
        private AudioClip m_ShootSound;
        [SerializeField]
        private AudioClip m_KeepShootSound;
        [SerializeField]
        private AudioSource m_Source;

        private Light2D m_Laser;

        private bool m_Enable = false;

        // Use this for initialization
        void Start()
        {
            m_Laser = GetComponent<Light2D>();
            m_Source = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            if(m_Enable)
            {
                m_Laser.LightBeamRange = Mathf.Lerp(m_Laser.LightBeamRange, m_LaserRange, Time.deltaTime);
            }
            else
            {
                m_Laser.LightBeamRange = 0;
            }
        }

        public void EnableLaser()
        {
            AudioSource.PlayClipAtPoint(m_ShootSound, transform.position);
            m_Enable = true;
            m_Source.mute = false;
        }

        public void DisbleLaser()
        {
            m_Enable = false;
            m_Source.mute = true;
        }
    }
}
