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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //Student stu;
        public MainWindow()
        {
            InitializeComponent();
            //// 准备数据源
            //stu = new Student();
            ////准备binding
            //Binding binding = new Binding();
            //binding.Source = stu;
            //binding.Path = new PropertyPath("Name");
            ////使用binding连接数据源和Binding目标
            //BindingOperations.SetBinding(this.textBoxName, TextBox.TextProperty, binding);

        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    stu.Name += "Name";
        //}
    }
}
