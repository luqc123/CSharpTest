﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D = System.Collections.Generic.List<System.DateTime>;

namespace ConsoleApplicationTest.Generics
{
    public static class GenericTest
    {
        public static void Main()
        {
            //GenericArray();
            //Performance.ReferenceTypePerfTest();
            //Performance.ValueTypePerfTest();
            //OpenTypes.Go();
            //GenericInheritance.Go();
            //VariantTest.Test1();
            //VariantTest.Test2();
            //SwapTest.Test1();
            //SwapTest.Test2();
            //SwapTest.Test3();
            //SwapTest.Test4();
            //WhereTest.Test1();
            //WhereTest.Test2();
            //WhereTest.Test3();
            WhereTest.Test4();
        }

        private static void GenericArray()
        {
            Byte[] byteArray = new Byte[] { 5, 2, 3, 1, 6 };
            //generic method
            Array.Sort<Byte>(byteArray);
            Int32 i = Array.BinarySearch<Byte>(byteArray, 5);
            Console.WriteLine(i);
        }
    }

    internal static class Performance
    {
        public static void ReferenceTypePerfTest()
        {
            const Int32 count = 100000000;
            using (new OperationTimer("List<string>"))
            {
                List<String> l = new List<string>();
                for (Int32 n = 0; n < count; n++)
                {
                    l.Add("x"); //Reference copy
                    String x = l[n]; //Reference copy
                }
                l = null;
            }

            using (new OperationTimer("ArrayList of String"))
            {
                ArrayList s = new ArrayList();
                for (Int32 n = 0; n < count; n++)
                {
                    s.Add("x");//Reference copy
                    String x = (String)s[n]; //Cast and Reference Copy
                }
                s = null;
            }
        }

        public static void ValueTypePerfTest()
        {
            const Int32 count = 100000000;
            using (new OperationTimer("List<Int32>"))
            {
                List<Int32> l = new List<Int32>();
                for (Int32 n = 0; n < count; n++)
                {
                    l.Add(n); //no boxing
                    Int32 x = l[n]; //no boxing
                }
                l = null;
            }
            using (new OperationTimer("ArrayList of Int32"))
            {
                ArrayList a = new ArrayList();
                for (Int32 n = 0; n < count; n++)
                {
                    a.Add(n); //boxing
                    Int32 x = (Int32)a[n]; //unboxing
                }
                a = null;
            }
        }
    }

    sealed class OperationTimer : IDisposable
    {
        private Stopwatch stopwatch;
        private String text;
        private Int32 collectionCount;

        public OperationTimer(String text)
        {
            PrepareForOperation();
            this.text = text;
            collectionCount = GC.CollectionCount(0);
            stopwatch = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            Console.WriteLine("{0} (GCs={1,3}) {2}",
                stopwatch.Elapsed, GC.CollectionCount(0) - collectionCount, text);
        }

        private static void PrepareForOperation()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }

    internal static class OpenTypes
    {
        public static void Go()
        {
            Object o = null;
            Type t = typeof(Dictionary<,>);
            o = CreateInstance(t);
            Console.WriteLine();
            t = typeof(Dictionary<int, long>);
            o = CreateInstance(t);
            Console.WriteLine("object's type is : {0}", o.GetType());
            Console.WriteLine("classs's type is : {0}", typeof(Dictionary<int, long>));
            Console.WriteLine("classs's type is : {0}", typeof(Object));
            t = typeof(DictionaryStringKey<Guid>);
            o = CreateInstance(t);
            Console.WriteLine("object's type is : {0}", o.GetType());
            t = typeof(DictionaryStringKey<>);
            o = CreateInstance(t);
            t = typeof(GenericTypeThatRequiresAnEnum<int>);
            o = CreateInstance(t);
        }

