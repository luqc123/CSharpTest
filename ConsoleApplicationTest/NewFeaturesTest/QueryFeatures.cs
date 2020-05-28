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
        public static void QueryVersionOne() 
        {
            ArrayList products = ProductVersionOne.GetSomeProduct();
            foreach(ProductVersionOne p in products)
            {
                if (p.Price > 10m)
                    Console.WriteLine(p);
            }
        }
        public static void QueryVersionTwo()
        {
            List<ProductVersionTwo> products = ProductVersionTwo.GetSomeProduct();
            Predicate<ProductVersionTwo> test = delegate (ProductVersionTwo p) { return p.Price > 10m; };
            List<ProductVersionTwo> matches = products.FindAll(test);
            Action<ProductVersionTwo> print = Console.WriteLine;
            matches.ForEach(print);
        }

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
