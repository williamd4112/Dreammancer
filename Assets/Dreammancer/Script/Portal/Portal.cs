using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Collider2D))]
    public class Portal : MonoBehaviour
    {
        [SerializeField]
        private Transform m_TargetPos;

        [SerializeField]
        private AudioClip m_Sound;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.CompareTag("Player"))
            {
                collider.transform.position = m_TargetPos.position;
                AudioSource.PlayClipAtPoint(m_Sound, transform.position);
            }
        }
    }
}
