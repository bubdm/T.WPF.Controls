using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace T.Controls.Converters
{
    public class ColorToBrushConverters : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new SolidColorBrush((Color)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var brush = (SolidColorBrush)value;
            return brush.Color;
        }
    }
    
    public class ColorToRGBAConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Color color && parameter is ColorChannelType channel)
            {
                switch (channel)
                {
                    case ColorChannelType.A:
                        return color.A;
                    case ColorChannelType.R:
                        return color.B;
                    case ColorChannelType.G:
                        return color.G;
                    case ColorChannelType.B:
                        return color.B;
                    default:
                        return value;
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //byte chnanel;
            //if(byte.TryParse(value.ToString(), out chnanel))
            //{
            //    if (parameter is ColorChannelType channel)
            //    {
            //        switch (channel)
            //        {
            //            case ColorChannelType.A:
            //                return color.A;
            //            case ColorChannelType.R:
            //                return color.B;
            //            case ColorChannelType.G:
            //                return color.G;
            //            case ColorChannelType.B:
            //                return color.B;
            //            default:
            //                return value;
            //        }
            //    }
            //}
            return null;
            
        }
    }

    public enum ColorChannelType
    {
        A,
        R,
        G,
        B
    }
    
}
