using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest.Generics
{
    public class DoubleList : IEnumerable
    {
        public ListNode First { get; set; }
        public ListNode Last { get; set; }

        public ListNode AddLast(object value)
        {
            var newNode = new ListNode(value);
            if(First == null)
            {
                First = newNode;
                Last = First;
            }
            else
            {
                Last.Next = newNode;
                Last = newNode;
            }
            return newNode;
        }

        public IEnumerator GetEnumerator()
        {
            ListNode current = First;
            while(current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
    }

    public class DoubleListT<T> : IEnumerable<T>
    {
        public ListNodeT<T> First { get; set; }
        public ListNodeT<T> Last { get; set; }

        public ListNodeT<T> AddLast(T node)
        {
            var newNode = new ListNodeT<T>(node);
            if(First == null)
            {
                First = newNode;
                Last = First;
            }
            else
            {
                Last.Next = newNode;
                newNode.Prev = Last;
                Last = newNode;
            }
            return newNode;
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListNodeT<T> current = Last;
           

            while(current != null)
            {
                yield return current.Value;
                current = current.Prev;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
