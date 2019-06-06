using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    class AttributeTest
    {
        [AttributeUsage(System.AttributeTargets.Class, Inherited=false)]
        class A1 : System.Attribute { }

        [AttributeUsage(System.AttributeTargets.Class)]
        class A2 : System.Attribute { }

        [AttributeUsage(System.AttributeTargets.Class, Inherited=true)]
        class A3 : System.Attribute { }

        [A1,A2]
        class BaseClass { }

        [A3,A2]
        class DerivedClass : BaseClass { }

        public void TestAttributeUsage ()
        {
            BaseClass b = new BaseClass();
            DerivedClass d = new DerivedClass();
            Console.WriteLine("Attriute on Base Class:");
            object[] attrs = b.GetType().GetCustomAttributes(true);
            foreach (Attribute attr in attrs)
                Console.WriteLine(attr);

            Console.WriteLine("Attribute on Derived Class:");
            attrs = d.GetType().GetCustomAttributes(true);
            foreach (Attribute attr in attrs)
                Console.WriteLine(attr);
        }


    }
}
