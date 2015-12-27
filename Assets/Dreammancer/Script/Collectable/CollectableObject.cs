using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public enum CollectableType
    {
        SMALL_ENERGY,
        SMALL_LIFE
    }

    [RequireComponent(typeof(Collider2D))]
    public class CollectableObject : MonoBehaviour
    {
        [SerializeField]
        private CollectableType m_Type;
        public CollectableType Type
        {
            get { return m_Type; }
        }

        [SerializeField]
        private AudioClip m_OnCollectedSound;
        [SerializeField]
        private GameObject m_OnCollectedAnimation;
        [SerializeField]
        private bool m_IsRecollcectable = false;
        [SerializeField]
        private float m_RecoverTime = 1.0f;
        private bool timeToReset = false;

        void Update()
        {
            if(timeToReset)
            {
                ResetAllTo(true);
                timeToReset = false;
            }
        }

        void PlaySound()
        {
            AudioSource.PlayClipAtPoint(m_OnCollectedSound, transform.position);
        }

        void PlayAnimation()
        {
            if (m_OnCollectedAnimation != null)
                GameObject.Instantiate(m_OnCollectedAnimation, transform.position, transform.rotation);
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.CompareTag("Player"))
            {
                PlaySound();
                PlayAnimation();
                if(!m_IsRecollcectable)
                {
                    Destroy(gameObject);
                }
                else
                {
                    StartCoroutine(CountDown(m_RecoverTime));
                    ResetAllTo(false);
                } 
            }
        }

        void ResetAllTo(bool b)
        {
            GetComponent<SpriteRenderer>().enabled = b;
            GetComponent<Collider2D>().enabled = b;
        }

        IEnumerator CountDown(float t)
        {
            yield return new WaitForSeconds(t);
            timeToReset = true;
        }
    }
}
