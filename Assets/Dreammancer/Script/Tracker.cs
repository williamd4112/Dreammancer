using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class Tracker : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_TrackingTarget;
        [SerializeField]
        private float m_Speed = 1.5f;

        // Use this for initialization
        void Start()
        {
           
        }

        // Update is called once per frame
        void LateUpdate()
        {
            float oy = transform.position.y;
            Vector3 v = Vector3.Lerp(transform.position, m_TrackingTarget.transform.position, m_Speed * Time.deltaTime);
            v.y = oy;
            transform.position = v;
        }
    }
}
