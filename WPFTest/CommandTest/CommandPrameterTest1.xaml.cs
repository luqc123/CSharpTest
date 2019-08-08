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
    /// Interaction logic for CommandPrameterTest1.xaml
    /// </summary>
    public partial class CommandPrameterTest1 : Window
    {
        public CommandPrameterTest1()
        {
            InitializeComponent();
        }

        private void New_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(this.nameTextBox.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }

        private void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string name = this.nameTextBox.Text;
            if(e.Parameter as string == "Teacher")
            {
                this.listBoxNewItems.Items.Add(string.Format("New Teacher:{0} 学而不厌，诲人不倦", name));
            }
            if(e.Parameter as string == "Student")
            {
                this.listBoxNewItems.Items.Add(string.Format("New Student:{0} 好好学习，天天向上", name));
            }
        }
    }
}
