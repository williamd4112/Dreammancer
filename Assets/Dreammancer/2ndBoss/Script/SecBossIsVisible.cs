using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class SecBossIsVisible : MonoBehaviour
    {

        private SpriteRenderer m_sr;
        private Vector3 m_pos;
        private Vector3 i_pos;
        private Vector3 c_pos;
        [SerializeField]
        private GameObject player;
        private Vector3 p_pos;
        private Vector3 newV3;
        [SerializeField]
        private Canvas m_Can;
        private float width;
        [SerializeField]
        private GameObject mainCam;
        [SerializeField]
        private GameObject imga;
        private Camera m_Cam;
        private float newX;
        float Can_X;
        // Use this for initialization
        void Start()
        {
            m_sr = this.GetComponent<SpriteRenderer>();
            width = m_Can.GetComponent<RectTransform>().rect.width;
            m_Cam = mainCam.GetComponent<Camera>();
            i_pos = imga.GetComponent<RectTransform>().position;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (!m_sr.isVisible)
            {
                imga.SetActive(true);
                m_pos = this.gameObject.transform.position;
                p_pos = player.transform.position;
                c_pos = mainCam.transform.position;
                newX = m_Cam.WorldToScreenPoint(this.transform.position).x;
                if (newX >= m_Can.pixelRect.width)
                {
                    newX = m_Can.pixelRect.width;
                }
                else if (newX <= 0)
                {
                    newX = 0;
                }
                imga.GetComponent<RectTransform>().position = new Vector3(newX, i_pos.y, i_pos.z);
            }
            else
            {
                imga.SetActive(false);
            }

        }
    }
}
