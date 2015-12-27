using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(MonsterCharacter))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class SlimeMonsterControl : MonoBehaviour
    {
        [SerializeField]
        private Vector3 m_DetectRadius = new Vector3(20.0f, 6.0f, 0.0f);
        [SerializeField]
        private Color errorLight;

        private MonsterCharacter m_MonsterCharacter;
        private SpriteRenderer m_SpriteRenderer;
        private Color m_OriginColor;
        private Transform m_Target;

        // Use this for initialization
        void Start()
        {
            m_MonsterCharacter = GetComponent<MonsterCharacter>();
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_OriginColor = m_SpriteRenderer.color;
            m_Target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            int dir = transform.position.x - m_Target.position.x > 0 ? -1 : 1;
            float acc = (isCrazy()) ? 2.0f : 1.0f;
            if (isInRange())
            {
                m_MonsterCharacter.Move(dir * acc, false);
                Debug.Log(acc);
            }
        }

        private bool isInRange()
        {
            if(Mathf.Abs(transform.position.x - m_Target.position.x) < m_DetectRadius.x && Mathf.Abs(transform.position.y - m_Target.position.y) < m_DetectRadius.y)
            {
                return true;
            }
            
            return false;
            //return Vector3.Distance(transform.position, m_Target.position) < m_DetectRadius;
        }

        private bool isCrazy()
        {
            if (ColorUtil.colorSubRGB(m_OriginColor, errorLight) == m_SpriteRenderer.color)
            {
                return true;
            }
            return false;
        }
    }

}
