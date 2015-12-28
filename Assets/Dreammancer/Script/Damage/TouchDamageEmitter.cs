using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Collider2D))]
    public class TouchDamageEmitter : MonoBehaviour
    {
        [SerializeField]
        private int m_DamageAmount;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnCollisionEnter2D(Collision2D other)
        {
            Health health = other.gameObject.GetComponent<Health>();
            if(health != null)
            {
                health.decreaseHealth(m_DamageAmount);
            }
        }
    }
}
