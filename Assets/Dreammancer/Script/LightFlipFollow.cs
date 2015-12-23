using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class LightFlipFollow : MonoBehaviour
    {
        [SerializeField]
        private Transform m_Target;
        public Transform Target
        {
            set { m_Target = value; }
        }

        private float m_TargetLastScaleX;

        // Use this for initialization
        void Start()
        {
            m_TargetLastScaleX = m_Target.localScale.x;
        }

        // Update is called once per frame
        void Update()
        {
            //if(m_TargetLastScaleX > 0 && m_Target.localScale.x < 0)
            //{
            //    transform.Rotate(new Vector3(0, 0, -180));
            //}
            //else if (m_TargetLastScaleX < 0 && m_Target.localScale.x > 0)
            //{
            //    transform.Rotate(new Vector3(0, 0, 180));
            //}
            if(m_Target.localScale.x >= 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 270);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 90);
            }

            m_TargetLastScaleX = m_Target.localScale.x;
        }
    }
}
