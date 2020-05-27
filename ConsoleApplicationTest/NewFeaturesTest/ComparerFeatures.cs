using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NewFeaturesTest.ClassFeatures;

namespace NewFeaturesTest
{
    public class ComparerFeatures
    {
        //c# 1 
        public class ProductComparerVersionOne : IComparer
        {
            public int Compare(object x, object y)
            {
                ProductVersionOne p1 = (ProductVersionOne)x;
                ProductVersionOne p2 = (ProductVersionOne)y;
                return p1.Name.CompareTo(p2.Name);
            }
        }

        //c# 2 generic
        public class ProductComparerVersionTwo : IComparer<ProductVersionTwo>
        {
            public int Compare(ProductVersionTwo x, ProductVersionTwo y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }
    }
}
