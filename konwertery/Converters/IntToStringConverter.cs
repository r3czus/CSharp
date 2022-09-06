using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace konwertery.Converters
{
    internal class IntToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        { 
            if(parameter != null)
            { return System.Convert.ToInt32(value) >= System.Convert.ToInt32(parameter) ? "zdane" : "oblane"; }
            else
            { return System.Convert.ToInt32(value) >= 50 ? "zdane" : "oblane"; }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        { throw new NotImplementedException(); }
    }
}
