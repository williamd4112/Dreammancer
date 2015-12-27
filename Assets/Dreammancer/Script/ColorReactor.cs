using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public delegate void ColorEvent();

    public class ColorReactor : MonoBehaviour
    {
        [SerializeField]
        [Range(2, 5)]
        private int m_Partitions = 2;

        private ColorEvent[,,] m_ColorEvents;
        private SpriteRenderer m_Renderer;

        public ColorReactor()
        {
            m_ColorEvents = new ColorEvent[m_Partitions, m_Partitions, m_Partitions];
        }

        public void RegistetColorEvent(ColorEvent e, Color c)
        {
            Color color = c;
            color = ColorUtil.floatTo255(color);
            color = ColorUtil.quantinize(color, 255 / m_Partitions);

            int r, g, b;
            r = Mathf.Clamp(Mathf.FloorToInt(color.r), 0, m_Partitions - 1);
            g = Mathf.Clamp(Mathf.FloorToInt(color.g), 0, m_Partitions - 1);
            b = Mathf.Clamp(Mathf.FloorToInt(color.b), 0, m_Partitions - 1);

            m_ColorEvents[r, g, b] += e;
        }

        void Start()
        {
            m_Renderer = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            Color color = m_Renderer.color;
            color = ColorUtil.floatTo255(color);
            color = ColorUtil.quantinize(color, 255 / m_Partitions);

            int r, g, b;
            r = Mathf.Clamp(Mathf.FloorToInt(color.r), 0, m_Partitions - 1);
            g = Mathf.Clamp(Mathf.FloorToInt(color.g), 0, m_Partitions - 1);
            b = Mathf.Clamp(Mathf.FloorToInt(color.b), 0, m_Partitions - 1);  
            
            if(m_ColorEvents[r, g, b] != null)
            {
                Debug.LogFormat("<{0}, {1}, {2}>", r, g, b);
                m_ColorEvents[r, g, b].Invoke();
            }
        }
    }

    
}
