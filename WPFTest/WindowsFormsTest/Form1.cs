using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WindowsFormsTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Add("add something to listbox1");
            listBox1.Items.Add("add something to listbox1 too");
            listBox1.Items.AddRange(new String[] { "One", "Two", "Three" });
            listBox1.Items.Insert(2, "this item will be third");
            int anIndex;
            anIndex = listBox1.Items.IndexOf("Two");
            listBox1.SelectedIndex = anIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button clicked.");
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            switch(e.Button)
            {
                case MouseButtons.Left:
                    MessageBox.Show("Left button click.");
                    break;
                case MouseButtons.Right:
                    MessageBox.Show("Right button click.");
                    break;
                default:
                    MessageBox.Show("button click.");
                    break;
            }
        }
    }
}
