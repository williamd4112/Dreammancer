﻿using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public delegate void DestroyEvent();

    [RequireComponent(typeof(Health))]
    public class Damageable : MonoBehaviour
    {

		public LevelManager levelManager;

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

        // Update is called once per frame
        void Update()
        {

        }

        void OnHealthChange(int hp, int diff)
        {
            if(m_HitDelay <= 0 && diff < 0)
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
                    if (m_DestroyEvents != null)
                    {
                        Debug.Log("Drop!");
                        m_DestroyEvents.Invoke();
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
    }
}
