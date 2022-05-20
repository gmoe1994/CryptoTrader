using Microsoft.UI.Xaml.Data;
using System;
using System.Globalization;

namespace CryptoTrader.App.Helpers
{
    public class ConvertToCurrency : IValueConverter
    {
        /// <summary>Converts the specified value to a currency format</summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="language">The language.</param>
        /// <returns>System.Object.</returns>
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
