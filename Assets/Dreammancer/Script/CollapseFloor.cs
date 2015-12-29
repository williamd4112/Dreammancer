using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class CollapseFloor : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_DisappearAnim;
        [SerializeField]
        private AudioClip m_DisappearSound;

        private bool m_IsDestroy = false;
        private int id;

        // Use this for initialization
        void Start()
        {
            id = gameObject.GetInstanceID();
            Light2D.RegisterEventListener(LightEventListenerType.OnStay, OnLightStay);
        }

        // Update is called once per frame
        void Update()
        {
            if (m_IsDestroy) Destroy(gameObject);
        }

        void OnLightStay(Light2D l, GameObject g)
        {
            if (g.GetInstanceID() == id && ColorUtil.colorCompareQuantRGB(l.LightColor, Color.white, 127))
            {
                AudioSource.PlayClipAtPoint(m_DisappearSound, transform.position);
                GameObject.Instantiate(m_DisappearAnim, transform.position, transform.rotation);
                m_IsDestroy = true;
            }
        }
    }
}
