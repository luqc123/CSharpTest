using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    public class EventTest2
    {
        public static void Main()
        {
            var dealer = new CarDealer();
            var kaka = new Consumer("Kaka");

            dealer.NewCarInfo += kaka.NewCarIsHere;
            dealer.NewCar("Audi Q5");
            dealer.NewCarInfo -= kaka.NewCarIsHere;
            dealer.NewCar("Baoma X1");
        }
    }

    public class CarInfoEventArgs : EventArgs
    {
        public string Car { get; set; }
        public CarInfoEventArgs(string car)
        {
            Car = car;
        }
    }

    public class CarDealer
    {
        public event EventHandler<CarInfoEventArgs> NewCarInfo;

        public void NewCar(string car)
        {
            Console.WriteLine($"CarDealer new car : {car}");
            RaiseNewCarInfo(car);
        }

        protected virtual void RaiseNewCarInfo(string car)
        {
            EventHandler<CarInfoEventArgs> newCarInfo = NewCarInfo;
            if(newCarInfo != null)
            {
                newCarInfo(this, new CarInfoEventArgs(car));
            }
        }
    }

    public class Consumer
    {
        private string name;

        public Consumer(string name)
        {
            this.name = name;
        }

        public void NewCarIsHere(object sender, CarInfoEventArgs eventArgs)
        {
            Console.WriteLine($"{name} : car {eventArgs.Car} is new");
        }
    }
}
