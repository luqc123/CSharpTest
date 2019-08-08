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
    /// Interaction logic for CustomEventTest.xaml
    /// </summary>
    public partial class CustomEventTest : Window
    {
        public CustomEventTest()
        {
            InitializeComponent();
        }

        private void TimeButton_ReportTime(object sender, CustomEventArgs e)
        {
            FrameworkElement f = sender as FrameworkElement;
            string timeStr = e.ClickTime.ToLongTimeString();
            string content = string.Format("{0} arrived {1}", timeStr, f.Name);
            this.listBox.Items.Add(content);
            if (f.Name == this.grid2.Name)
                e.Handled = true;
        }

        private void Clr_Click(object sender, RoutedEventArgs e)
        {
            this.listBox.Items.Clear();
        }

    }
}
