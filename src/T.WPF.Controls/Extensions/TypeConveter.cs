using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace T.Controls.Extensions
{
    public static class TypeConveter
    {
        /// <summary>
        /// convert string to double
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue"></param>
        /// <returns>if success, return result, else return defaultValue</returns>
        public static double ToDouble(this string source, double defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;
            double result;
            return double.TryParse(source, out result) ? result : defaultValue;
        }

        /// <summary>
        /// convert string to double
        /// </summary>
        /// <param name="source"></param>
        /// <returns>if failed, throw a exception</returns>
        /// <exception cref="ArgumentNullException">s 为 null</exception>
        /// <exception cref="FormatException">source is not a number</exception>
        /// <exception cref="OverflowException"> source overflow range of double</exception>
        public static double ToDouble(this string source)
        {
            return double.Parse(source);
        }


        /// <summary>
        /// convert string to byte
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue"></param>
        /// <returns>if success, return result, else return defaultValue</returns>
        public static byte ToByte(this string source, byte defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;
            byte result;
            return byte.TryParse(source, out result) ? result : defaultValue;
        }

        public static Color ToColor(int source)
        {
            return Colors.Red;
        }
    }
}
