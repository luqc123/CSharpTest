using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime;

namespace ConsoleApplicationTest
{
    public class DisposableTest 
    {
        public static void Main()
        {
            //MyClass myClass = new MyClass("MyClass");
            //Timer t = new Timer(TimerCallback, null, 0, 2000);
            //Console.ReadLine();
            //t.Dispose();
            Console.WriteLine(GC.MaxGeneration);
            Console.WriteLine("Application is running with server GC=" + GCSettings.IsServerGC);
            Console.WriteLine("Application is running with server GCMode=" +
                GCSettings.LatencyMode);
        }

        private static void TimerCallback(object o)
        {
            Console.WriteLine("In TimerCallback: " + DateTime.Now);
            GC.Collect();
        }
    }

    public sealed class MyClass
    {
        public string Name { get; set; }
        public MyClass(string name)
        {
            Name = name;
        }

        ~MyClass()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Delete Myclass...");
        }
    }
}
