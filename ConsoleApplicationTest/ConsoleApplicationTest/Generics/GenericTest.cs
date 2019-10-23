using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest.Generics
{
    public static class GenericTest
    {
        public static void Main()
        {
            //GenericArray();
            Performance.ReferenceTypePerfTest();
            Performance.ValueTypePerfTest();
        }

        private static void GenericArray()
        {
            Byte[] byteArray = new Byte[] { 5, 2, 3, 1, 6 };
            //generic method
            Array.Sort<Byte>(byteArray);
            Int32 i = Array.BinarySearch<Byte>(byteArray, 5);
            Console.WriteLine(i);
        }
    }

    internal static class Performance
    {
        public static void ReferenceTypePerfTest()
        {
            const Int32 count = 100000000;
            using(new OperationTimer("List<string>"))
            {
                List<String> l = new List<string>();
                for(Int32 n = 0; n < count; n++)
                {
                    l.Add("x"); //Reference copy
                    String x = l[n]; //Reference copy
                }
                l = null;
            }

            using (new OperationTimer("ArrayList of String"))
            {
                ArrayList s = new ArrayList();
                for(Int32 n = 0; n < count; n++)
                {
                    s.Add("x");//Reference copy
                    String x = (String)s[n]; //Cast and Reference Copy
                }
                s = null;
            }
        }

        public static void ValueTypePerfTest()
        {
            const Int32 count = 100000000;
            using (new OperationTimer("List<Int32>"))
            {
                List<Int32> l = new List<Int32>();
                for(Int32 n = 0; n < count; n++)
                {
                    l.Add(n); //no boxing
                    Int32 x = l[n]; //no boxing
                }
                l = null;
            }
            using (new OperationTimer("ArrayList of Int32"))
            {
                ArrayList a = new ArrayList();
                for(Int32 n = 0; n < count; n++)
                {
                    a.Add(n); //boxing
                    Int32 x = (Int32)a[n]; //unboxing
                }
                a = null;
            }
        }
    }

    sealed class OperationTimer : IDisposable
    {
        private Stopwatch stopwatch;
        private String text;
        private Int32 collectionCount;

        public OperationTimer(String text)
        {
            PrepareForOperation();
            this.text = text;
            collectionCount = GC.CollectionCount(0);
            stopwatch = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            Console.WriteLine("{0} (GCs={1,3}) {2}",
                stopwatch.Elapsed, GC.CollectionCount(0) - collectionCount, text); 
        }

        private static void PrepareForOperation()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }

}
