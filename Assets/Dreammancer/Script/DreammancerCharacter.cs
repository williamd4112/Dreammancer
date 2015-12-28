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

        private bool m_IsDash = false;
        private float m_OriginGravityScale;

        private Collider2D m_Collider;
        private PlatformerCharacter2D m_Character;
        private Rigidbody2D m_Rigidbody;
        private Animator m_Animator;
        private CarryableObject m_CarryableObject;
        private CharacterLightArea m_LightArea;
        private DashControl m_DashControl;
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
            m_DashControl = GetComponent<DashControl>();
            m_Health = GetComponent<Health>();
            m_Health.RegisterHealthChangeEvent(OnHealthChange);

            m_DamageHandlers = new Dictionary<Damage.DamageType, DamageHandler>();
            foreach (DamageHandler handler in GetComponents<DamageHandler>())
                m_DamageHandlers[handler.Type] = handler;

            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Hidden"), true);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Default"), LayerMask.NameToLayer("Hidden"), true);
            //Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Hidden"), LayerMask.NameToLayer("Hidden"), true);

            m_OriginGravityScale = m_Rigidbody.gravityScale;
            StartCoroutine(Recharge(m_DashChargeRate));
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            m_Character.BaseVelocity = m_CarryableObject.CarrierVelocity;

            if (Input.GetKeyDown(KeyCode.E) || 
                CrossPlatformInputManager.GetAxis("Mouse Y") < 0.01f 
                && CrossPlatformInputManager.GetAxis("Mouse X") > 0.8f && !m_IsDash && m_DashEnergy > 0)
            {
                m_IsDash = true;
                m_DashControl.ResetColor(m_LightArea.LightArea.LightColor);
                
                AudioSource.PlayClipAtPoint(m_DashSound, transform.position);
                StartCoroutine(CountDown(m_DashUnitTime * m_DashEnergy));
                m_DashEnergy = 0;
            }

            if(m_IsDash)
            {
                m_Character.BaseVelocity += new Vector2((m_Character.FacingRight) ? m_DashForce : -m_DashForce, 0);
                m_Rigidbody.gravityScale = 0;
                m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x, 0);
                //m_LightArea.LightArea.tag = "Laser";
            }
            else
            {
                m_Rigidbody.gravityScale = m_OriginGravityScale;
                //m_LightArea.LightArea.tag = "Untagged";
            }

            m_DashControl.UpdateDashLaser(m_IsDash, m_LightArea.LightArea.LightColor);
            m_Animator.SetBool("Dash", m_IsDash);
        }

        public void OnHealthChange(int hp)
        {
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

