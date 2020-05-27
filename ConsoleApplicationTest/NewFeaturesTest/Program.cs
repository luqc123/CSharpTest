using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NewFeaturesTest.ComparerFeatures;
using static NewFeaturesTest.ClassFeatures;

namespace NewFeaturesTest
{
    class Program
    {
        static void Main()
        {
            ArrayList product1 = ClassFeatures.ProductVersionOne.GetSomeProduct();
            product1.Sort(new ProductComparerVersionOne());
            foreach (var t in product1)
            {
                Console.WriteLine(t);
            }

            //generic no boxing
            List<ClassFeatures.ProductVersionTwo> product2 = ClassFeatures.ProductVersionTwo.GetSomeProduct();
            //product2.Sort(new ProductComparerVersionTwo());
            product2.Sort(delegate (ProductVersionTwo x, ProductVersionTwo y) { return x.Name.CompareTo(y.Name); });
            foreach(var item in product2)
            {
                Console.WriteLine(item);
            }

            var product3 = ClassFeatures.ProductVersionThree.GetSomeProduct();
            product3.Sort((x, y) => x.Name.CompareTo(y.Name));
            foreach(var p in product3)
            {
                Console.WriteLine(p);
            }

            var product4 = ClassFeatures.ProductVersionFour.GetSomeProduct();
            foreach(var p in product4.OrderBy(o=>o.Name))
            {
                Console.WriteLine(p);
            }
            foreach(var p in product4)
            {
                Console.WriteLine(p);
            }
        }
    }
}
