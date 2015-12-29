using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class UFOMonsterControl : MonoBehaviour
    {
        [SerializeField]
        private Vector3 m_DetectRadius = new Vector3(20.0f, 0.0f, 0.0f);
		private PlatformerUFO2D m_PlatformerUFO2D;
        private Transform m_Target;        
        
        private Vector3 DisToTarget;        
        // Use this for initialization
        void Start()
        {
            //startFly = false;
			m_PlatformerUFO2D = GetComponent<PlatformerUFO2D>();

            //m_MonsterCharacter = GetComponent<MonsterCharacter>();
            m_Target = GameObject.FindGameObjectWithTag("Player").transform;
           
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Vector2 dir = (m_Target.position - transform.position).normalized;

			float acc = 1.0f;
            if (isInRange())
            {
				//m_PlatformerUFO2D.drift(dir.x * acc, dir.y * acc);
				m_PlatformerUFO2D.drift(dir.x, m_Target);
			}
        }
        private bool isInRange()
        {
            if (Mathf.Abs(transform.position.x - m_Target.position.x) < m_DetectRadius.x)
            {
                return true;
            }

            return false;
            //return Vector3.Distance(transform.position, m_Target.position) < m_DetectRadius;
        }

    }

}
