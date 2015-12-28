using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Damageable))]
    public class DropItem : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_DropItem;

        private Damageable m_Damageable;

        // Use this for initialization
        void Start()
        {
            m_Damageable = GetComponent<Damageable>();
            m_Damageable.RegisterDestroyEvent(OnObjectDestroy);
        }

        void OnObjectDestroy()
        {
            GameObject.Instantiate(m_DropItem, transform.position, transform.rotation);
        }
    }
}
