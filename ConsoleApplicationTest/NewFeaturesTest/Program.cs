using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NewFeaturesTest.ComparerFeatures;
using static NewFeaturesTest.ClassFeatures;
<<<<<<< HEAD
using static NewFeaturesTest.QueryFeatures;
=======
>>>>>>> aac4832a7634678ab87a600435d0c27144fa805f

namespace NewFeaturesTest
{
    class Program
    {
        static void Main()
        {
<<<<<<< HEAD
            ArrayList product1 = ProductVersionOne.GetSomeProduct();
            product1.Sort(new ProductVersionOneComparer());
=======
            ArrayList product1 = ClassFeatures.ProductVersionOne.GetSomeProduct();
            product1.Sort(new ProductComparerVersionOne());
>>>>>>> aac4832a7634678ab87a600435d0c27144fa805f
            foreach (var t in product1)
            {
                Console.WriteLine(t);
            }

            //generic no boxing
<<<<<<< HEAD
            List<ProductVersionTwo> product2 = ProductVersionTwo.GetSomeProduct();
            product2.Sort(new ProductVersionTwoComparer());
=======
            List<ClassFeatures.ProductVersionTwo> product2 = ClassFeatures.ProductVersionTwo.GetSomeProduct();
            //product2.Sort(new ProductComparerVersionTwo());
            product2.Sort(delegate (ProductVersionTwo x, ProductVersionTwo y) { return x.Name.CompareTo(y.Name); });
>>>>>>> aac4832a7634678ab87a600435d0c27144fa805f
            foreach(var item in product2)
            {
                Console.WriteLine(item);
            }

<<<<<<< HEAD
            var product3 = ProductVersionThree.GetSomeProduct();
            //delegate version1 
            product3.Sort(delegate (ProductVersionThree x, ProductVersionThree y)
            {
                return x.Name.CompareTo(y.Name);
            });
=======
            var product3 = ClassFeatures.ProductVersionThree.GetSomeProduct();
>>>>>>> aac4832a7634678ab87a600435d0c27144fa805f
            product3.Sort((x, y) => x.Name.CompareTo(y.Name));
            foreach(var p in product3)
            {
                Console.WriteLine(p);
            }

<<<<<<< HEAD
            var product4 = ProductVersionFour.GetSomeProduct();
            foreach(var p in product4.OrderBy(p=>p.Name))
            {
                Console.WriteLine(p);
            }

            //order not change 
=======
            var product4 = ClassFeatures.ProductVersionFour.GetSomeProduct();
            foreach(var p in product4.OrderBy(o=>o.Name))
            {
                Console.WriteLine(p);
            }
>>>>>>> aac4832a7634678ab87a600435d0c27144fa805f
            foreach(var p in product4)
            {
                Console.WriteLine(p);
            }

            QueryVersionOne();
            QueryVersionTwo();
        }
    }
}
