using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace PokerTimer
{
    public class MyColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((bool)value)
            {
                {
                    return Windows.UI.Colors.Red.ToString();
                }
            }
            return Windows.UI.Colors.White.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

    }
}
