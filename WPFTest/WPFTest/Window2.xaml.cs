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
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {
        List<string> stringList = new List<string>{"PengMan", "Luqc", "YiHan"};
        public Window2()
        {
            InitializeComponent();
            this.textBox1.SetBinding(TextBox.TextProperty, new Binding("/") { Source = stringList });
            this.textBox2.SetBinding(TextBox.TextProperty, new Binding("/Length") { Source = stringList, Mode = BindingMode.OneWay });
            this.textBox3.SetBinding(TextBox.TextProperty, new Binding("/[2]") { Source = stringList,Mode=BindingMode.OneWay});
        }
    }
}
