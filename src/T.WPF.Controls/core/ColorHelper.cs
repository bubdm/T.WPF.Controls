using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace T.Controls.core
{
    public sealed class ColorHelper
    {
        public static Color HSV2RGB(HSVColor hSVColor)
        {
            if (hSVColor.S == 0)
            {
                return CreateColor(1, hSVColor.V, hSVColor.V, hSVColor.V);
            }
            var h = (hSVColor.H*360 / 60) % 6;//when h is 360, needing mod 6
            var i = Math.Floor(h);
            var f = h - i;
            var p = hSVColor.V * (1 - hSVColor.S);
            var q = (float)(hSVColor.V * (1 - hSVColor.S * f));
            var t = (float)(hSVColor.V * (1 - hSVColor.S * (1 - f)));
            switch (i)
            {
                case 0:
                    return CreateColor(1, hSVColor.V, t, p);
                case 1:
                    return CreateColor(1, q, hSVColor.V, p);
                case 2:
                    return CreateColor(1, p, hSVColor.V, t);
                case 3:
                    return CreateColor(1, p, q, hSVColor.V);
                case 4:
                    return CreateColor(1, t, p, hSVColor.V);
                default:
                    return CreateColor(1, hSVColor.V, p, q);
            }
        }

        internal static double GetHube(Color value)
        {
            return RGB2HSV(value).H;
        }

        private static Color CreateColor(double a, double r, double g, double b)
        {
            return Color.FromArgb((byte)(255*a), (byte)(255 *r), (byte)(255 *g), (byte)(255 *b));
        }

        public static HSVColor RGB2HSV(Color rgbColor)
        {
            var r = rgbColor.R / 255.0f;
            var g = rgbColor.G / 255.0f;
            var b = rgbColor.B / 255.0f;
            var max = Math.Max(r, Math.Max(b, g));
            var min = Math.Min(r, Math.Min(b, g));
            var delta = max - min;

            double h,s,v;
            v = max;
            if(max != 0 && delta != 0)
            {
                s = delta / max;
                if (r == max)
                {
                    h = (g - b) / delta;
                }
                else if (g == max)
                {
                    h = 2 + (b - r) / delta;
                }
                else
                {
                    h = 4 + (r - g) / delta;
                }

                h = h * 60;
                if (h < 0)
                    h = h + 360;
            }
            else
            {
                s = 0;
                h = 0;
            }
            return new HSVColor(h/360,s,v);
        }
    }
}
