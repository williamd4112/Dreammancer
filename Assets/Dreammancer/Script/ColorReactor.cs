using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public delegate void ColorEvent(GameObject source, Object arg);

    public class ColorReactor : MonoBehaviour
    {
        [SerializeField]
        private int m_Partitions;

        private ColorEvent[,] m_ColorEvents;
        private SpriteRenderer m_Renderer;

        void Start()
        {
            m_ColorEvents = new ColorEvent[3, m_Partitions];
            m_Renderer = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            Color color = m_Renderer.color;
            color = ColorUtil.floatTo255(color);
            color = ColorUtil.quantinize(color, 255 / m_Partitions);

            int r, g, b;
            r = Mathf.FloorToInt(color.r);
            g = Mathf.FloorToInt(color.g);
            b = Mathf.FloorToInt(color.b);
            Debug.LogFormat("{0}, {1}, {2}", r,g,b);
        }
    }

    
}
