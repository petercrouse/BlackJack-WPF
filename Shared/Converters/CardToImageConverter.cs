using Shared.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Shared.Converters
{
    public class CardToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Card card = value as Card;
            return $"/Shared;component/Resources/{card.Name}.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
