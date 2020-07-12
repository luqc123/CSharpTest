using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// Interaction logic for CarListItemView.xaml
    /// </summary>
    public partial class CarListItemView : UserControl
    {
        public CarListItemView()
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
                textName.Text = car.Name;
                textYear.Text = car.Year;
                String uriString = string.Format(@"/Resource/Image/{0}.png", car.Name);
                pngName.Source = new BitmapImage(new Uri(uriString, UriKind.Relative));
            }
        }
    }
}
