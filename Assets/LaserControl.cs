using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Light2D))]
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

        private Light2D m_Laser;

        private bool m_Enable = false;

        // Use this for initialization
        void Start()
        {
            m_Laser = GetComponent<Light2D>();
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

        void EnableLaser()
        {
            AudioSource.PlayClipAtPoint(m_ShootSound, transform.position);
            m_Enable = true;
        }

        void DisbleLaser()
        {
            m_Enable = false;
        }
    }
}
