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

namespace BindingTest
{
    /// <summary>
    /// Interaction logic for CollectionBind.xaml
    /// </summary>
    public partial class CollectionBind : Window
    {
        public CollectionBind()
        {
            InitializeComponent();
            List<Student> stu = new List<Student>()
            {
                new Student() { Age = 27, ID = 123, Name = "Luqichang" },
                new Student() { Age = 27,ID = 456, Name = "Pengman" },
                new Student() { Age = 2, ID = 789, Name = "Luyihan" }
            };

            //binding listBox1
            this.listBox1.ItemsSource = stu;
            this.listBox1.DisplayMemberPath = "Name";

            Binding binding1 = new Binding("SelectedItem.Age") { Source = this.listBox1 };
            this.textBox1.SetBinding(TextBox.TextProperty, binding1);

            //binding listBox2
            this.listBox2.ItemsSource = stu;
            Binding binding2 = new Binding("SelectedItem.Name") { Source = this.listBox2 };
            this.textBox2.SetBinding(TextBox.TextProperty, binding2);

            this.DataContext = stu[2];
        }
    }

    public class Student
    {
        public int Age { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
