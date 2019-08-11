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
    /// Interaction logic for ResourceTest1.xaml
    /// </summary>
    public partial class ResourceTest1 : Window
    {
        public ResourceTest1()
        {
            InitializeComponent();
            button.Content = Properties.Resources.Password;
            //Uri imgUri = new Uri(@"Resources/Images/CertificatePressed.png", UriKind.Relative);
            //image.Source = new BitmapImage(imgUri);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["res1"] = new TextBlock() { Text = "Changed Text1" };
            this.Resources["res2"] = new TextBlock() { Text = "Changed Text2" };
        }
    }
}
