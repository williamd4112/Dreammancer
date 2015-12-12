using UnityEngine;
using System.Collections;

namespace Dreammancer
{
    public class ColorUtil
    {
        public static Color clampColor(Color c, float min, float max)
        {
            c.r = Mathf.Clamp(c.r, min, max);
            c.g = Mathf.Clamp(c.g, min, max);
            c.b = Mathf.Clamp(c.b, min, max);
            c.a = Mathf.Clamp(c.a, min, max);

            return c;
        }

        public static Color colorAddRGB(Color a, Color b)
        {
            a.r += b.r;
            a.g += b.g;
            a.b += b.b;

            return a;
        }

        public static Color colorSubRGB(Color a, Color b)
        {
            a.r -= b.r;
            a.g -= b.g;
            a.b -= b.b;
            
            return a;
        }

        public static bool colorCompareRGB(Color a, Color b)
        {
            return (a.r == b.r && a.g == b.g && a.b == b.b);
        }

        public static Color floatTo255(Color c)
        {
            return clampColor(c, 0, 1) * 255.0f;
        }

        public static Color quantinize(Color c, int levelSize)
        {
            return c / levelSize;
        }
    }
}
