using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    [RequireComponent(typeof(MovingPlatform))]
    public class DynamicCube : MonoBehaviour
    {
        public enum DynamicCubeState
        {
            POSITIVE,
            NORMAL,
            NEGATIVE
        }

        private DynamicCubeState m_State = DynamicCubeState.NORMAL;

        [SerializeField]
        private Transform m_HStart;
        [SerializeField]
        private Transform m_HEnd;
        [SerializeField]
        private Transform m_VStart;
        [SerializeField]
        private Transform m_VEnd;
        [SerializeField]
        private float m_Speed = 1.8f;

        private MovingPlatform m_MovingPlatform;

        // Use this for initialization
        void Start()
        {
            m_MovingPlatform = GetComponent<MovingPlatform>();
            Light2D.RegisterEventListener(LightEventListenerType.OnStay, OnLightStay);
        }

        // Update is called once per frame
        void Update()
        {
            switch(m_State)
            {
                case DynamicCubeState.POSITIVE:
                    m_MovingPlatform.startTransform = m_HStart;
                    m_MovingPlatform.endTransform = m_HEnd;
                    m_MovingPlatform.platformSpeed = m_Speed;
                    break;
                case DynamicCubeState.NORMAL:
                    m_MovingPlatform.platformSpeed = 0;
                    break;
                case DynamicCubeState.NEGATIVE:
                    m_MovingPlatform.startTransform = m_VStart;
                    m_MovingPlatform.endTransform = m_VEnd;
                    m_MovingPlatform.platformSpeed = m_Speed;
                    break;
                default:
                    break;
            }
        }

        void OnLightStay(Light2D l, GameObject o)
        {
            if (o.GetInstanceID() == gameObject.GetInstanceID())
            {
                if (ColorUtil.colorCompareQuantRGB(l.LightColor, Color.red, 127))
                    m_State = DynamicCubeState.POSITIVE;
                if (ColorUtil.colorCompareQuantRGB(l.LightColor, Color.blue, 127))
                    m_State = DynamicCubeState.NEGATIVE;
            }
        }

    }
}
