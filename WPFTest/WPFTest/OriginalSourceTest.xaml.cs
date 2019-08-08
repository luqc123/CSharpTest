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
    /// Interaction logic for OriginalSourceTest.xaml
    /// </summary>
    public partial class OriginalSourceTest : Window
    {
        public OriginalSourceTest()
        {
            InitializeComponent();
            this.AddHandler(Button.ClickEvent, new RoutedEventHandler(this.Button_Click));
        }

        private void Button_Click(object sender,RoutedEventArgs e)
        {
            string strOriginalSource = string.Format("Visual Tree start point is {0}, type is {1}",
                (e.OriginalSource as FrameworkElement).Name, e.OriginalSource.GetType().Name);

            string strSource = string.Format("Logical Tree start point is {0},type is {1}",
                (e.Source as FrameworkElement).Name, e.Source.GetType().Name);

            MessageBox.Show(strOriginalSource + "\r\n" + strSource);
        }
    }
}
