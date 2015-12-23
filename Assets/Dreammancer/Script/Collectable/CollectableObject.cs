using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public enum CollectableType
    {
        SMALL_ENERGY,
        SMALL_LIFE
    }

    [RequireComponent(typeof(Collider2D))]
    public class CollectableObject : MonoBehaviour
    {
        [SerializeField]
        private CollectableType m_Type;
        public CollectableType Type
        {
            get { return m_Type; }
        }

        [SerializeField]
        private AudioClip m_OnCollectedSound;

        void Start()
        {
        }

        public void PlaySound()
        {
            AudioSource.PlayClipAtPoint(m_OnCollectedSound, transform.position);
        }
    }
}
