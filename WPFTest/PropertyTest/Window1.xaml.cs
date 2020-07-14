using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PropertyTest
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }


        public static readonly DependencyProperty AgeProperty = DependencyProperty.RegisterAttached("AgeProperty", typeof(int), typeof(Window1),
            new PropertyMetadata(0));

        public static int GetAgeProperty(DependencyObject obj)
        {
            return (int)obj.GetValue(AgeProperty);
        }

        public static void SetAgeProperty(DependencyObject obj,int value)
        {
            obj.SetValue(AgeProperty, value);
        }

        class FamilyMember : DependencyObject { }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FamilyMember m1 = new FamilyMember();
            FamilyMember m2 = new FamilyMember();

            Window1.SetAgeProperty(m1, 28);
            Window1.SetAgeProperty(m2, 3);

            int age1 = Window1.GetAgeProperty(m1);
            int age2 = Window1.GetAgeProperty(m2);

            MessageBox.Show(age1 + " " + age2);
        }
    }
}
