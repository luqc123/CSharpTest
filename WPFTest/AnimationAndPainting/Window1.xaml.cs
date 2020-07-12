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

namespace AnimationAndPainting
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double o = 1.0;
            int i = 5;
            VisualBrush vBrush = new VisualBrush(this.button);
            while (i > 0)
            {
                Rectangle rect = new Rectangle();
                rect.Height = button.ActualHeight;
                rect.Width = button.ActualWidth;
                rect.Opacity = o;
                rect.Fill = vBrush;
                o -= 0.2;
                i = i - 1;
                this.stackPanelRight.Children.Add(rect);
            }
        }
    }
}
