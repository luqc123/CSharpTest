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
    /// Interaction logic for CustomCommandTest.xaml
    /// </summary>
    public partial class CustomCommandTest : Window
    {
        public CustomCommandTest()
        {
            InitializeComponent();

            ClearCommand clearCmd = new ClearCommand();
            this.ctrclear.Command = clearCmd;
            this.ctrclear.CommandTarget = this.miniView;
        }
    }
}
