using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using StoreDatabase;

namespace DataBindingTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static StoreDb StoreDb { get; } = new StoreDb();

        public static StoreDbDataSet GetStoreDbDataSet { get; } = new StoreDbDataSet();
    }
}
