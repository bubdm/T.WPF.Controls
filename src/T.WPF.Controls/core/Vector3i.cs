using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace T.Controls.core
{
    struct Vector3i
    {
        public static Vector3i White = new Vector3i(255, 255, 255);

        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public Vector3i(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }
        public Vector3i(Color color)
        {
            R = color.R;
            G = color.G;
            B = color.B;
        }

        public static Vector3i operator +(Vector3i color1, Vector3i color2)
        {
            return new Vector3i(color1.R + color2.R, color1.G + color2.G, color1.B + color2.B);
        }
        public static Vector3i operator -(Vector3i color1, Vector3i color2)
        {
            return new Vector3i(color1.R - color2.R, color1.G - color2.G, color1.B - color2.B);
        }

        public static Vector3i operator *(Vector3i color1, int c)
        {
            return new Vector3i(color1.R * c, color1.G * c, color1.B * c);
        }

        public static Vector3i operator *(Vector3i color1, double c)
        {
            return new Vector3i((int)(color1.R * c), (int)(color1.G * c), (int)(color1.B * c));
        }

        public Color ToColor()
        {
            return new Color() { A = 255, R = (byte)R, G = (byte)G, B = (byte)B };
        }

        public override string ToString()
        {
            return $"{R},{G},{B}";
        }
    }
}
