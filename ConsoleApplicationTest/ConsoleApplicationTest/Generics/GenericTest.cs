using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
            GenericInheritance.Go();
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
}
