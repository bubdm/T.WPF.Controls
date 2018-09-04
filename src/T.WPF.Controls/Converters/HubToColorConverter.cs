using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using T.Controls.core;

namespace T.Controls.Converters
{
    public class HueToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var Hue = (double)value;
            var color= ColorHelper.HSV2RGB(new HSVColor(Hue, 1, 1));
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)ColorHelper.GetHue((Color)value);
        }
    }
}
