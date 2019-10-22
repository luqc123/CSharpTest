using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    public class HashSetTest
    {
        public static void Test1()
        {
            HashSet<string> StopPriceConstSet = new HashSet<string>() { "SPO", "SLS", "SPA", "SLA" };
            Console.WriteLine(StopPriceConstSet.Count);
            StopPriceConstSet.Add("Other");
            Console.WriteLine(StopPriceConstSet.Count);
            StopPriceConstSet.Contains("Other");
            StopPriceConstSet.UnionWith(new List<String>() { "hello", "world" });
            Console.WriteLine(StopPriceConstSet.Count);
            Console.WriteLine(StopPriceConstSet);
        }

        public static void Test2()
        {

        }
    }
}
