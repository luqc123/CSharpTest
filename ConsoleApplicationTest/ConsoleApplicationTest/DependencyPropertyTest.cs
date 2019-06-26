using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConsoleApplicationTest
{
    class DependencyPropertyTest : DependencyObject
    {
        public static readonly DependencyProperty MyValueProperty =
            DependencyProperty.Register("MyValue", typeof(int), typeof(DependencyPropertyTest), new PropertyMetadata(0));

        public int MyValue
        {
            get { return (int)GetValue(MyValueProperty); }
            set { SetValue(MyValueProperty, value); }
        }

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(int), typeof(DependencyPropertyTest), new PropertyMetadata(100,null,CoerceMaxValue));

        public int Maximum
        {
            get { return (int)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(int), typeof(DependencyPropertyTest), new PropertyMetadata(0,null));

        private static object CoerceMaxValue(DependencyObject element, object value)
        {
            int newValue = (int)value;
            DependencyPropertyTest dt = (DependencyPropertyTest)element;
            newValue = Math.Max(dt.Minimum, Math.Min(dt.Maximum, newValue));
            return newValue;
        }

        private static object CoerMinvalue(DependencyObject element, object value)
        {
            int newValue = (int)value;
            DependencyPropertyTest dt = (DependencyPropertyTest)element;
            return newValue;
        }

        public void Test()
        {
            int minValue = this.Minimum;
            int maxValue = this.Maximum;

            Console.WriteLine("Min value is {0} Max value is {1}", minValue, maxValue);

            this.Maximum = 200;
            minValue = this.Minimum;
            maxValue = this.Maximum;
            Console.WriteLine("Min value is {0} Max value is {1}", minValue, maxValue);

            this.Maximum = 20;
            minValue = this.Minimum;
            maxValue = this.Maximum;
            Console.WriteLine("Min value is {0} Max value is {1}", minValue, maxValue);

        }
    }
}
