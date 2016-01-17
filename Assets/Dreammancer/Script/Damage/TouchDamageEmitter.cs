using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Collider2D))]
    public class TouchDamageEmitter : MonoBehaviour
    {
        [SerializeField]
        private string[] m_DamageTags;

        [SerializeField]
        private GameObject m_TouchEffect;
        [SerializeField]
        private AudioClip m_TouchSound;

        [SerializeField]
        private int m_DamageAmount;
        [SerializeField]
        private bool m_SelfDestroy = false;

        private GameObject m_EffectInstance = null;

        void OnCollisionEnter2D(Collision2D other)
        {
            CheckDamage(other.gameObject);
        }

        void OnCollisionStay2D(Collision2D other)
        {
            CheckDamage(other.gameObject);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            CheckDamage(other.gameObject);
        }

        void OnTriggerStay2D(Collider2D other)
        {
            CheckDamage(other.gameObject);
        }

        void CheckDamage(GameObject other)
        {
            Health health = other.gameObject.GetComponent<Health>();
            if (health != null)
            {
               
                foreach (string tag in m_DamageTags)
                {
                    if (other.gameObject.CompareTag(tag))
                    {
                        health.decreaseHealth(m_DamageAmount);
                        ShowEffect();
                    }
                }
            }

            
            if (m_SelfDestroy)
            {
				Debug.Log(other);
                ShowEffect();
                Destroy(gameObject);
            }

        }

        void ShowEffect()
        {
			if (m_TouchEffect != null) {
				m_EffectInstance = GameObject.Instantiate (m_TouchEffect, transform.position, transform.rotation) as GameObject;
			}
            if (m_TouchSound != null)
                AudioSource.PlayClipAtPoint(m_TouchSound, transform.position);

        }
    }
}