        private static Object CreateInstance(Type t)
        {
            Object o = null;
            try
            {
                o = Activator.CreateInstance(t);
                Console.WriteLine("create instance : {0}", o.ToString());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            return o;
        }

        internal sealed class DictionaryStringKey<TValue> : Dictionary<String, TValue>
        {
        }

        internal sealed class GenericTypeThatRequiresAnEnum<T>
        {
            static GenericTypeThatRequiresAnEnum()
            {
                if (!typeof(T).IsEnum)
                {
                    throw new ArgumentException("T must be a enum type");
                }
            }
        }
    }


    internal static class GenericInheritance
    {
        public static void Go()
        {
            //SameDataLinkedList();
            //DifferentDataLinkedList();
            TypeTest();
        }
        private static void SameDataLinkedList()
        {
            Node<Char> head = new Node<char>('C');
            head = new Node<char>('B', head);
            head = new Node<char>('A', head);
            Console.WriteLine(head.ToString());
        }

        private static void DifferentDataLinkedList()
        {
            Node head = new TypedNode<char>('.');
            head = new TypedNode<DateTime>(DateTime.Now, head);
            head = new TypedNode<String>("list", head);
            head = new TypedNode<Tuple<int, int>>(new Tuple<int, int> (1,2), head);
            Console.WriteLine(head.ToString());
        }

        private static void TypeTest()
        {
            Boolean sameType = (typeof(List<DateTime>) == typeof(DateTimeList));
            Console.WriteLine(typeof(List<DateTime>));
            Console.WriteLine(typeof(DateTimeList));
            sameType = (typeof(List<DateTime>) == typeof(D));
            Console.WriteLine("it is {0} same type", sameType == true ? "" : "not");
        }

        internal sealed class DateTimeList : List<DateTime> { }
    }

    internal sealed class Node<T>
    {
        public T data;
        public Node<T> next;
        public Node(T data) : this(data, null) { }
        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }

        public override string ToString()
        {
            return data.ToString() + ((next != null) ? next.ToString() : String.Empty);
        }
    }

    class Node
    {
        protected Node next;
        public Node(Node next) { this.next = next; }
    }

    sealed class TypedNode<T> : Node
    {
        public T data;
        public TypedNode(T data,Node next) : base(next)
        {
            this.data = data;
        }
        public TypedNode(T data) : this(data,null) { }

        public override string ToString()
        {
            return data.ToString() + ((next != null) ? next.ToString() : String.Empty);
        }
    }

    // invariant and contravariant 
    public delegate TResult Func<in T, out TResult>(T arg);

    internal static class VariantTest
    {
        public static void Test1()
        {
            Func<Object, ArgumentException> func = null;
            Func<Object, Exception> outfunc = func;
            Func<String, ArgumentException> infunc = func;
            Func<Dictionary<Func<String,Exception>,Exception>, Exception> inoutfunc = func;

            //Exception ee = inoutfunc(Activator.CreateInstance(typeof(Dictionary<Func<String, Exception>, Exception>)), new Exception());
            try
            {
                Exception e = infunc("");
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.ToString());
            }
            finally
            {
                Type t = typeof(Dictionary<Func<String, Exception>,Exception>);
                Console.WriteLine(t);
            }
        }

        public interface IMyEnumerator<out T>: IEnumerator
        {
            Boolean MoveToNext();
            T GetCurrent();
        }

        static Int32 Count(IEnumerable<Object> collection) { return 0; }

