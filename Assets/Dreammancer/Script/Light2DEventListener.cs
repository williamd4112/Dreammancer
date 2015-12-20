using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Dreammancer
{
    public class Light2DEventListener : MonoBehaviour
    {
        const float FADEOUT_INTENSITY = 0.1f;

        [SerializeField]
        private bool EnablePhysicEffect = true;

        [SerializeField]
        private AudioClip hitSound;

        [SerializeField]
        private float m_FadeInSpeed = 10.0f;

        [SerializeField]
        private float m_FadeOutSpeed = 5.0f;

        protected int id = 0;
        private bool isDetected = false;
        private bool isEffect = false;
        private Color m_OriginColor = Color.black;
        private Color m_FadeInColor = Color.black;
        private Dictionary<Light2D, Color> m_AffectLightTable;

        private int m_HiddenLayer;
        private int m_NormalLayer;

        private SpriteRenderer m_Renderer;
        private Collider2D m_Collider;

        public bool GetIsEffect()
        {
            return isEffect;
        }

        void Start()
        {
            id = gameObject.GetInstanceID();
            m_Renderer = GetComponent<SpriteRenderer>();
            m_Collider = GetComponent<Collider2D>();

            m_OriginColor = m_Renderer.color;
            m_FadeInColor = m_OriginColor;
            m_AffectLightTable = new Dictionary<Light2D, Color>();

            m_NormalLayer = gameObject.layer;
            m_HiddenLayer = LayerMask.NameToLayer("Hidden");

            Light2D.RegisterEventListener(LightEventListenerType.OnStay, OnLightStay);
            Light2D.RegisterEventListener(LightEventListenerType.OnEnter, OnLightEnter);
            Light2D.RegisterEventListener(LightEventListenerType.OnExit, OnLightExit);
        }

        void Update()
        {
            if (isDetected)
                m_Renderer.color = Color.Lerp(
                    m_Renderer.color, m_FadeInColor, Time.deltaTime * m_FadeInSpeed);
            else
                m_Renderer.color = Color.Lerp(
                    m_Renderer.color, m_OriginColor, Time.deltaTime * m_FadeOutSpeed);

            if(EnablePhysicEffect)
                isEffect = checkReachLimit();

            isDetected = false;
        }

        virtual protected void OnLightEnter(Light2D l, GameObject g)
        {
            if (g.GetInstanceID() == id)
            {
                m_AffectLightTable.Add(l, l.LightColor);
                m_FadeInColor = ColorUtil.colorSubRGB(m_FadeInColor, l.LightColor);
                //m_FadeInColor = ColorUtil.clampColor(m_FadeInColor, 0, 1);
                AudioSource.PlayClipAtPoint(hitSound, transform.position, 0.1f);
            }
        }

        virtual protected void OnLightStay(Light2D l, GameObject g)
        {
            if (g.GetInstanceID() == id && m_AffectLightTable.ContainsKey(l))
            {
                Color color = m_AffectLightTable[l];
                if(!color.Equals(l.LightColor))
                {
                    m_FadeInColor = ColorUtil.colorAddRGB(m_FadeInColor, color);
                    m_FadeInColor = ColorUtil.colorSubRGB(m_FadeInColor, l.LightColor);
                    //m_FadeInColor = ColorUtil.clampColor(m_FadeInColor, 0, 1);
                    m_AffectLightTable[l] = l.LightColor;
                }
                isDetected = true;
            }
        }

        virtual protected void OnLightExit(Light2D l, GameObject g)
        {
            if (g.GetInstanceID() == id && m_AffectLightTable.ContainsKey(l))
            {
                m_FadeInColor = ColorUtil.colorAddRGB(m_FadeInColor, m_AffectLightTable[l]);
                //m_FadeInColor = ColorUtil.clampColor(m_FadeInColor, 0.0f, 1.0f);
                m_AffectLightTable.Remove(l);
            }
        }

        bool checkReachLimit()
        {
            Color clampColor = ColorUtil.clampColor(m_FadeInColor, 0, 1);
            bool b = ColorUtil.colorCompareRGB(Color.black, clampColor) && isDetected;
            setHidden(b);
            return b;
        }

        void setLayerRecursively(int layer)
        {
            gameObject.layer = layer;
            foreach (Transform child in transform)
            {
                child.gameObject.layer = layer;
            }
        }

        void setHidden(bool b)
        {
            int layer = (b) ? m_HiddenLayer : m_NormalLayer;
            if (gameObject.layer != layer)
                setLayerRecursively(layer);

            Color color = m_Renderer.color;
            color.a = (b) ? FADEOUT_INTENSITY : 1.0f;
            m_Renderer.color = color;
        }
    }
}

