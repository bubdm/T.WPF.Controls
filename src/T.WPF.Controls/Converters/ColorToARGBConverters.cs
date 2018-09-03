using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using T.Controls.Extensions;

namespace T.Controls.Converters
{
    public class ColorToAConverters : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = (Color)value;
            return color.A;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = parameter as TextBox;
            if (text != null)
            {
                var color = (Color)ColorConverter.ConvertFromString(text.Text);
                color.A = value.ToString().ToByte(255);
                return color;
            }
            return value;
        }
    }


    public class ColorToRConverters : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = (Color)value;
            return color.R;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = parameter as TextBox;
            if (text != null)
            {
                var color = (Color)ColorConverter.ConvertFromString(text.Text);
                color.R = value.ToString().ToByte(255);
                return color;
            }
            return value;
        }
    }


    public class ColorToGConverters : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = (Color)value;
            return color.G;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = parameter as TextBox;
            if (text != null)
            {
                var color = (Color)ColorConverter.ConvertFromString(text.Text);
                color.G = value.ToString().ToByte(255);
                return color;
            }
            return value;
        }
    }

    public class ColorToBConverters : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = (Color)value;
            return color.B;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = parameter as TextBox;
            if (text != null)
            {
                var color = (Color)ColorConverter.ConvertFromString(text.Text);
                color.B = value.ToString().ToByte(255);
                return color;
            }
            return value;
        }
    }
}
