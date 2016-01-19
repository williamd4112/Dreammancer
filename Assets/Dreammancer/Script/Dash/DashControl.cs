using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Health))]
    public class DashControl : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_DashLaser;
        [SerializeField]
        private GameObject m_Head;

        private Light2D m_Laser;
        private Light2D m_HeadLaser;
        private Follow m_Follow;
        private LightFlipFollow m_Flipfollow;
        private LightTrail m_Trail;
        private Health m_Health;
        private bool m_LastImmortalFlag = false;

        // Use this for initialization
        void Start()
        {
            m_Laser = m_DashLaser.GetComponent<Light2D>();
            m_HeadLaser = m_Head.GetComponent<Light2D>();
            m_Follow = m_DashLaser.GetComponent<Follow>();
            m_Flipfollow = m_DashLaser.GetComponent<LightFlipFollow>();
            m_Trail = m_DashLaser.GetComponent<LightTrail>();
            m_Health = GetComponent<Health>();
        }

        public void ResetColor(Color c)
        {
            m_Follow.FollowPos = transform;
            m_Flipfollow.Target = transform;
            m_Laser.transform.position = transform.position;
            m_Laser.LightBeamRange = 0;
            m_Laser.LightColor = c;
            m_HeadLaser.LightColor = c;
            m_Trail.ResetDiff();
        }

        public void UpdateDashLaser(bool e, Color c)
        {
            m_DashLaser.SetActive(e);
            m_Laser.LightColor = c;
            m_HeadLaser.LightColor = c;

            if (!m_LastImmortalFlag && e)
            {
                m_Health.EnterImmortal();
            }
                
            m_LastImmortalFlag = e;
        }
    }
}
