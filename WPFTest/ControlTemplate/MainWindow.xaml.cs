using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace ControlTemplate
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitialCarList();
        }

        public void InitialCarList()
        {
            List<Car> carList = new List<Car>()
            {
                new Car() {Name="Aodi",Year="1991",Automaker="lanbojini",TopSpeed="334"},
                new Car() {Name="Aodi",Year="1992",Automaker="lanbojini",TopSpeed="335"},
                new Car() {Name="Aodi",Year="1993",Automaker="lanbojini",TopSpeed="336"},
                new Car() {Name="Aodi",Year="1994",Automaker="lanbojini",TopSpeed="337"},
            };

            this.listBoxCars.ItemsSource = carList;
            this.listBoxCars.SelectedItem = this.listBoxCars.Items[0];
            //foreach(Car car in carList)
            //{
            //    CarListItemView view = new CarListItemView();
            //    view.Car = car;
            //    listBoxCars.Items.Add(view);
            //}
            //listBoxCars.SelectedItem = listBoxCars.Items[0];
        }

        //private void listBoxCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    CarListItemView view = e.AddedItems[0] as CarListItemView;
        //    if (view != null)
        //        detailView.Car = view.Car;
        //}

    }
    public class AutomakerToLogoPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string uriStr = string.Format(@"/Resource/Image/{0}.png", (string)value);
            return new BitmapImage(new Uri(uriStr, UriKind.Relative));
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class NameToPhotoPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string uriStr = string.Format(@"/Resource/Image/{0}.jpg", (string)value);
            return new BitmapImage(new Uri(uriStr, UriKind.Relative));
        }

        public object ConvertBack(object value, Type targetType, object parameters, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
