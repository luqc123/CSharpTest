using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    class ArrayTest
    {
        public static void InitTest()
        {
            int[] myArray = new int[] { 1, 2, 3, 4 };
            int[] myArray1 = { 1, 2, 3, 4 };

            foreach (var i in myArray)
                Console.WriteLine(i);

            for (int i = 0; i < myArray1.Length; i++)
                Console.WriteLine(myArray1[i]);
        }

        public static void Test1()
        {
            Person[] person = new Person[2];
            person[0] = new Person { FirstName = "Man", LastName = "Peng" };
            person[1] = new Person { FirstName = "QiChang", LastName = "Lu" };

            Person[] person1 =
            {
                new Person{FirstName="1",LastName="2"},
                new Person{FirstName="3",LastName="4"}
            };

            foreach (Person p in person)
                Console.WriteLine(p);

            for (int i = 0; i < person1.Length; i++)
                Console.WriteLine(int.Parse(person1[i].FirstName) + int.Parse(person1[i].LastName));
        }

        public static void MultiArrayTest()
        {
            int[,] twodim = {
                {1,2,3 },
                {4,5,6 },
                {7,8,9 }
            };
            int[,,] threedim = {
                {{1,2},{3,4} },
                {{5,6},{7,8} }
            };
            Console.WriteLine(twodim[1, 1]);//5
            Console.WriteLine(threedim[1, 1, 2]);//8
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return string.Format("FirstName is {0}, LastName is {1}", FirstName, LastName);
        }
    }
}
