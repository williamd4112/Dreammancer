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
        private Coroutine m_CountdownRoutine;

        [SerializeField]
        private AudioClip m_DashSound;
        [SerializeField]
        private GameObject m_DashEffect;

        [SerializeField]
        private float m_DamageBackoffForce = 3.0f;
        [SerializeField]
        private float m_RecoverFromDamageSpeed = 2.0f;
        [SerializeField]
        private int m_DamageAmountHitByWhite = 10;

        private bool m_IsDash = false;
        private float m_OriginGravityScale;


        private int id;
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

        private Vector2 m_AdditionalVelocity = Vector2.zero;
  
        private Dictionary<Damage.DamageType, DamageHandler> m_DamageHandlers;
        
        public void increaseEnergy(int v)
        {
            m_DashEnergy = Mathf.Clamp(m_DashEnergy + v, 0, k_MaxDashEnergy);
        }

		public bool IsDead{ get; private set;}

        // Use this for initialization
        void Start()
        {
            id = gameObject.GetInstanceID();
            m_Collider = GetComponent<Collider2D>();
            m_Rigidbody = GetComponent<Rigidbody2D>();
            m_Animator = GetComponent<Animator>();
            m_Character = GetComponent<PlatformerCharacter2D>();
            m_CarryableObject = GetComponent<CarryableObject>();
            m_LightArea = GetComponent<CharacterLightArea>();
            m_DashControl = GetComponent<DashControl>();
            m_Health = GetComponent<Health>();
            m_Health.RegisterHealthEvent(OnHeathChange);

            m_DamageHandlers = new Dictionary<Damage.DamageType, DamageHandler>();
            foreach (DamageHandler handler in GetComponents<DamageHandler>())
                m_DamageHandlers[handler.Type] = handler;

            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Hidden"), true);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Default"), LayerMask.NameToLayer("Hidden"), true);
            //Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Hidden"), LayerMask.NameToLayer("Hidden"), true);

            Light2D.RegisterEventListener(LightEventListenerType.OnStay, OnLightStay);
            Light2D.RegisterEventListener(LightEventListenerType.OnEnter, OnLightEnter);
            Light2D.RegisterEventListener(LightEventListenerType.OnExit, OnLightExit);

            m_OriginGravityScale = m_Rigidbody.gravityScale;
            StartCoroutine(Recharge(m_DashChargeRate));
        }

        void Update()
        {
            // Trigger dash
            if (Input.GetKeyDown (KeyCode.E) && !m_IsDash && m_DashEnergy > 0 && !m_IsDash) {
				m_IsDash = true;
				m_DashControl.ResetColor (m_LightArea.LightArea.LightColor);

				AudioSource.PlayClipAtPoint (m_DashSound, transform.position);
				m_CountdownRoutine = StartCoroutine (CountDown (m_DashUnitTime * m_DashEnergy));
				m_DashEnergy = 0;

				GameObject dashEffectInstance = GameObject.Instantiate (m_DashEffect, transform.position, transform.rotation) as GameObject;
				if (!m_Character.FacingRight) {
					Vector3 scale = dashEffectInstance.transform.localScale;
					scale.x = -1.0f;
					dashEffectInstance.transform.localScale = scale;
				}
			} else if (m_IsDash) {
				m_IsDash = Input.GetKey (KeyCode.E);
			} 

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            m_Character.BaseVelocity = m_CarryableObject.CarrierVelocity + m_AdditionalVelocity;
            m_AdditionalVelocity = Vector2.Lerp(m_AdditionalVelocity, Vector2.zero, Time.deltaTime * m_RecoverFromDamageSpeed);

            if(m_IsDash)
            {
                m_Character.BaseVelocity += new Vector2((m_Character.FacingRight) ? m_DashForce : -m_DashForce, 0);
                m_Rigidbody.gravityScale = 0;
                m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x, 0);
            }
            else
            {
                m_Rigidbody.gravityScale = m_OriginGravityScale;
                if(m_CountdownRoutine != null)
                {
                    StopCoroutine(m_CountdownRoutine);
                    m_CountdownRoutine = null;
                }
            }

            m_DashControl.UpdateDashLaser(m_IsDash, m_LightArea.LightArea.LightColor);
            m_Animator.SetBool("Dash", m_IsDash);
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

        void OnLightEnter(Light2D l, GameObject g)
        {

        }

        void OnLightStay(Light2D l, GameObject g)
        {
            if(id == g.GetInstanceID() && ColorUtil.colorCompareQuantRGB(l.LightColor, Color.white, 127))
            {
                m_Health.decreaseHealth(m_DamageAmountHitByWhite);
            }
        }

        void OnLightExit(Light2D l, GameObject g)
        {

        }

        public void OnHeathChange(int hp, int diff)
        {
            if(diff < 0 && !m_Animator.GetBool("Damage"))
            {
                m_Animator.SetTrigger("Damage");

                Vector2 backDir = new Vector2(transform.right.x, transform.right.y) * ((m_Character.FacingRight) ? -1.0f : 1.0f);
                m_AdditionalVelocity += backDir * m_DamageBackoffForce;
            }
        }
		public void FinishLevel(){

			enabled = false;
//			ControllerColliderHit 
//			Collider
		}
		public void Kill(){
			IsDead = true;
			//Health
		}
		public void RespawnAt(Transform spawnPoint){

//			if (!_isFacingRighr) {
//				LightFlipFollow()
//			}
			IsDead = false;
			//Health
			//Health.HealthPoint = m
			Health.increaseHealth (100);
			transform.position = spawnPoint.position;
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

