using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplicationTest
{

    public static class Events
    {
        public static void Main()
        {
            TypeWithLotsOfEventsTest();
        }

        private static void TypeWithLotsOfEventsTest()
        {
            TypeWithLotsOfEvents twle = new TypeWithLotsOfEvents();
            twle.Foo += HandleFooEvent;
            twle.SimulateFoo();
            Console.WriteLine("the callback was invoked 1 time above" + Environment.NewLine);
            Console.WriteLine();
        }

        private static void HandleFooEvent(object sender,FooEventArgs eventArgs)
        {
            Console.WriteLine("Handling Foo Event here...");
        }
    }
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
                Console.WriteLine(e.GetType().ToString());
            }
        }
    }

    public class FooEventArgs : EventArgs { }
    
    public class BarEventArgs : EventArgs { }

    internal class TypeWithLotsOfEvents
    {
        private readonly EventSet m_eventSet = new EventSet();

        protected EventSet EventSet { get { return m_eventSet; } }

        protected static readonly EventKey s_fooEventKey = new EventKey();

        public event EventHandler<FooEventArgs> Foo
        {
            add { m_eventSet.Add(s_fooEventKey, value); }
            remove { m_eventSet.Remove(s_fooEventKey, value); }
        }

        protected virtual void OnFoo(FooEventArgs e)
        {
            m_eventSet.Raise(s_fooEventKey, this, e);
        }

        public void SimulateFoo()
        {
            OnFoo(new FooEventArgs());
        }

        protected readonly EventKey s_barEventKey = new EventKey();

        public event EventHandler<BarEventArgs> Bar
        {
            add { m_eventSet.Add(s_barEventKey, value); }
            remove { m_eventSet.Remove(s_barEventKey, value); }
        }

        protected virtual void OnBar(BarEventArgs e)
        {
            OnBar(new BarEventArgs());
        }
    }

}
