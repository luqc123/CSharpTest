using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ConsoleApplicationTest
{
    public class ExpressionTest
    {
        public static void Test()
        {
            Func<int, bool> delg = i => i < 5;
            Console.WriteLine("delg(4)={0}", delg(4));

            Expression<Func<int, bool>> expr = i => i < 5;
            Func<int, bool> f = expr.Compile();
            Console.WriteLine("f(4)={0}", f(4));

        }
    }
}
