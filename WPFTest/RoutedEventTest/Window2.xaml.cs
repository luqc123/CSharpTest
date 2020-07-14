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

namespace RoutedEventTest
{
    /// <summary>
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            RootNet.AddRoleChangedHandler(this.gridMain, RoleChangedHandler);
        }

        public void RoleChangedHandler(object sender, RoutedEventArgs e)
        {
            RootNet rootNet = e.OriginalSource as RootNet;
            if (rootNet != null)
            {
                MessageBox.Show(rootNet.Role);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            RootNet root = new RootNet() { Role = "C#" };
            RoutedEventArgs arg = new RoutedEventArgs(RootNet.RoleChanged, root);
            button.RaiseEvent(arg);
        }
    }

    public class RootNet
    {
        public string Role { get; set; }

        public static readonly RoutedEvent RoleChanged = EventManager.RegisterRoutedEvent("RoleChanged", RoutingStrategy.Bubble
            , typeof(RoutedEventHandler), typeof(RootNet));

        public static void AddRoleChangedHandler(DependencyObject dp,RoutedEventHandler h)
        {
            UIElement ui = dp as UIElement;
            if(ui!=null)
            {
                ui.AddHandler(RoleChanged, h);
            }
        }
        public static void RemoveRoleChangedHandler(DependencyObject dp,RoutedEventHandler h)
        {
            UIElement ui = dp as UIElement;
            if (ui != null)
            {
                ui.RemoveHandler(RoleChanged, h);
            }
        }
    }
}
