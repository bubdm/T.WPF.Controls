using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace T.Controls.core
{
    public struct HSVColor
    {
        public double H { get; set; }
        public double S { get; set; }
        public double V { get; set; }

        public HSVColor(double h, double s, double v)
        {
            H = h;
            S = s;
            V = v;
        }

        public static bool operator ==(HSVColor color1, HSVColor color2)
        {
            return color1.H == color2.H && color1.S == color2.S && color1.V == color2.V;
        }

        public static bool operator !=(HSVColor color1, HSVColor color2)
        {
            return color1.H != color2.H || color1.S != color2.S || color1.V != color2.V;
        }

        public override string ToString()
        {
            return H + "," + S + "," + V;
        }
    }
}
