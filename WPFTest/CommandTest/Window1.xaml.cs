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

namespace CommandTest
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        { 
            InitializeComponent();
            InitialCommand();
        }

        private RoutedCommand clearCommand = new RoutedCommand("ClearCommand", typeof(Window1));

        private void InitialCommand()
        {
            this.clearCommand.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Alt));
            //command source
            this.button.Command = this.clearCommand;
            //command target
            this.button.CommandTarget = this.textBox;

            //command binding
            CommandBinding cb = new CommandBinding();
            cb.Command = this.clearCommand;
            cb.CanExecute += new CanExecuteRoutedEventHandler(cb_CanExecute);
            cb.Executed += new ExecutedRoutedEventHandler(cb_Executed);

            this.window1.CommandBindings.Add(cb);
        }

        void cb_CanExecute(object sender,CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text))
                e.CanExecute = false;
            else
            {
                e.CanExecute = true;
                e.Handled = true;
            }    
        }

        void cb_Executed(object sender,ExecutedRoutedEventArgs e)
        {
            this.textBox.Clear();
            e.Handled = true;
        }
    }
}
