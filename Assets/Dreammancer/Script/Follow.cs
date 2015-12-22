using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class Follow : MonoBehaviour
    {
        [SerializeField]
        private Transform m_FollowPosition;

        [SerializeField]
        private bool m_FollowRotation = false;

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = m_FollowPosition.position;
            if(m_FollowRotation)
                transform.rotation = m_FollowPosition.rotation;
        }
    }
}
