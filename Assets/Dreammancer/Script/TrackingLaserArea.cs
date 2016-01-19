﻿using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class TrackingLaserArea : MonoBehaviour
    {
        private GameObject m_AttachedLaser;

        // Use this for initialization
        void Start()
        {
            m_AttachedLaser = transform.FindChild("Laser").gameObject;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                m_AttachedLaser.SetActiveRecursively(true);
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                m_AttachedLaser.SetActiveRecursively(false);
            }
        }

    }
}