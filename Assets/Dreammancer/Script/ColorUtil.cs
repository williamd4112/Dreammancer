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

        public static bool colorCompareQuantRGB(Color a, Color b, int partitionSize)
        {
            a = ColorUtil.quantinize(ColorUtil.floatTo255(a), partitionSize);
            b = ColorUtil.quantinize(ColorUtil.floatTo255(b), partitionSize);

            int maxLevel = 255 / partitionSize;
            int ar, ag, ab;
            ar = Mathf.Clamp(Mathf.FloorToInt(a.r), 0, maxLevel - 1);
            ag = Mathf.Clamp(Mathf.FloorToInt(a.g), 0, maxLevel - 1);
            ab = Mathf.Clamp(Mathf.FloorToInt(a.b), 0, maxLevel - 1);

            int br, bg, bb;
            br = Mathf.Clamp(Mathf.FloorToInt(b.r), 0, maxLevel - 1);
            bg = Mathf.Clamp(Mathf.FloorToInt(b.g), 0, maxLevel - 1);
            bb = Mathf.Clamp(Mathf.FloorToInt(b.b), 0, maxLevel - 1);

            return ar == br && ag == bg && ab == bb;
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
