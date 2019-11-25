using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    public class EnumTest
    {
        public static void Main()
        {
            EnumTest t = new EnumTest();
            t.WriteGreeting(TimeOfDay.Morning);
            t.WriteGreeting((TimeOfDay)5);

            TimeOfDay time = TimeOfDay.Morning;
            Console.WriteLine(time);//Moring
            Console.WriteLine((int)time);//0

            TimeOfDay time2 = (TimeOfDay)Enum.Parse(typeof(TimeOfDay), "afternoon", true);
            Console.WriteLine(time2);
            Console.WriteLine((int)time2);
        }

        public void WriteGreeting(TimeOfDay t)
        {
            switch (t)
            {
                case TimeOfDay.Morning:
                    Console.WriteLine("Good Morning");
                    break;
                case TimeOfDay.Afternoon:
                    Console.WriteLine("Good Afternoon");
                    break;
                case TimeOfDay.Evening:
                    Console.WriteLine("Good Eveing");
                    break;
                case TimeOfDay.Midnight:
                    Console.WriteLine("Good Midnight");
                    break;
                default:
                    Console.WriteLine("Hello");
                    break;
            }
        }
    }

    public enum TimeOfDay
    {
        Morning = 0,
        Afternoon = 1,
        Evening = 2,
        Midnight = 3,
    }
}
