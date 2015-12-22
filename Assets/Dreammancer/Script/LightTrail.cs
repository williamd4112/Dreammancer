using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(Light2D))]
    public class LightTrail : MonoBehaviour
    {
        [SerializeField]
        private float m_TrailFactor = 5.0f;

        private Vector3 m_LastPos;
        private float m_Diff;
        private Light2D m_Light2D;

        // Use this for initialization
        void Start()
        {
            m_LastPos = transform.position;
            m_Light2D = GetComponent<Light2D>();
        }

        // Update is called once per frame
        void LateUpdate()
        {
            m_Diff = Mathf.Abs((transform.position - m_LastPos).x);
            Debug.LogFormat(transform.position + "," + m_LastPos + ":"+ m_Diff);
            m_LastPos = transform.position;
           
            m_Light2D.LightBeamRange = Mathf.Lerp(m_Light2D.LightBeamRange, m_TrailFactor * m_Diff, Time.deltaTime);

        }
    }
}
