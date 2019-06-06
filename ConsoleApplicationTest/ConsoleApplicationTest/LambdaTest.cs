using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    class LambdaTest
    {
        
        delegate void TestDelegate(string s);

        void M(string s)
        {
            Console.WriteLine(s);
        }

        public void Test()
        {
            //c#1.0
            TestDelegate testDelA = new TestDelegate(M);
            testDelA("Hello,My first Test...");
            //c#2.0
            TestDelegate testDelB = delegate(string s) { Console.WriteLine(s); };
            testDelB("Hello,this is anonymous method...");
            //c#3.0
            // with lambda expression
            TestDelegate testDelC = (x) => { Console.WriteLine(x); };
            testDelC("Hello,this is lambda test...");

        }


    }
}
