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
    /// Interaction logic for RoutedEventTest1.xaml
    /// </summary>
    public partial class RoutedEventTest1 : Window
    {
        public RoutedEventTest1()
        {
            InitializeComponent();
        }
        void AboutDialog_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Title = "e.Source=" + e.Source.GetType().Name + " e.OriginalSource=" + e.OriginalSource.GetType().Name +
                "@" + e.Timestamp;

            Control source = e.Source as Control;

            if (source.BorderThickness != new Thickness(5))
            {
                source.BorderThickness = new Thickness(5);
                source.BorderBrush = Brushes.Blue;
            }
            else
                source.BorderThickness = new Thickness(0);

        }

        void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count > 0)
            {
                MessageBox.Show("You just selected " + e.AddedItems[0]);
            }
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You just clicked " + e.Source);
        }
    }
}
