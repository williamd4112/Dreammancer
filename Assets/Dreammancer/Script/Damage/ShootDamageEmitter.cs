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
        private Vector2 m_Direction = Vector2.right;
        [SerializeField]
		private float m_ShootDirection = 1.0f;
        [SerializeField]
        private float m_Speed = 1.0f;
        [SerializeField]
        private float m_CooldownTime = 0.5f;
        [SerializeField]
        private bool m_FollowFlip = true;

        [SerializeField]
        private bool m_FixedColor = false;
        [SerializeField]
        private float m_DetectDistance = 5.0f;

        private bool m_Ready = true;
        private int m_ColorIndex = 0;
        private GameObject player;

        
        // Use this for initialization
        void Start()
        {
            player = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {
            if (Vector3.Distance(player.transform.position, transform.position) > m_DetectDistance)
                return;

            if (transform.parent.transform.localScale.x < 0 && m_FollowFlip)
            {
                transform.RotateAround(transform.parent.transform.position, m_Direction, 180.0f);
                m_ShootDirection *= -1.0f;
            }

            if (m_Ready)
            {
                GameObject obj = GameObject.Instantiate(m_BulletTemplate, transform.position, transform.rotation) as GameObject;
				Vector3 s = obj.transform.localScale;
				s.x = transform.parent.transform.localScale.x ;
				obj.transform.localScale = s;
				m_ShootDirection = (s.x < 0 && m_FollowFlip) ? 1.0f : -1.0f;

                SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
                if(renderer != null)
                {
                    renderer.color = m_PossiableColor[m_ColorIndex];
                    m_ColorIndex = (m_ColorIndex + 1) % m_PossiableColor.Length;
                }

                Rigidbody2D rigid = obj.GetComponent<Rigidbody2D>();
				rigid.velocity = m_Speed * m_Direction * m_ShootDirection;
                StartCoroutine(Cooldown(m_CooldownTime));

                m_Ready = false;
            }

        }

        public void SetShootingRate(float rate)
        {
            m_Speed = rate;
        }

        IEnumerator Cooldown(float t)
        {
            yield return new WaitForSeconds(t);
            m_Ready = true;
        }
    }

}