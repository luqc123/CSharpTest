using System.Windows;
using System.Windows.Input;
using System;

namespace CommandTest
{
    /// <summary>
    /// Interaction logic for CommandTest1.xaml
    /// </summary>
    public partial class CommandTest1 : Window
    {
        public CommandTest1()
        {
            InitializeComponent();
            InitializeClearCommand();
            InitializeRecoverCommand();
        }

        //save result
        public string Result { get; set; }

        private RoutedCommand recoverCmd = new RoutedCommand("Recover", typeof(CommandTest1));
        private RoutedCommand clearCmd = new RoutedCommand("Clear", typeof(CommandTest1));

        private void InitializeClearCommand()
        {
            this.button.Command = clearCmd;
            this.clearCmd.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Alt));

            this.button.CommandTarget = this.textBoxA;

            CommandBinding cb = new CommandBinding();
            cb.Command = this.clearCmd;
            cb.CanExecute += new CanExecuteRoutedEventHandler(Cb_CanExecute);
            cb.Executed += new ExecutedRoutedEventHandler(Cb_Executed);

            //this.stackPanel.CommandBindings.Add(cb);
            this.button1.CommandBindings.Add(cb);
            this.stackPanel.CommandBindings.Add(cb);
        }

        private void InitializeRecoverCommand()
        {
            this.button1.Command = recoverCmd;

            this.button1.CommandTarget = this.textBoxA;

            CommandBinding cb = new CommandBinding();
            cb.Command = recoverCmd;
            cb.CanExecute += new CanExecuteRoutedEventHandler(Cb_CanExecute1);
            cb.Executed += new ExecutedRoutedEventHandler(Cb_Executed1);

            this.window1.CommandBindings.Add(cb);
        }

        private void Cb_Executed1(object sender, ExecutedRoutedEventArgs e)
        {
            this.textBoxA.Text = Result;
            e.Handled = true;
        }

        private void Cb_CanExecute1(object sender, CanExecuteRoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(Result))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }

            e.Handled = true;
        }

        private void Cb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Result = String.Copy(textBoxA.Text);
            this.textBoxA.Clear();
            e.Handled = true;
        }

        private void Cb_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(this.textBoxA.Text))
            { e.CanExecute = false; }
            else
            { e.CanExecute = true; }

            e.Handled = true;
        }
    }
}
