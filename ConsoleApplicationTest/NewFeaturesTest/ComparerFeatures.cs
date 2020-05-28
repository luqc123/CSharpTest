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
        public class ProductVersionOneComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                ProductVersionOne one = (ProductVersionOne)x;
                ProductVersionOne two = (ProductVersionOne)y;
                return one.Name.CompareTo(two.Name);
            }
        }

        public class ProductVersionTwoComparer : IComparer<ProductVersionTwo>
        {
            public int Compare(ProductVersionTwo x, ProductVersionTwo y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }
    }
}
