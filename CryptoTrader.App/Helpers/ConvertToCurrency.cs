using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTrader.App.Helpers
{
    public class ConvertToCurrency : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var toConvert = value;
            return string.Format(new CultureInfo("en-US"), "{0:C2}", toConvert);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
