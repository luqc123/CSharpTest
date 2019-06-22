using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest.Generics
{
    public class ListNode
    {
        public ListNode(object value)
        {
            this.Value = value;
        }

        public object Value;
        public ListNode Prev { get; set; }
        public ListNode Next { get; set; }
    }

    public class ListNodeT<T>
    {
        public ListNodeT(T value)
        {
            this.Value = value;
        }
        public T Value { get; private set; }
        public ListNodeT<T> Next { get; internal set; }
        public ListNodeT<T> Prev { get; internal set; }

    }
}
