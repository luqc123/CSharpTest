﻿using System;
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

namespace WPFTest
{
    /// <summary>
    /// RoutedEventTest.xaml 的交互逻辑
    /// </summary>
    public partial class RoutedEventTest : Window
    {
        public RoutedEventTest()
        {
            InitializeComponent();
            this.gridRoot.AddHandler(Button.ClickEvent,new RoutedEventHandler(ButtonLeft_Click));
        }

        private void ButtonLeft_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((e.OriginalSource as FrameworkElement).Name);

        }
    }
}
