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

namespace ControlTemplate
{
    /// <summary>
    /// Interaction logic for CarDetailView.xaml
    /// </summary>
    public partial class CarDetailView : UserControl
    {
        public CarDetailView()
        {
            InitializeComponent();
        }

        private Car car;
        public Car Car
        {
            get { return car; }
            set
            {
                car = value;
                textAutomaker.Text = car.Automaker;
                textName.Text = car.Name;
                textYear.Text = car.Year;
                textTopSpeed.Text = car.TopSpeed;
                string uriStr = string.Format(@"/Resource/Image/{0}.jpg", car.Name);
                imageName.Source = new BitmapImage(new Uri(uriStr, UriKind.Relative));
            }
        }
    }
}
