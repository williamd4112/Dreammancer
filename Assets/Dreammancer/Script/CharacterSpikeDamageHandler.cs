using UnityEngine;
using System.Collections;
using System;

namespace Dreammancer
{
    public class CharacterSpikeDamageHandler : DamageHandler
    {
        public override void OnDamageTrigger(Damage damage)
        {
            Health health = gameObject.GetComponent<Health>();
            if(health != null)
            {
                health.decreaseHealth(health.MaxHealth);
            }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
