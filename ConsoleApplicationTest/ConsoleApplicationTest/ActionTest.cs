using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    class ActionTest
    {
        public Action<Int32> Action1;
        public Action<Int32, String> Action2;
        public Func<bool> Func1;
        public Func<String[], Int32, String> Func2;

        public ActionTest()
        {
            Action1 = (i) => Console.WriteLine("Action<Int32> test : Print Int32 {0}", i);
            Action2 = (i, s) => Console.WriteLine("Action<Int32,String> test : Print Int32 {0}, String {1}", i, s);
            Func1 = delegate() { return true; };
            Func2 = (s, i) => s[i];
        }

        public void Test()
        {
            Action1(1);
            Action2(1, "hello,world");
            Console.WriteLine("{0}", Func1() == true ? "True" : "False");
            Console.WriteLine("{0}", Func2(new String[] { "hello", "world" },0));
        }
        
        
    }
}
