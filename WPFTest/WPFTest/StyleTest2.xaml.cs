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
    /// StyleTest2.xaml 的交互逻辑
    /// </summary>
    public partial class StyleTest2 : Window
    {
        public StyleTest2()
        {
            InitializeComponent();
            Init();
        }

        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Skill { get; set; }
        }
        
        private void Init()
        {
            List<Student> info = new List<Student>() {
                new Student() {Id=1,Name="luqc",Skill="C#"},
                new Student() {Id=2,Name="pengan",Skill="English"},
                new Student() {Id=3,Name="xiran",Skill="Excel"},
            };
            this.lbInfos.ItemsSource = info;
        }
    }
}
