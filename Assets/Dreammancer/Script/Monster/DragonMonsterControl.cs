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
            //int dir = transform.position.x - m_Target.position.x > 0 ? -1 : 1;
            float acc = 1.0f;
            m_MonsterCharacter.Fly(dir * acc);
            //Debug.Log(m_BoxCollider.size);
        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            Rigidbody2D rigidbody;     
            ContactPoint2D contact = collision.contacts[0];
            if ((rigidbody = collision.gameObject.GetComponent<Rigidbody2D>()) != null)
            {
                if (rigidbody.velocity.y != 0.0f) {
                    return;
                }  
            }
            Debug.Log(contact.point);
            //Debug.Log(Mathf.Abs(contact.point.y - transform.position.y));
            //Debug.Log(m_BoxCollider.size.y / 2);

            if (Mathf.Abs(contact.point.y - transform.position.y) < (m_BoxCollider.size.y / 2))
            {
                dir = dir * -1;
            }
        }
    }

}
