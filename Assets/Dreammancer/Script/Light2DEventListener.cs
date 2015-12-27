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
        protected AudioClip hitSound;

        [SerializeField]
        protected GameObject m_RipEffectAnimation;

        [SerializeField]
        private float m_FadeInSpeed = 10.0f;

        [SerializeField]
        private float m_FadeOutSpeed = 5.0f;

        protected int id = 0;
        private bool isDetected = false;
        private bool isEffect = false;
        private bool isAnimPlaying = false;
        private Color m_OriginColor = Color.black;
        private Color m_FadeInColor = Color.black;
        private Dictionary<Light2D, Color> m_AffectLightTable;
        private Light2DEvent m_LaserHitEvents;

        private int m_HiddenLayer;
        private int m_NormalLayer;

        private SpriteRenderer m_Renderer;
        private SpriteRenderer[] m_ChildRenderers;
        [SerializeField]
        private bool m_IsRecurrsive = true;

        private Collider2D m_Collider;

        public bool GetIsEffect()
        {
            return isEffect;
        }

        public void RegisterLaserEvent(Light2DEvent e)
        {
            m_LaserHitEvents += e;
        }

        void Start()
        {
            id = gameObject.GetInstanceID();
            m_Renderer = GetComponent<SpriteRenderer>();
            m_ChildRenderers = GetComponentsInChildren<SpriteRenderer>();
            m_Collider = GetComponent<Collider2D>();

            if (m_Renderer != null)
                m_OriginColor = m_Renderer.color;
            else
                m_OriginColor = m_ChildRenderers[0].color;
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
            {
                if(m_Renderer != null)
                    m_Renderer.color = Color.Lerp(
                        m_Renderer.color, m_FadeInColor, Time.deltaTime * m_FadeInSpeed);
                if (m_IsRecurrsive)
                    foreach (SpriteRenderer renderer in m_ChildRenderers)
                    {
                        renderer.color = Color.Lerp(
                            renderer.color, m_FadeInColor, Time.deltaTime * m_FadeInSpeed);
                    }
            }
            else
            {
                if (m_Renderer != null)
                    m_Renderer.color = Color.Lerp(
                        m_Renderer.color, m_OriginColor, Time.deltaTime * m_FadeOutSpeed);
                if (m_IsRecurrsive)
                    foreach (SpriteRenderer renderer in m_ChildRenderers)
                        renderer.color = Color.Lerp(
                            renderer.color, m_OriginColor, Time.deltaTime * m_FadeOutSpeed);
            }

            if(EnablePhysicEffect)
                isEffect = checkReachLimit();

            isDetected = false;
        }

        virtual protected void OnLightEnter(Light2D l, GameObject g)
        {
            if (g.GetInstanceID() == id)
            {
                if (!l.CompareTag("Laser"))
                {
                    m_AffectLightTable.Add(l, l.LightColor);
                    m_FadeInColor = ColorUtil.colorSubRGB(m_FadeInColor, l.LightColor);

                    AudioSource.PlayClipAtPoint(hitSound, transform.position, 0.1f);
                    isAnimPlaying = false;
                }
            }
        }

        virtual protected void OnLightStay(Light2D l, GameObject g)
        {
            if (g.GetInstanceID() == id && m_AffectLightTable.ContainsKey(l))
            {
                Color color = m_AffectLightTable[l];
                if (!color.Equals(l.LightColor))
                {
                    m_FadeInColor = ColorUtil.colorAddRGB(m_FadeInColor, color);
                    m_FadeInColor = ColorUtil.colorSubRGB(m_FadeInColor, l.LightColor);
                    m_AffectLightTable[l] = l.LightColor;
                    isAnimPlaying = false;
                }
                isDetected = true;

            }
        }

        virtual protected void OnLightExit(Light2D l, GameObject g)
        {
            if (g.GetInstanceID() == id && m_AffectLightTable.ContainsKey(l))
            {
                m_FadeInColor = ColorUtil.colorAddRGB(m_FadeInColor, m_AffectLightTable[l]);

                m_AffectLightTable.Remove(l);
            }
        }

        bool checkReachLimit()
        {
            Color clampColor = ColorUtil.clampColor(m_FadeInColor, 0, 1);
            bool b = ColorUtil.colorCompareQuantRGB(Color.black, clampColor, 127) && isDetected;

            if (m_RipEffectAnimation != null && b && !isAnimPlaying)
            {
                GameObject.Instantiate(m_RipEffectAnimation, transform.position, transform.rotation);
                isAnimPlaying = true;
            }

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

            if (m_Renderer != null)
            {
                Color color = m_Renderer.color;
                color.a = (b) ? FADEOUT_INTENSITY : 1.0f;
                m_Renderer.color = color;
            }
            if (m_IsRecurrsive)
                foreach (SpriteRenderer renderer in m_ChildRenderers)
                {
                    Color color = renderer.color;
                    color.a = (b) ? FADEOUT_INTENSITY : 1.0f;
                    renderer.color = color;
                }
        }
    }
}

