using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    public class LinqTest
    {
        public static void Test1()
        {
            List<int> lst = new List<int> { 1, 2, 3, 4,5,6,7,8,9 };
            // capacity and count 
            Console.WriteLine("list<int> capacity is {0}", lst.Capacity); //16
            Console.WriteLine("list<int> count is {0}", lst.Count);//9

            IEnumerable<int> query = lst.Where(x => x % 2 == 0);
            Console.WriteLine(query.FirstOrDefault());//2
            Console.WriteLine(query.Count());//4

            Console.WriteLine(lst.Any());//true
            lst.RemoveAll(x => x % 2 == 0);
            Console.WriteLine(lst.Count);//5
            Console.WriteLine(lst.Capacity);//16
            Console.WriteLine(lst.Contains(8));//False
            Console.WriteLine(lst.IndexOf(8));
            Console.WriteLine(lst.IndexOf(9));
            Console.WriteLine(lst[4]);//9
            lst.AddRange(lst);
            foreach (var item in lst)
                Console.WriteLine(item);
            foreach (var item in lst.Distinct())
                Console.WriteLine(item);
        }
    }
}
