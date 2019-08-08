using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace CommandTest
{
    class MyCommandSource : UserControl,ICommandSource
    {
        public ICommand Command { get; set; }
        public object CommandParameter { get; set; }
        public IInputElement CommandTarget { get; set; }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            if(this.CommandTarget != null)
            {
                this.Command.Execute(this.CommandTarget);
            }
        }
    }
}
