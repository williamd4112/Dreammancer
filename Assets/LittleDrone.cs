using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class LittleDrone : MonoBehaviour
    {
        [SerializeField]
        private LaserControl m_LaserControl;

        [SerializeField]
        private GameObject m_Target;
        public GameObject Target
        {
            get { return m_Target; }
            set { m_Target = value; }
        }

        [SerializeField]
        private float m_DetectRadius = 4.0f;

        private bool m_PlayerInRange = false;

        // Use this for initialization
        void Start()
        {
            if (m_Target == null)
                m_Target = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {
            float dis = Vector3.Distance(m_Target.transform.position, transform.position);
            if(dis < m_DetectRadius)
            {
                if(!m_PlayerInRange)
                    m_LaserControl.EnableLaser();
                m_PlayerInRange = true;
            }
            else
            {
                m_LaserControl.DisbleLaser();
                m_PlayerInRange = false;
            }
        }
    }
}
