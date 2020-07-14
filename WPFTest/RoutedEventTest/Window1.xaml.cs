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
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            grid1.AddHandler(MyButton.MyClickEvent, new EventHandler<ReportTimeEventArgs>(MyButton_MyClick));
        }

        private void MyButton_MyClick(object sender, ReportTimeEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            if (element != null)
            {
                string timeStr = e.ClickTime.ToLongDateString();
                string content = string.Format("{0} arrived {1}", timeStr, element.Name);
                listBox.Items.Add(content);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.Items.Count > 0)
                listBox.Items.Clear();
        }
    }

    class ReportTimeEventArgs : RoutedEventArgs
    {
        public DateTime ClickTime { get; set; }

        public ReportTimeEventArgs(RoutedEvent routedEvent,object source) : base(routedEvent, source) { }
    }

    public class MyButton : Button
    {
        public static readonly RoutedEvent MyClickEvent = EventManager.RegisterRoutedEvent("MyClick", RoutingStrategy.Bubble, typeof(EventHandler<ReportTimeEventArgs>), typeof(MyButton));

        public event RoutedEventHandler MyClick
        {
            add { this.AddHandler(MyClickEvent, value); }
            remove { this.RemoveHandler(MyClickEvent, value); }
        }

        protected override void OnClick()
        {
            base.OnClick();
            ReportTimeEventArgs newEvent = new ReportTimeEventArgs(MyClickEvent, this);
            newEvent.ClickTime = DateTime.Now;
            this.RaiseEvent(newEvent);
        }
    }
}
