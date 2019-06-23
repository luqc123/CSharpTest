using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media;

namespace BindingTest
{
    public class MyConverter:IValueConverter
    {
        public object Convert(object o, Type type, object parameter, CultureInfo culture)
        {
            var date = (DateTime)o;
            switch(type.Name)
            {
                case "String":
                    return date.ToString("F",culture);
                case "Brush":
                    return Brushes.Red;
                default:
                    return o;
            }
        }

        public object ConvertBack(object o, Type type, object parameter, CultureInfo culture)
        {
            return (object)null;
        }
    }
}
