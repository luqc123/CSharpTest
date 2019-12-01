using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConsoleApplicationTest
{
    public class EventTest3
    {
        public static void Main()
        {
            var dealer = new CarDealer2();
            var kaka = new Consumer2("Kaka");

            WeakEventManager<CarDealer2, CarInfoEventArgs2>.AddHandler(dealer, "NewCarInfo", kaka.NewCarIsHere);
//            WeakCarInfoEventManager.AddListener(dealer, kaka);
            dealer.NewCar("Audi Q5");
            var john = new Consumer2("John");
            WeakEventManager<CarDealer2, CarInfoEventArgs2>.AddHandler(dealer, "NewCarInfo", john.NewCarIsHere);
//            WeakCarInfoEventManager.AddListener(dealer, john);
            dealer.NewCar("Audi A6L");
            WeakEventManager<CarDealer2, CarInfoEventArgs2>.RemoveHandler(dealer, "NewCarInfo", john.NewCarIsHere);
//            WeakCarInfoEventManager.RemoveListener(dealer, john);
            dealer.NewCar("Audi A8");


        }
    }

    public class CarInfoEventArgs2 : EventArgs
    {
        public CarInfoEventArgs2(string car)
        {
            Car = car;
        }
        public string Car { get; set; }
    }

    public class CarDealer2
    {
        public event EventHandler<CarInfoEventArgs2> NewCarInfo;

        public CarDealer2() { }

        public void NewCar(string car)
        {
            Console.WriteLine("There is a new car : {0} here.", car);
            EventHandler<CarInfoEventArgs2> eventHandler = NewCarInfo;
            if (eventHandler != null)
                NewCarInfo(this, new CarInfoEventArgs2(car));
        }
    }

    public class Consumer2 : IWeakEventListener
    {
        public string name;
        public Consumer2(string name) { this.name = name; }

        public void NewCarIsHere(object sender, CarInfoEventArgs2 e)
        {
            Console.WriteLine("New Car:{0},{1}", e.Car,name);
        }

        bool IWeakEventListener.ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            NewCarIsHere(sender, e as CarInfoEventArgs2);
            return true;
        }
    }

    public class WeakCarInfoEventManager : WeakEventManager
    {
        public static void AddListener(object source, IWeakEventListener listener)
        {
            CurrentManager.ProtectedAddListener(source, listener);
        }
        public static void RemoveListener(object source,IWeakEventListener listener)
        {
            CurrentManager.ProtectedRemoveListener(source, listener);
        }


        protected override void StartListening(object source)
        {
            (source as CarDealer2).NewCarInfo += CarDealer2_NewCarInfo;
        }

        void CarDealer2_NewCarInfo(object sender,CarInfoEventArgs2 e)
        {
            DeliverEvent(sender, e);
        }

        protected override void StopListening(object source)
        {
            (source as CarDealer2).NewCarInfo -= CarDealer2_NewCarInfo;
        }

        public static WeakCarInfoEventManager CurrentManager
        {
            get
            {
                var manager = GetCurrentManager(typeof(WeakCarInfoEventManager)) as
                    WeakCarInfoEventManager;

                if (manager == null)
                {
                    manager = new WeakCarInfoEventManager();
                    SetCurrentManager(typeof(WeakCarInfoEventManager), manager);
                }
                return manager;
            }
        }
    }
}
