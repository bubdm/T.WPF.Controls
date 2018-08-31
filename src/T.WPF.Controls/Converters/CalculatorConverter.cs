using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using T.Controls.Extensions;
using T.Controls.Utils;

namespace T.Controls.Converters
{
    public class CalculatorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null && parameter != null)
            {
                var expression = parameter as string;
                if (!string.IsNullOrEmpty(expression))
                {
                    expression = expression.Replace("$Value", value.ToString());

                    var result = CalculatorHelper.Compute(expression);
                    if (!string.IsNullOrEmpty(result))
                    {
                        return result.ToDouble(0);
                    }
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
