using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    public sealed class ClassTest
    {
        public static void Main()
        {
            Object o = new object();
            Console.WriteLine(o);
            Console.WriteLine("this is a static method.");
            Console.WriteLine("this is a virtual method GetHashCode() called:{0}",o.GetHashCode());
            Console.WriteLine("this is a non virtual method GetType() called:{0}",o.GetType());
            string s = new string("hello".ToCharArray());
            o = s;
            Console.WriteLine(o);
            Console.WriteLine("this is a static method.");
            Console.WriteLine("this is a virtual method GetHashCode() called:{0}",o.GetHashCode());
            Console.WriteLine("this is a non virtual method GetType() called:{0}",o.GetType());
            Point p = new Point(3, 4);
            Console.WriteLine(p);

            CompanyA.BetterPhone b = new CompanyA.BetterPhone();
            b.Dial();

            A a = new A();
            a.Func();
            a = new B();
            a.Func();
            a = new C();
            a.Func();
        }
    }

    public class SomeClass
    {
        public override string ToString()
        {
            // call non't callvirt
            return base.ToString();
        }
    }

    public sealed class Point
    {
        private Int32 _x, _y;
        public Point(Int32 x, Int32 y) { _x = x; _y = y; }

        public override string ToString()
        {
            return String.Format("x={0},y={1}", _x, _y);
        }
    }

    public class A
    {
        public virtual void Func()
        {
            Console.WriteLine("A:Func");
        }
    }

    public class B : A
    {
        public override void Func()
        {
            Console.WriteLine("B:Func");
        }
    }

    public class C:B
    {
        public override void Func()
        {
            Console.WriteLine("C:Func");
        }
    }

    namespace CompanyA
    {
        public class Phone
        {
            public void Dial()
            {
                Console.WriteLine("Phone,Dial");
            }

        }

        public class BetterPhone : Phone
        {
            public new void Dial()
            {
                Console.WriteLine("BetterPhone.Dial");
                EstablishConnection();
                base.Dial();
            }
            protected virtual void EstablishConnection()
            {
                Console.WriteLine("BetterPhone.EstablishConnection");
            }
        }
    }
}
