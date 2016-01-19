using UnityEngine;
using System.Collections;
using System;

namespace Dreammancer
{
    public delegate void DestroyEvent();

    [RequireComponent(typeof(Health))]
    public class Damageable : MonoBehaviour, CallbackObject
    {

		public LevelManager levelManager;

        [SerializeField]
        private AudioClip m_HitSound;
        [SerializeField]
        private AudioClip m_DestroySound;
        [SerializeField]
        private GameObject m_HitAnim;
        private GameObject m_HitAnimInstance = null;
        [SerializeField]
        private GameObject m_DestroyAnim;
        private GameObject m_DestroyAnimInstance = null;

        [SerializeField]
        private int m_HitDelayMax = 10;
        private int m_HitDelay;

        private Health m_Health;
        private DestroyEvent m_DestroyEvents;
		private Transform spawnPoint;

        public void RegisterDestroyEvent(DestroyEvent e)
        {
            m_DestroyEvents += e;
        }

        // Use this for initialization
        void Start()
        {
            m_Health = GetComponent<Health>();
            m_Health.RegisterHealthEvent(OnHealthChange);

            m_HitDelay = m_HitDelayMax;

			levelManager = FindObjectOfType<LevelManager> ();
        }

        void OnHealthChange(int hp, int diff)
        {
            if(m_HitDelay <= 0 && diff < 0)
            {
                if (hp > 0)
                {
                    if(m_HitAnimInstance == null)
                    {
                        m_HitAnimInstance = GameObject.Instantiate(m_HitAnim, transform.position, transform.rotation) as GameObject;

                        DestroySelf destroy = m_HitAnimInstance.GetComponent<DestroySelf>();
                        if (m_HitAnimInstance.GetComponent<DestroySelf>() != null)
                        {
                            destroy.AddCallback(this);
                        }

                        AudioSource.PlayClipAtPoint(m_HitSound, transform.position);
                    }
                }
                else
                {   
                    if(m_DestroyAnimInstance == null)
                    {
                        m_DestroyAnimInstance = GameObject.Instantiate(m_DestroyAnim, transform.position, transform.rotation) as GameObject;

                        DestroySelf destroy = m_DestroyAnimInstance.GetComponent<DestroySelf>();
                        if (m_DestroyAnimInstance.GetComponent<DestroySelf>() != null)
                        {
                            destroy.AddCallback(this);
                        }

                        AudioSource.PlayClipAtPoint(m_DestroySound, transform.position);
                        if (m_DestroyEvents != null)
                        {
                            m_DestroyEvents.Invoke();
                        }
                    }
                    
                    if(CompareTag("Player")){
						LevelManager.Instance.KillPlayer();
					}
                    else{
                        Destroy(gameObject);
					}
                }
                m_HitDelay = m_HitDelayMax;
            }
            else
            {
                m_HitDelay--;
            }
        }

        public void Callback(GameObject obj)
        {
            if (obj.Equals(m_DestroyAnimInstance))
            {
                m_DestroyAnimInstance = null;
                Debug.Log("Clear instance");
            }
            if (obj.Equals(m_HitAnimInstance))
                m_HitAnimInstance = null;
        }
    }
}
