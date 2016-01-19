using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(MonsterCharacter))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class DragonMonsterControl : MonoBehaviour
    {
        private MonsterCharacter m_MonsterCharacter;
        private Transform m_Target;
        private BoxCollider2D m_BoxCollider;
        [SerializeField]
        private float start_dir;
        private float dir;

        // Use this for initialization
        void Start()
        {
            dir = start_dir;
            m_MonsterCharacter = GetComponent<MonsterCharacter>();
            m_Target = GameObject.FindGameObjectWithTag("Player").transform;
            m_BoxCollider = GetComponent<BoxCollider2D>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            float acc = 1.0f;
            m_MonsterCharacter.Fly(dir * acc);
        }

    }

}
