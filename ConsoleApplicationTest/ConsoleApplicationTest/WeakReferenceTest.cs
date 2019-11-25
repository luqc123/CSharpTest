using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    public class WeakReferenceTest
    {
        public static void Main()
        {
            WeakReference dataReference = new WeakReference(new Data(100));
            Data d;
            if(dataReference.IsAlive)
            {
                d = dataReference.Target as Data;
                Console.WriteLine(d.Size());
                Console.WriteLine(d.Count);
            }
            else
            {
                Console.WriteLine("Reference is not available");
            }

            GC.Collect();

            if (dataReference.IsAlive)
                d = dataReference.Target as Data;
            else
                Console.WriteLine("Reference is not available");
        }
    }

    public class Data
    {
        List<int> lst;
        int size;

        public Data(int size)
        {
            lst = new List<int>(size);
            for (int i = 0; i < size; i++)
                lst.Add(i);
        }

        public int Size()
        {
            return lst.Count();
        }

        public int Count
        {
            get
            {
                return lst.Count;
            }
        }
    }
}
