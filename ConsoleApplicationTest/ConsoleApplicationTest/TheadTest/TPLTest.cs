using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;

namespace ConsoleApplicationTest.TheadTest
{
    sealed public class TPLTest
    {
        public static void Main()
        {
            Test1();
        }

        public static void TestMethod(string name)
        {
            WriteLine($"Task {name} running on thread: {CurrentThread.ManagedThreadId}");
            WriteLine($"{name} 's thread {CurrentThread.ManagedThreadId} is threadpool thread : {CurrentThread.IsThreadPoolThread}");
        }
        public static void Test1()
        {
            //why all task's name is Task10
            Task[] tasks = new Task[10];
            for(int i = 0; i < 10; i++)
            {
                tasks[i] = new Task(() => TestMethod("Task"+i));
            }
            for(int i = 0; i < 10; i++)
            {
                tasks[i].Start();
            }
            Task.Run(() => TestMethod("Task101"));
            Task.Factory.StartNew(() => TestMethod("Task102"));
            Task.Factory.StartNew(() => TestMethod("Task103"), TaskCreationOptions.LongRunning);
            Sleep(TimeSpan.FromSeconds(10));
        }
    }
}
