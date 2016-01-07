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
        private Vector3 m_ShootDirection = Vector3.left;
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
                if (transform.parent.transform.localScale.x < 0)
                {
                    Vector3 s = obj.transform.localScale;
                    s.x = -1.0f;
                    obj.transform.localScale = s;
                }

                SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
                if(renderer != null)
                {
                    renderer.color = m_PossiableColor[m_ColorIndex];
                    m_ColorIndex = (m_ColorIndex + 1) % m_PossiableColor.Length;
                }

                Rigidbody2D rigid = obj.GetComponent<Rigidbody2D>();

                rigid.velocity = m_Speed * m_ShootDirection;
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