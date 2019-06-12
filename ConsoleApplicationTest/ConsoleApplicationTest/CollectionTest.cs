using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ConsoleApplicationTest
{
    class CollectionTest
    {
        public void ObservableCollectionTest()
        {
            var data = new ObservableCollection<string>();
            data.CollectionChanged += Data_CollectionChanged;
            data.Add("One");
            data.Add("Two");
            data.Insert(1, "Three");
            data.Remove("Two");
        }

        public void Data_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("action:{0}", e.Action.ToString());
            if (e.OldItems != null)
            {
                Console.WriteLine("old items start at {0}", e.OldStartingIndex);
                foreach (var item in e.OldItems)
                {
                    Console.WriteLine(item);
                }
            }

            if (e.NewItems != null)
            {
                Console.WriteLine("new items start at {0}", e.NewStartingIndex);
                foreach (var item in e.NewItems)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}