using System;

namespace T.Controls.Extensions
{
    public static class ConverterHelper
    {
        public static T SafeCast<T>(object source)
        {
            if(source is IConvertible)
            {
                return (T)Convert.ChangeType(source, typeof(T));
            }
            return (T)source;
        }
    }
}
