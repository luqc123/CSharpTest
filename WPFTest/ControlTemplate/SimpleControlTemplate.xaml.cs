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

namespace ControlTemplate
{
    /// <summary>
    /// Interaction logic for SimpleControlTemplate.xaml
    /// </summary>
    public partial class SimpleControlTemplate : Window
    {
        public SimpleControlTemplate()
        {
            InitializeComponent();
        }
    }
    public class Unit
    {
        public int Price { get; set; }
        public string Year { get; set; }
    }
}
