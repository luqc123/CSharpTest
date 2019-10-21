using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    public class DictionaryTest
    {
        public static void Test1()
        {
            Dictionary<String, int> si = new Dictionary<string, int>();
            si.Add("one", 1);
            si.Add("two", 2);
            si.Add("three", 3);
            Console.WriteLine(si);
            Console.WriteLine(si.Keys);
            Console.WriteLine(si.Values);
            Console.WriteLine(si.Count);
            Console.WriteLine(si.FirstOrDefault());
            Console.WriteLine(si.ContainsKey("four"));
            Console.WriteLine(si.ContainsValue(4));
            int r;
            si.TryGetValue("four", out r);
            Console.WriteLine(r);
            // can not add same key 
            //si.Add("three", 33);
            foreach(var item in si)
            {
                Console.WriteLine("({0}-{1})", item.Key, item.Value);
            }
        }
    }
}
