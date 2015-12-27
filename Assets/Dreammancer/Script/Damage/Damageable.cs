using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Health))]
    public class Damageable : MonoBehaviour
    {
        [SerializeField]
        private AudioClip m_HitSound;
        [SerializeField]
        private AudioClip m_DestroySound;
        [SerializeField]
        private GameObject m_HitAnim;
        [SerializeField]
        private GameObject m_DestroyAnim;

        [SerializeField]
        private int m_HitDelayMax = 10;
        private int m_HitDelay;

        private Health m_Health;

        // Use this for initialization
        void Start()
        {
            m_Health = GetComponent<Health>();
            m_Health.RegisterHealthChangeEvent(OnHealthChange);

            m_HitDelay = m_HitDelayMax;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnHealthChange(int hp)
        {
            if(m_HitDelay <= 0)
            {
                if (hp > 0)
                {
                    GameObject.Instantiate(m_HitAnim, transform.position, transform.rotation);
                    AudioSource.PlayClipAtPoint(m_HitSound, transform.position);
                }
                else
                {
                    GameObject.Instantiate(m_DestroyAnim, transform.position, transform.rotation);
                    AudioSource.PlayClipAtPoint(m_DestroySound, transform.position);
                    Destroy(gameObject);
                }
                m_HitDelay = m_HitDelayMax;
            }
            else
            {
                m_HitDelay--;
            }
        }
    }
}
