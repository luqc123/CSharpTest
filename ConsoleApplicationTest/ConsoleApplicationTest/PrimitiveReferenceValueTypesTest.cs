using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Linq;
using Microsoft.CSharp.RuntimeBinder;

namespace ConsoleApplicationTest
{
    public static class PrimitiveReferenceValueTypesTest
    {
        public static void Main()
        {
            //PrimitiveDemo();
            //BoxingDemo();
            ReferenceVsValue.Go();
        }
        private static void PrimitiveDemo()
        {
            int a = new int();
            int b = 0;
            Int32 c = new Int32();
            Int32 d = 0;

            Console.WriteLine("a={0},b={1},c={2},d={3}", new object[] { a, b, c, d });
            a = b = c = d = 5;
            Console.WriteLine("a={0},b={1},c={2},d={3}", new object[] { a, b, c, d });
        }
        private static void BoxingDemo()
        {
            Int32 a = 5;
            Object o = a;
            a = 123;
            //123,5
            Console.WriteLine(a + "," + (Int32)o);
            Console.WriteLine(a + "," + o);//better no unboxing
        }
    }

    internal static class ReferenceVsValue
    {
        private class SomeRef { public Int32 x; }
        private struct SomeVal { public Int32 x; }

        public static void Go()
        {
            SomeRef r1 = new SomeRef();
            SomeVal v1 = new SomeVal();
            r1.x = 5;
            v1.x = 5;

            SomeRef r2 = r1;
            SomeVal v2 = v1;

            r2.x = 8;
            v2.x = 8;

            Console.WriteLine("r1.x={0}", r1.x);
            Console.WriteLine("r2.x={0}", r2.x);
            Console.WriteLine("v1.x={0}", v1.x);
            Console.WriteLine("v2.x={0}", v2.x);
        }
    }
}
