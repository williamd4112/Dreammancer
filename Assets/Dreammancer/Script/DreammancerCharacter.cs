using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets._2D;
using UnityStandardAssets.CrossPlatformInput;
using System;

namespace Dreammancer
{
    public class DreammancerCharacter : MonoBehaviour, Trappable
    {
        const int k_MaxDashEnergy = 100;

        [SerializeField]
        private float m_DashForce = 800.0f;
        [SerializeField]
        private float m_DashUnitTime = 0.01f;
        [SerializeField]
        private float m_DashChargeRate = 0.1f;
        [SerializeField]
        private int m_DashEnergy = 0;
        public int DashEnergy
        {
            get { return m_DashEnergy; }
        }

        [SerializeField]
        private AudioClip m_DashSound;

        [SerializeField]
        private GameObject m_DashLaserTemplate;
        private GameObject m_DashLaserInstance = null;
        private bool m_IsDash = false;

        private Collider2D m_Collider;
        private PlatformerCharacter2D m_Character;
        private Rigidbody2D m_Rigidbody;
        private Animator m_Animator;
        private CarryableObject m_CarryableObject;
        private CharacterLightArea m_LightArea;
        private Health m_Health;
        public Health Health
        {
            get { return m_Health; }
        }
  
        private Dictionary<Damage.DamageType, DamageHandler> m_DamageHandlers;
        
        public void increaseEnergy(int v)
        {
            m_DashEnergy = Mathf.Clamp(m_DashEnergy + v, 0, k_MaxDashEnergy);
        }

        // Use this for initialization
        void Start()
        {
            m_Collider = GetComponent<Collider2D>();
            m_Rigidbody = GetComponent<Rigidbody2D>();
            m_Animator = GetComponent<Animator>();
            m_Character = GetComponent<PlatformerCharacter2D>();
            m_CarryableObject = GetComponent<CarryableObject>();
            m_LightArea = GetComponent<CharacterLightArea>();
            m_Health = GetComponent<Health>();
            m_Health.RegisterHealthChangeEvent(OnHealthChange);

            m_DamageHandlers = new Dictionary<Damage.DamageType, DamageHandler>();
            foreach (DamageHandler handler in GetComponents<DamageHandler>())
                m_DamageHandlers[handler.Type] = handler;

            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Hidden"), true);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Default"), LayerMask.NameToLayer("Hidden"), true);
            //Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Hidden"), LayerMask.NameToLayer("Hidden"), true);

            StartCoroutine(Recharge(m_DashChargeRate));
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            m_Character.BaseVelocity = m_CarryableObject.CarrierVelocity;
            
            if(Input.GetKeyDown(KeyCode.E) && !m_IsDash && m_DashEnergy > 0)
            {
                m_IsDash = true;
                if(m_DashLaserInstance == null)
                {
                    m_DashLaserInstance = Instantiate(m_DashLaserTemplate, transform.position, m_DashLaserTemplate.transform.rotation) as GameObject;
                }

                m_DashLaserInstance.GetComponent<Follow>().FollowPos = transform;
                m_DashLaserInstance.GetComponent<LightFlipFollow>().Target = transform;
                m_DashLaserInstance.GetComponent<Light2D>().LightBeamRange = 0;
                m_DashLaserInstance.GetComponent<Light2D>().LightColor = m_LightArea.LightArea.LightColor;
                m_DashLaserInstance.GetComponent<LightTrail>().ResetDiff();
                
                AudioSource.PlayClipAtPoint(m_DashSound, transform.position);
                StartCoroutine(CountDown(m_DashUnitTime * m_DashEnergy));
                m_DashEnergy = 0;
            }

            if(m_IsDash)
            {
                m_Character.BaseVelocity += new Vector2((m_Character.FacingRight) ? m_DashForce : -m_DashForce, 0);
                m_Rigidbody.gravityScale = 0;
                m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x, 0);
                m_LightArea.SetColorEnergy(1.0f);
            }
            else
            {
                m_Rigidbody.gravityScale = 3;
                m_LightArea.SetColorEnergy(0.5f);
            }

            if (m_DashLaserInstance != null)
            {
                m_DashLaserInstance.SetActive(m_IsDash);
                m_DashLaserInstance.GetComponent<Light2D>().LightColor = m_LightArea.LightArea.LightColor;
            }
            m_Animator.SetBool("Dash", m_IsDash);
        }

        public void OnHealthChange(int hp)
        {
            Debug.Log("HP : " + hp);
        }

        public void OnTrapEnter(Trap trap)
        {       
            if (m_DamageHandlers.ContainsKey(trap.damage.Type))
            {
                m_DamageHandlers[trap.damage.Type].OnDamageTrigger(trap.damage);
            }
            else
            {
                Debug.Log("Unhandled Damage Type: " + trap.damage.Type);
            }
        }

        public void OnTrapStay(Trap trap)
        {
           
        }

        public void OnTrapExit(Trap trap)
        {
            
        }

        public bool GetDashInput()
        {
            return true;
        }

        IEnumerator CountDown(float t)
        {
            yield return new WaitForSeconds(t);
            m_IsDash = false;
        }

        IEnumerator Recharge(float t)
        {
            yield return new WaitForSeconds(t);
            increaseEnergy(1);
            StartCoroutine(Recharge(t));
        }

    }
}

