using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using T.Controls.core;

namespace T.Controls.Converters
{
    public class HubToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var hub = (double)value;
            var color= ColorHelper.HSV2RGB(new HSVColor((float)hub, 1, 1));
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)ColorHelper.GetHube((Color)value);
        }
    }
}
