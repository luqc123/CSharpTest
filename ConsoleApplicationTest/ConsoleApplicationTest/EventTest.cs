using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplicationTest
{
    //自定义事件
    public sealed class EventKey : Object { }

    public sealed class EventSet
    {
        private readonly Dictionary<EventKey, Delegate> m_events =
            new Dictionary<EventKey, Delegate>();

        public void Add(EventKey eventKey, Delegate handler)
        {
            Monitor.Enter(m_events);
            Delegate d;
            m_events.TryGetValue(eventKey, out d);
            //一个时间的多个订阅者
            m_events[eventKey] = Delegate.Combine(d, handler);
            Monitor.Exit(m_events);
        }

        public void Remove(EventKey eventKey, Delegate handler)
        {
            Monitor.Enter(m_events);
            Delegate d;
            m_events.TryGetValue(eventKey, out d);
            d = Delegate.Remove(d, handler);
            if (d != null)
                m_events[eventKey] = d;
            else
                m_events.Remove(eventKey);
            Monitor.Exit(m_events);
        }

        public void Raise(EventKey eventKey, Object sender, EventArgs e)
        {
            Delegate d;
            Monitor.Enter(m_events);
            m_events.TryGetValue(eventKey, out d);
            Monitor.Exit(m_events);

            if (d!=null)
            {
                d.DynamicInvoke(new object[] { sender, e });
            }
        }
    }
}
