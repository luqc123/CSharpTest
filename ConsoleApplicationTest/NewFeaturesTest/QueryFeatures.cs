using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NewFeaturesTest.ClassFeatures;

namespace NewFeaturesTest
{
    public class QueryFeatures
    {
        //c# 1
        public static void QueryVersionOne() 
        {
            ArrayList products = ProductVersionOne.GetSomeProduct();
            foreach(ProductVersionOne p in products)
            {
                if (p.Price > 10m)
                    Console.WriteLine(p);
            }
        }
        //c# 2
        public static void QueryVersionTwo()
        {
            List<ProductVersionTwo> products = ProductVersionTwo.GetSomeProduct();
            Predicate<ProductVersionTwo> test = delegate (ProductVersionTwo p) { return p.Price > 10m; };
            List<ProductVersionTwo> matches = products.FindAll(test);
            Action<ProductVersionTwo> print = Console.WriteLine;
            matches.ForEach(print);
        }

        //c# 3
        public static void QueryVersionThree()
        {
            var products = ProductVersionThree.GetSomeProduct();
            foreach(var p in products.Where(x=>x.Price>10m))
            {
                Console.WriteLine(p);
            }
        }
    }
}
