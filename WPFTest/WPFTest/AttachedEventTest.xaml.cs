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
    /// Interaction logic for AttachedEventTest.xaml
    /// </summary>
    public partial class AttachedEventTest : Window
    {
        public AttachedEventTest()
        {
            InitializeComponent();
            //this.grid1.AddHandler(RoutedStudent.NameChangedEvent, new RoutedEventHandler(this.StudentNameChangedHandler));
            RoutedStudent.AddNameChangedHandler(this.grid1, new RoutedEventHandler(this.StudentNameChangedHandler));
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            RoutedStudent stu = new RoutedStudent() { Id=100,Name="Man"};
            stu.Name = "Tom";

            RoutedEventArgs arg = new RoutedEventArgs(RoutedStudent.NameChangedEvent, stu);
            this.button1.RaiseEvent(arg);
        }


        private void StudentNameChangedHandler(object sender,RoutedEventArgs e)
        {
            MessageBox.Show((e.OriginalSource as RoutedStudent).Id.ToString());
        }
    }
}
