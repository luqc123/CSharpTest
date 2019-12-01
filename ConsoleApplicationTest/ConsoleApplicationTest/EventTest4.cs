using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    public class EventTest4
    {
        public static void Main()
        {
            Subsriber subsriber1 = new Subsriber("subscriber1");
            Subsriber subsriber2 = new Subsriber("subscriber2");

            Publisher publisher = new Publisher("publisher");

            publisher.EventHandler += subsriber1.SomeMethodTobeCalled;
            publisher.EventHandler += subsriber2.SomeMethodTobeCalled;

            publisher.NotifySubsriber(new SomeEventArgs("SomeName"));

            publisher.EventHandler -= subsriber2.SomeMethodTobeCalled;

            publisher.NotifySubsriber(new SomeEventArgs("SomeName2"));

            publisher.SimulateEvent();
        }
    }

    public sealed class Publisher
    {
        public string PublisherName { get; set; }
        public Publisher(string name)
        {
            PublisherName = name;   
        }

        public event EventHandler<SomeEventArgs> EventHandler;

        public void NotifySubsriber(SomeEventArgs e)
        {
            var handler = EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void SimulateEvent()
        {
            NotifySubsriber(new SomeEventArgs("SomeName2"));
        }
    }

    public sealed class Subsriber
    {
        public string SubsriberName { get; set; }

        public Subsriber(string name)
        {
            SubsriberName = name;
        }
        public void SomeMethodTobeCalled(object sender,SomeEventArgs e)
        {
            Console.WriteLine($"{SubsriberName} will be called.");
            Console.WriteLine($"From Publisher: SomeEventArgs's Name is {e.SomeName}");
            var t = sender as Publisher;
            if (t != null)
                Console.WriteLine($"From Publisher: Publisher's Name is {t.PublisherName}");
        }
    }

    public sealed class SomeEventArgs : EventArgs
    {
        public string SomeName { get; set; }

        public SomeEventArgs(string name)
        {
            SomeName = name;
        }
    }
}
