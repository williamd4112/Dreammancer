using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class ShootDamageEmitter : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_BulletTemplate;

        [SerializeField]
        private Color[] m_PossiableColor = { Color.white };

        [SerializeField]
		private float m_ShootDirection = 1.0f;
        [SerializeField]
        private float m_Speed = 1.0f;
        [SerializeField]
        private float m_CooldownTime = 0.5f;

        [SerializeField]
        private bool m_FixedColor = false;

        private bool m_Ready = true;
        private int m_ColorIndex = 0;
        
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (transform.parent.transform.localScale.x < 0)
            {
                transform.RotateAround(transform.parent.transform.position, Vector2.right, 180.0f);
                m_ShootDirection *= -1.0f;
            }

            if (m_Ready)
            {
                GameObject obj = GameObject.Instantiate(m_BulletTemplate, transform.position, transform.rotation) as GameObject;
				Vector3 s = obj.transform.localScale;
				s.x = transform.parent.transform.localScale.x ;
				obj.transform.localScale = s;
				m_ShootDirection = (s.x < 0) ? 1.0f : -1.0f;

                SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
                if(renderer != null)
                {
                    renderer.color = m_PossiableColor[m_ColorIndex];
                    m_ColorIndex = (m_ColorIndex + 1) % m_PossiableColor.Length;
                }

                Rigidbody2D rigid = obj.GetComponent<Rigidbody2D>();
				rigid.velocity = m_Speed * transform.right * m_ShootDirection;
                StartCoroutine(Cooldown(m_CooldownTime));

                m_Ready = false;
            }

        }

        IEnumerator Cooldown(float t)
        {
            yield return new WaitForSeconds(t);
            m_Ready = true;
        }
    }

}