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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CommandTest
{
    /// <summary>
    /// Interaction logic for MiniView.xaml
    /// </summary>
    public partial class MiniView : UserControl,IView
    {
        public MiniView()
        {
            InitializeComponent();
        }

        public bool IsChanged { get; set; }
        public void SetBinding() { }
        public void Refresh() { }
        public void Save() { }

        public void Clear()
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
        }
    }
}
