using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTest
{
    [TypeConverter(typeof(StringToHumanConvert))]
    class Human
    {
        public string Name { get; set; }
        public Human Child { get; set; }
    }

    public class StringToHumanConvert:TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                Human h = new Human();
                h.Name = value as string;
                return h;
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}
