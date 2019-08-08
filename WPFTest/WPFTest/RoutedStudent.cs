using System;
using System.Windows;
using System.Windows.Input;

namespace WPFTest
{
    class RoutedStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static readonly RoutedEvent NameChangedEvent = EventManager.RegisterRoutedEvent("NameChanged",
            RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RoutedStudent));
        
        public static void AddNameChangedHandler(DependencyObject d, RoutedEventHandler h)
        {
            UIElement e = d as UIElement;
            if (e!=null)
            {
                e.AddHandler(RoutedStudent.NameChangedEvent, h);
            }
        }

        public static void RemoveNameChangedHandler(DependencyObject d, RoutedEventHandler h)
        {
            UIElement e = d as UIElement;
            if(e!=null)
            {
                e.RemoveHandler(RoutedStudent.NameChangedEvent, h);
            }

        }
    }
}
