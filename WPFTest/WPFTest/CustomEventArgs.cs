using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace WPFTest
{
    class CustomEventArgs : RoutedEventArgs
    {
        public DateTime ClickTime { get; set; }

        public CustomEventArgs(RoutedEvent routedEvent, object source)
            : base(routedEvent, source) { }
    }

    class TimeButton : Button
    {
        public static readonly RoutedEvent ReportTimeEvent = EventManager.RegisterRoutedEvent("ReportTime",
            RoutingStrategy.Bubble, typeof(EventHandler<CustomEventArgs>), typeof(TimeButton));

        public event RoutedEventHandler ReportTime
        {
            add { this.AddHandler(ReportTimeEvent, value); }
            remove { this.RemoveHandler(ReportTimeEvent, value); }
        }

        protected override void OnClick()
        {
            base.OnClick();

            CustomEventArgs args = new CustomEventArgs(ReportTimeEvent,this);
            args.ClickTime = DateTime.Now;
            this.RaiseEvent(args);
        }
    }
}
