using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets._2D;
using System;

namespace Dreammancer
{
    public class DreammancerCharacter : MonoBehaviour, Trappable
    {
        private Collider2D m_Collider;
        private PlatformerCharacter2D m_Character;
        private Rigidbody2D m_Rigidbody;
        private CarryableObject m_CarryableObject;
        private Dictionary<Damage.DamageType, DamageHandler> m_DamageHandlers;
 
        // Use this for initialization
        void Start()
        {
            m_Collider = GetComponent<Collider2D>();
            m_Rigidbody = GetComponent<Rigidbody2D>();
            m_Character = GetComponent<PlatformerCharacter2D>();
            m_CarryableObject = GetComponent<CarryableObject>();

            m_DamageHandlers = new Dictionary<Damage.DamageType, DamageHandler>();
            foreach (DamageHandler handler in GetComponents<DamageHandler>())
                m_DamageHandlers[handler.Type] = handler;

            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Hidden"), true);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Default"), LayerMask.NameToLayer("Hidden"), true);
            //Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Hidden"), LayerMask.NameToLayer("Hidden"), true);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            m_Character.BaseVelocity = m_CarryableObject.CarrierVelocity;
        }

        public void OnTrapEnter(Trap trap)
        {
            DamageHandler handler = m_DamageHandlers[trap.damage.Type];
            handler.OnDamageTrigger(trap.damage);
        }

        public void OnTrapStay(Trap trap)
        {
           
        }

        public void OnTrapExit(Trap trap)
        {
            
        }

    }
}

