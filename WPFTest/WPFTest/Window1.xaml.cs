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
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        Student stu;
        public Window1()
        {
            InitializeComponent();

            stu = new Student();

            //准备绑定
            Binding binding = new Binding();
            //源
            binding.Source = stu;
            binding.Path = new PropertyPath("Name");

            //使用Binding连接数据源和目标
            BindingOperations.SetBinding(this.textBoxName, TextBox.TextProperty, binding);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stu.Name = "Name";
        }
    }
}
