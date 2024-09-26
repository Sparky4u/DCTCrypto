using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DCTCrypto.Utilities.Converter
{
    public class PriceChangeConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not double doubleValue)
                return null;

            var result = doubleValue.ToString("0.00", culture) + "%";
            if (doubleValue > 0)
                return "+" + result;

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
