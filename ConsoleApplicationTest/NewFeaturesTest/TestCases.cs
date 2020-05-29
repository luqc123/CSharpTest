using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NewFeaturesTest.ClassFeatures;
using static NewFeaturesTest.ComparerFeatures;
using static NewFeaturesTest.QueryFeatures;
using Product = NewFeaturesTest.ClassFeatures.ProductVersionFour;

namespace NewFeaturesTest
{
    public class TestCases
    {
        public static void Run()
        {
            //TestClassFeatures();
            //TestQueryFeatures();
            //TestNullable();
            TestLinq();
        }

        //c# 3
        public static void TestLinq()
        {
            List<Product> products = Product.GetSomeProduct();
            var filtered = from Product p in products
                           where p.Price > 10
                           select p;
            foreach (var p in filtered)
                Console.WriteLine(p);
        }

        public static void TestClassFeatures()
        {
            ArrayList product1 = ProductVersionOne.GetSomeProduct();
            product1.Sort(new ProductComparerVersionOne());
            foreach (var t in product1)
            {
                Console.WriteLine(t);
            }

            //generic no boxing
            List<ProductVersionTwo> product2 = ProductVersionTwo.GetSomeProduct();
            //product2.Sort(new ProductComparerVersionTwo());
            product2.Sort(delegate (ProductVersionTwo x, ProductVersionTwo y) { return x.Name.CompareTo(y.Name); });
            foreach (var item in product2)
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
            foreach (var p in product3)
            {
                Console.WriteLine(p);
            }

            var product4 = ProductVersionFour.GetSomeProduct();
            foreach (var p in product4.OrderBy(p => p.Name))
            {
                Console.WriteLine(p);
            }

            foreach (var p in product4)
            {
                Console.WriteLine(p);
            }
        }
        public static void TestQueryFeatures()
        {
            QueryVersionOne();
            QueryVersionTwo();
            QueryVersionThree();
        }

        public static void TestNullable()
        {
            List<Test> tests = new List<Test>();

            tests.Add(new Test());
            tests.Add(new Test());
            tests.Add(new Test(1.1m));

            //c# 2
            tests.FindAll(delegate (Test t) { return t.Price == null; }).ForEach(Console.WriteLine);
            //c# 3
            foreach (var t in tests.Where(x => x.Price == null))
                Console.WriteLine(t.ToString());
            foreach (var t in tests.Where(x => x.Price.HasValue))
                Console.WriteLine(t.Price);
        }

        class Test
        {
            private decimal? price;
            public decimal? Price { get { return price; } set { this.Price = value; } }

            //c# 4
            public Test(decimal? p = null) { this.Price = p; }

            public Test() { }
            public Test(decimal p) { this.Price = p; }

            public override string ToString()
            {
                if (Price.HasValue)
                    return string.Format($"{Price}");
                else
                    return "null value.";
            }
        }
    }
}
