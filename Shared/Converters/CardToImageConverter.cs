using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Shared.Converters
{
    public static class CardToImageConverter : IValueConverter
    {
        public static string CardImagePath(string cardName)
        {
            return $"/Shared;component/Resources/{cardName}.png";
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
