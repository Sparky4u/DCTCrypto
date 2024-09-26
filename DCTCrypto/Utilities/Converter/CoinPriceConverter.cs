using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;

namespace DCTCrypto.Utilities.Converter
{
    public class CoinPriceConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not double doubleValue)
                return null;

            if(doubleValue > 1)
                return string.Concat("$",doubleValue.ToString("###0.00",culture));

            var refDouble = 0.1;
            var count = 1;
            while (!(doubleValue >= refDouble))
            {
                refDouble /= 10;
                count++;
            }

            return string.Concat("$",doubleValue.ToString($"###0.{new string('0',count)}0",culture));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
