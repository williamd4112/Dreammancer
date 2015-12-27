using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(MonsterCharacter))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class SlimeMonsterControl : MonoBehaviour
    {
        [SerializeField]
        private float m_DetectRadius = 5.0f;

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
            m_MonsterCharacter.Move(dir * acc, false);
        }

        private bool isInRange()
        {
            return Vector3.Distance(transform.position, m_Target.position) < m_DetectRadius;
        }

        private bool isCrazy()
        {
            if(!ColorUtil.colorCompareRGB(m_SpriteRenderer.color, m_OriginColor))
            {
                return true;
            }
            return false;
        }
    }

}