﻿using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(DreammancerCharacter))]
    public class Collector : MonoBehaviour
    {
        private DreammancerCharacter m_Character;

        // Use this for initialization
        void Start()
        {
            m_Character = GetComponent<DreammancerCharacter>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            CollectableObject collect = collision.gameObject.GetComponent<CollectableObject>();
            if(collect != null)
            {
                switch(collect.Type)
                {
                    case CollectableType.SMALL_ENERGY:
                        m_Character.increaseEnergy(10);
                        collect.PlaySound();
                        Destroy(collision.gameObject);
                        break;
                    case CollectableType.SMALL_LIFE:
                        m_Character.Health.increaseHealth(10);
                        collect.PlaySound();
                        Destroy(collision.gameObject);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}