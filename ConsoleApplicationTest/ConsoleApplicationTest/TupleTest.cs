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

        public static void Test2()
        {
            Func<int,Tuple<bool,long,string,double>> f = new Func<int, Tuple<bool, long, string, double>>(i=>{
                if (i % 2 == 1)
                    return new Tuple<bool, long, string, double>(true, 1, "1", 1.0);
                else
                    return new Tuple<bool, long, string, double>(false, 0, "0", 0);
            });

            var r = f(1);
            var p = f(2);
            Console.WriteLine(r);
            Console.WriteLine(p);
        }
    }
}
