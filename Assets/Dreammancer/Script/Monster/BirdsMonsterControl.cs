using UnityEngine;
using System.Collections;

namespace Dreammancer
{    
    public class BirdsMonsterControl : MonoBehaviour
    {
        [SerializeField]
        private Vector3 m_DetectRadius = new Vector3(20.0f, 0.0f, 0.0f);
        private MonsterCharacter[] m_MonsterCharacters;
        private Transform m_Target;
        private BoxCollider2D m_BoxCollider;
        private bool startFly;
        private Vector3 DisToTarget;
       
        [SerializeField]
        private float speed;
        // Use this for initialization
        void Start()
        {
            startFly = false;
            m_MonsterCharacters = GetComponentsInChildren<MonsterCharacter>();
            
            //m_MonsterCharacter = GetComponent<MonsterCharacter>();
            m_Target = GameObject.FindGameObjectWithTag("Player").transform;
            m_BoxCollider = GetComponent<BoxCollider2D>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Vector2 dir = (m_Target.position - transform.position).normalized;
                 
            if (isInRange() && !startFly)
            {
                
                DisToTarget = m_Target.position - transform.position;
                foreach (MonsterCharacter m_MonsterCharacter in m_MonsterCharacters) { 
                    m_MonsterCharacter.aimFly(dir.x * speed, dir.y * speed);
                }
                Destroy(gameObject, 5);
                startFly = true;
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
