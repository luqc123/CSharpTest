using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeaturesTest
{
    class Program
    {
        static void Main()
        {
            ArrayList product1 = ClassFeatures.ProductVersionOne.GetSomeProduct();
            foreach (var t in product1)
            {
                Console.WriteLine(t);
            }

            //generic no boxing
            List<ClassFeatures.ProductVersionTwo> product2 = ClassFeatures.ProductVersionTwo.GetSomeProduct();
            foreach(var item in product2)
            {
                Console.WriteLine(item);
            }

            var product3 = ClassFeatures.ProductVersionThree.GetSomeProduct();
            foreach(var p in product3)
            {
                Console.WriteLine(p);
            }

            var product4 = ClassFeatures.ProductVersionFour.GetSomeProduct();
            foreach(var p in product4)
            {
                Console.WriteLine(p);
            }
        }
    }
}