        public static void Test2()
        {
            Int32 c = Count(new[] { "Grant" });
            c = Count(new List<Object>());
        }
    }

    internal sealed class GenericMethodTest<T>
    {
        private T data;

        //like class template member partical specialize
        public TOutput Converter<TOutput>()
        {
            TOutput output = (TOutput)Convert.ChangeType(data, typeof(TOutput));
            return output;
        }
    }

    internal static class SwapTest
    {
        public static void Swap<T>(ref T o1, ref T o2)
        {
            T tmp = o1;
            o1 = o2;
            o2 = tmp;
        }
        // ref and no ref is override 
        public static void Swap<T>(T o1, T o2)
        {
            T tmp = o1;
            o1 = o2;
            o2 = tmp;
        }

        private static void Display(String s)
        {
            Console.WriteLine(s);
        }
        public static void Display<T>(T t)
        {
            Display(t.ToString());
        }

        public static void Test1()
        {
            String s1 = "hello";
            String s2 = "world";
            Console.WriteLine("s1={0},s2={1}", s1, s2);
            Swap(ref s1, ref s2);
            Console.WriteLine("s1={0},s2={1}", s1, s2);
            Int32 i1 = 123;
            Int32 i2 = 321;
            Console.WriteLine("i1={0},i2={1}", i1, i2);
            Swap<Int32>(ref i1, ref i2);
            Console.WriteLine("i1={0},i2={1}", i1, i2);
        }
        public static void Test2()
        {
            String s1 = "hello";
            String s2 = "world";
            Console.WriteLine("s1={0},s2={1}", s1, s2);
            Swap(s1, s2);
            Console.WriteLine("s1={0},s2={1}", s1, s2);
            Int32 i1 = 123;
            Int32 i2 = 321;
            Console.WriteLine("i1={0},i2={1}", i1, i2);
            Swap<Int32>(i1, i2);
            Console.WriteLine("i1={0},i2={1}", i1, i2);
        }
        public static void Test3()
        {
            String s1 = "hello";
            Object s2 = "world";
            Console.WriteLine("s1={0},s2={1}", s1, s2);
            Swap(s1, s2);
            Console.WriteLine("s1={0},s2={1}", s1, s2);
            //error
            //Swap<String>(ref s1, ref s2);
            //Swap<String>(s1, s2);
            Int32 i1 = 123;
            Object i2 = 321;
            Console.WriteLine("i1={0},i2={1}", i1, i2);
            Swap(i1, i2);
            Console.WriteLine("i1={0},i2={1}", i1, i2);
        }

        public static void Test4()
        {
            Display("hello");
            Display<String>("world");
            Display(123);
        }
    }

    internal static class WhereTest
    {
        private static Boolean MethodTakingAnyType<T>(T t)
        {
            T tmp = t;
            Boolean b = tmp.Equals(t);
            return b;
        }
        //error 
        //not all T type contains Compareto Method
        //private static T Min<T>(T o1, T o2)
        //{
        //   if (o1.CompareTo(o2) < o) reutrn o1;
        //  else
        //     return o2;
        //}

        private static T Min<T>(T t1, T t2) where T : IComparable<T>
        {
            if (t1.CompareTo(t2) < 0) return t1;
            else
                return t2;
        }

        internal class Base
        {
            public virtual void M<T1, T2>()
                where T1 : class
                where T2 : struct
            {
            }
            public virtual void N<T>()
                //where T : List<Object>
                //where T : System.Object
                where T : System.Delegate
            { }
        }

        internal sealed class Derived : Base
        {
            public override void M<T3, T4>()
            // error 
            //    where T3 : class
            //    where T4 : struct 
            { }
            public override void N<T>()
            {
                base.N<T>();
            }

            public void F1<T>(T t)
                where T : Stream
            {
                t.Close();
            }
        }

        internal sealed class PrimaryConstraintOfClass<T> where T : class
        {
            public void M() { T temp = null; }
            public void N<T>() where T : struct { }
        }

        internal static class PrimaryConstraintOfStaticClass<T> where T : class
        {
            public static void M<T>() where T : struct { }
            public static Int32 mi = default;
        }
        //internal static class PrimaryConstraintOfStruct<T> where T : new()
        internal static class PrimaryConstraintOfStruct<T> where T : struct
        {
            public static T Factory() { return new T(); }
        }
        internal sealed class SecondConstraintOfClass
        {
            private static List<TBase> ConvertList<T, TBase>(IList<T> list)
                where T : TBase
            {
                List<TBase> baseList = new List<TBase>(list.Count);
                for (Int32 i = 0; i < list.Count; i++)
                    baseList.Add(list[i]);
                return baseList;
            }

            public static void CallingConvertIList()
            {
                IList<String> ls = new List<String>();
                ls.Add("Is String");
                IList<Object> olst = ConvertList<String, Object>(ls);
                List<IComparable> iclst = ConvertList<String, IComparable>(ls);
                IList<IComparable<String>> icslst = ConvertList<String, IComparable<String>>(ls);
                List<String> slst = ConvertList<String, String>(ls);
                //error String is not subtype of Exception
                //List<Exception> elst = ConvertList<String, Exception>(ls);
            }
        }

        internal interface ConstructorConstraintOfInterface<T> where T : new()
            //is unnecessary
            //where T : struct
        {

        }

        //internal sealed class ConcreteInterface : ConstructorConstraintOfInterface<Int32>
        internal sealed class ConcreteInterface : ConstructorConstraintOfInterface<List<Int32>>
        {
        }

        public sealed class CastingAGenericTypeVariable
        {
            public static void CastingTypeVariable<T>(T obj)
            {
                try
                {
                    Int32 x = (Int32)(Object)obj;
                    String s = (String)(Object)obj;
                }catch(InvalidCastException e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            public static void CastingTypevariableWithAs<T>(T obj)
            {
                String s = obj as String;
                Console.WriteLine("s is null is {0} true",s==null?"":"not");
            }
            public static void CastingTypevariableWithAs<T>(T t1,T t2) where T : class
            {
                //error 
                //t1 == t2;
                Boolean b = t1 == t2;
            }
            private static void SettingAGenericTypeVariableToDefaultValue<T>()
            {
                //not all type has constructor with none parameter
                //T value = new T();
                //error valut type never is null
                //T value = null;
                T value = default(T);
            }
        }

        internal sealed class AType { }
        internal sealed class AType<T> { }
        internal sealed class AType<T1, T2> { }
        //error only with where can not override 
        //internal sealed class AType<T1> where T1:IComparable<T> { }
        internal sealed class AType<T1, T2, T3> where T1:IComparable<T1> { }
        internal sealed class AType<T1,T2,T3,T4> where T1:IComparable<T1> { }
        public static void Test1()
        {
            String s1 = "hhh";
            String s2 = "sss";
            Console.WriteLine("the min between s1 and s2 is {0}", Min(s1, s2));
            //error
            //Object not contains CompareTo
            //because o1 is reference is a pointer actually
            //not like c++ 
            //Object o1 = "hhh";
            //Object o2 = "sss";
            //Console.WriteLine("the min between s1 and s2 is {0}", Min(o1, o2));
        }
        public static void Test2()
        {
            Derived d = new Derived();
            // MulticastDelegate is a subtype of Delegate
            d.N<MulticastDelegate>();
            FileStream fileStream = new FileStream("Test",FileMode.Open);
            d.F1<FileStream>(fileStream);
            d.M<Object, Int32>();
            d.M<Object, SByte>();
            //error value type can not be nunll
            //Int32 i = null;
            //nullable type can be null
            Int32? ii = null;
        }
        public static void Test3()
        {
            PrimaryConstraintOfClass<EventArgs> p = new WhereTest.PrimaryConstraintOfClass<EventArgs>();
            p.N<Int32>();
            PrimaryConstraintOfStaticClass<Object>.M<Int32>();
            Type t1 = PrimaryConstraintOfStaticClass<Hashtable>.mi.GetType(); 
            Type t2 = PrimaryConstraintOfStaticClass<Object>.mi.GetType();
            Console.WriteLine(t1);
            Console.WriteLine(t2);
            Boolean t = t1 == t2;
            //true

            Console.WriteLine("{0}", t == true ? "true" : "false");
        }
        public static void Test4()
        {
            CastingAGenericTypeVariable.CastingTypeVariable<Int32>(32);
            CastingAGenericTypeVariable.CastingTypevariableWithAs<Int32>(32);
            Int32? i = 0;
            Boolean b = i == null;
            Console.WriteLine(b);
            Int32 ii = 0;
            b = ii == null;
            Console.WriteLine(b);
        }
    }
}
