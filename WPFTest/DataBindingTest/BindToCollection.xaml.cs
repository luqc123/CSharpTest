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
using StoreDatabase;

namespace DataBindingTest
{
    /// <summary>
    /// Interaction logic for BindToCollection.xaml
    /// </summary>
    public partial class BindToCollection : Window
    {
        public BindToCollection()
        {
            InitializeComponent();
        }
        private ICollection<Product> products;
        private bool isDirty = false;

        private void lstProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            products = App.StoreDb.GetProducts();
            lstProducts.ItemsSource = products;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            products.Remove((Product)lstProducts.SelectedItem);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            products.Add(new Product("000000", "?", 0, "?"));
        }

        private void Grid_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
