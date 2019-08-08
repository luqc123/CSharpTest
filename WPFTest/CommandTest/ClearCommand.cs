using System;
using System.Windows;
using System.Windows.Input;

namespace CommandTest
{
    class ClearCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            IView view = parameter as IView;
            if(view != null)
            {
                view.Clear();
            }
        }
    }
}
