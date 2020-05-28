using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NewFeaturesTest.ComparerFeatures;
using static NewFeaturesTest.ClassFeatures;
using static NewFeaturesTest.QueryFeatures;

namespace NewFeaturesTest
{
    class Program
    {
        static void Main()
        {
            ArrayList product1 = ProductVersionOne.GetSomeProduct();
            product1.Sort(new ProductVersionOneComparer());
            foreach (var t in product1)
            {
                Console.WriteLine(t);
            }

            //generic no boxing
            List<ProductVersionTwo> product2 = ProductVersionTwo.GetSomeProduct();
            product2.Sort(new ProductVersionTwoComparer());
            foreach(var item in product2)
            {
                Console.WriteLine(item);
            }

            var product3 = ProductVersionThree.GetSomeProduct();
            //delegate version1 
            product3.Sort(delegate (ProductVersionThree x, ProductVersionThree y)
            {
                return x.Name.CompareTo(y.Name);
            });
            product3.Sort((x, y) => x.Name.CompareTo(y.Name));
            foreach(var p in product3)
            {
                Console.WriteLine(p);
            }

            var product4 = ProductVersionFour.GetSomeProduct();
            foreach(var p in product4.OrderBy(p=>p.Name))
            {
                Console.WriteLine(p);
            }

            //order not change 
            foreach(var p in product4)
            {
                Console.WriteLine(p);
            }

            QueryVersionOne();
            QueryVersionTwo();
        }
    }
}
