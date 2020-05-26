using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeaturesTest
{
    public class ClassFeatures
    {
        public class ProductVersionOne
        {
            string name;
            public string Name { get { return name; } }

            public decimal price;
            public decimal Price { get { return price; } }

            public ProductVersionOne(string name,decimal price)
            {
                this.name = name;
                this.price = price;
            }
            public static ArrayList GetSomeProduct()
            {
                ArrayList list = new ArrayList();
                list.Add(new ProductVersionOne("banana", 1.1m));
                list.Add(new ProductVersionOne("computer", 1234m));
                list.Add(new ProductVersionOne("apple", 1.2m));
                //no error 
                //list.Add("banana");
                return list;
            }
            public override string ToString()
            {
                return string.Format("{0}-{1}", Name, Price);
            }
        }

        public class ProductVersionTwo
        {
            private string name;
            public string Name
            {
                get { return name; }
                private set { name = value; }
            }

            private decimal price;
            public decimal Price
            {
                get { return price; }
                private set { price = value; }
            }

            //c# 2 generic
            public ProductVersionTwo(string name,decimal price)
            {
                Name = name;
                Price = price;
            }

            public static List<ProductVersionTwo> GetSomeProduct()
            {
                List<ProductVersionTwo> list = new List<ProductVersionTwo>();
                list.Add(new ProductVersionTwo("banana", 1.1m));
                list.Add(new ProductVersionTwo("computer", 1234m));
                list.Add(new ProductVersionTwo("apple", 1.2m));
                //error 
                //list.Add("banana");
                return list;
            }

            public override string ToString()
            {
                return string.Format("{0}-{1}", Name, Price);
            }
        }

        //c# 3
        public class ProductVersionThree
        {
            //auto property
            public string Name { get; private set; }
            public decimal Price { get; private set; }

            public ProductVersionThree(string name,decimal price)
            {
                Name = name;
                Price = price;
            }

            public ProductVersionThree() { }

            public static List<ProductVersionThree> GetSomeProduct()
            {
                return new List<ProductVersionThree>
                {
                    new ProductVersionThree{Name="banana",Price=1.1m},
                    new ProductVersionThree{Name="computer",Price=1234m},
                    new ProductVersionThree{Name="apple",Price=1.2m}
                };
            }

            public override string ToString()
            {
                return string.Format($"{Name}-{Price}");
            }
        }

        //c# 4
        public class ProductVersionFour
        {
            readonly string name;
            public string Name { get { return name; } } 
            readonly decimal price;
            public decimal Price { get { return price; } }

            public ProductVersionFour(string name, decimal price)
            {
                this.name = name;
                this.price = price;
            }

            public ProductVersionFour() { }

            public static List<ProductVersionFour> GetSomeProduct()
            {
                return new List<ProductVersionFour>
                {
                    new ProductVersionFour(name:"banana",price:1.1m),
                    new ProductVersionFour(name:"computer",price:1234m),
                    new ProductVersionFour(name:"apple",price:1.2m)
                };
            }

            public override string ToString()
            {
                return string.Format($"{Name}-{Price}");
            }
        }
    }
}
