using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(MonsterCharacter))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class BullMonsterControl : MonoBehaviour
    {

        [SerializeField]
        private Vector3 m_DetectRadius = new Vector3(20.0f, 6.0f, 0.0f);

        [SerializeField]
        private Vector3 m_DetectJumpRadius = new Vector3(5.0f, 3.0f, 0.0f);
        private MonsterCharacter m_MonsterCharacter;   
        private Transform m_Target;

        // Use this for initialization
        void Start()
        {
            m_MonsterCharacter = GetComponent<MonsterCharacter>();           
            m_Target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            int dir = transform.position.x - m_Target.position.x > 0 ? -1 : 1;
            float acc = 1.0f;
            if (isInRange())
            {
                if (isInJumpRange()) {
                    m_MonsterCharacter.Move(dir * acc, true);
                }
                else
                {
                    m_MonsterCharacter.Move(dir * acc, false);
                }
            }
        }

        private bool isInRange()
        {
            if (Mathf.Abs(transform.position.x - m_Target.position.x) < m_DetectRadius.x && Mathf.Abs(transform.position.y - m_Target.position.y) < m_DetectRadius.y)
            {
                return true;
            }

            return false;
            //return Vector3.Distance(transform.position, m_Target.position) < m_DetectRadius;
        }        

        private bool isInJumpRange()
        {
            if (Mathf.Abs(transform.position.x - m_Target.position.x) < m_DetectJumpRadius.x && Mathf.Abs(transform.position.y - m_Target.position.y) > m_DetectJumpRadius.y)
            {
                return true;
            }
            return false;
        }
    }
}
