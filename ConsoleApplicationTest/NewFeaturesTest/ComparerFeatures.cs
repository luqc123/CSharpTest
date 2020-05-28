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
<<<<<<< HEAD
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
=======
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
>>>>>>> aac4832a7634678ab87a600435d0c27144fa805f
        {
            public int Compare(ProductVersionTwo x, ProductVersionTwo y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }
    }
}
