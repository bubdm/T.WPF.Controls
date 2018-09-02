using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace T.Controls.Converters
{
    public class ColorToHexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ColorConverter.ConvertFromString(value.ToString());
        }
    }
}
