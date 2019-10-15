using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplicationTest.EventTest
{
    public sealed class EventKey : Object
    {
    }

    public sealed class EventSet
    {
        private readonly Dictionary<EventKey, Delegate> _events = new Dictionary<EventKey, Delegate>();

        public void Add(EventKey eventKey, Delegate handler)
        {
            Monitor.Enter(_events);
            Delegate d;
            _events.TryGetValue(eventKey, out d);
            _events[eventKey] = Delegate.Combine(d, handler);
            Monitor.Exit(_events);
        }

        public void Remove(EventKey eventKey, Delegate handler)
        {
            Monitor.Enter(_events);
            Delegate d;
            if (_events.TryGetValue(eventKey,out d))
            {
                d = Delegate.Remove(d, handler);
                if (d!=null)
                {
                    _events[eventKey] = d;
                }
                else
                {
                    _events.Remove(eventKey);
                }
            }
            Monitor.Exit(_events);
        }

        public void Raise(EventKey eventKey,Object sender, EventArgs e)
        {
            Delegate d;
            Monitor.Enter(_events);
            _events.TryGetValue(eventKey, out d);
            if (d!= null)
            {
                d.DynamicInvoke(new Object[] { sender, e });
            }
            Monitor.Exit(_events);
        }
    }
}
