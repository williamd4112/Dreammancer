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
        [SerializeField]
        private float start_dir;
        private float dir;
        // Use this for initialization
        void Start()
        {
            dir = start_dir;
            m_MonsterCharacter = GetComponent<MonsterCharacter>();
            m_Target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //int dir = transform.position.x - m_Target.position.x > 0 ? -1 : 1;
            float acc = 1.0f;
            m_MonsterCharacter.Fly(dir * acc);

        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            dir = dir * -1;
        }
    }

}
