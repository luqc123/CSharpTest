using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    class DelegateTest
    {
        public delegate void Print(string s);

        public static void Func1(string s)
        {
            Console.WriteLine(s);
        }

        public void Test()
        {
            Print print = Func1;
            print("hello,world");

        }
    }
}
