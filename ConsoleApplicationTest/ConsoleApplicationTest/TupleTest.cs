using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    public class TupleTest
    {
        public static void Test1()
        {
            Tuple<int> iTpl = new Tuple<int>(1);
            Console.WriteLine(iTpl.Item1);
            Tuple<int, int> iTpl2 = new Tuple<int, int>(2, 3);
            Console.WriteLine(iTpl2.Item1 + " " + iTpl2.Item2);
            Tuple<int, int> t = iTpl2;
            Console.WriteLine(t);
        }
    }
}
