using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest.Generics
{
    public class SingleList : IEnumerable
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
}
