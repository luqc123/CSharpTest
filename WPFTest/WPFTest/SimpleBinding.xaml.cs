using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WPFTest
{
    /// <summary>
    /// SimpleBinding.xaml 的交互逻辑
    /// </summary>
    public partial class SimpleBinding : Window
    {
        public SimpleBinding()
        {
            InitializeComponent();
            Binding binding = new Binding();
            binding.Source = textbox1;
            binding.Path = new PropertyPath("Text");
            label1.SetBinding(Label.ContentProperty, binding);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression be = textbox2.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();  
        }
    }
}
