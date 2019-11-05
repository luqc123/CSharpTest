using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace ConsoleApplicationTest.TheadTest
{
    public class BaseThread
    {
        public static void Main()
        {
            //thread run order is not in order 
            //Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
            //Test2();
            //Test3();
            //Test4();
            //will block
            //Test5();
            //Test6();
            //Test7();
        }

        public static void GetProcessInfo()
        {
            Console.WriteLine("Current process's id is {0}", Process.GetCurrentProcess().Id);
            Console.WriteLine(Process.GetCurrentProcess().ProcessName);
            Console.WriteLine(Process.GetCurrentProcess().BasePriority);
            Console.WriteLine(Process.GetCurrentProcess().WorkingSet64);
            Console.WriteLine(Process.GetCurrentProcess().MachineName);
            Console.WriteLine(Process.GetCurrentProcess().TotalProcessorTime);
            Console.WriteLine(Process.GetCurrentProcess().UserProcessorTime);
            Console.WriteLine(Process.GetCurrentProcess().VirtualMemorySize64);
        }

        public static void  Test1()
        {
            Thread t = new Thread(ThreadFunc);
            t.Name = "Thread_1";
            Console.WriteLine("thread name is {0}", t.Name);
            Console.WriteLine("thread's managedThreadid is {0}", t.ManagedThreadId);
            Console.WriteLine("thread is background thread == {0}", t.IsBackground);
            Console.WriteLine("thread's priority is {0}", t.Priority);
            // unstarted
            Console.WriteLine("thread's state is {0}", t.ThreadState);
            t.Start();
            //running
            Console.WriteLine("thread's state is {0}", t.ThreadState);
            t.Join();
            //stopped
            Console.WriteLine("thread's state is {0}", t.ThreadState);
            t.Abort();
            //aborted
            Console.WriteLine("thread's state is {0}", t.ThreadState);
        }

        public static void Test2()
        {
            Thread t1 = new Thread(() =>
            {
                Console.WriteLine("Thread 1");
                //DoSomeWork();
            });
            Thread t2 = new Thread(() =>
            {
                Console.WriteLine("Thread 2");
                //DoSomeWork();
            });
            Thread t3 = new Thread(() =>
            {
                Console.WriteLine("Thread 3");
                //DoSomeWork();
            });
            Thread t4 = new Thread(() =>
            {
                Console.WriteLine("Thread 4");
                //DoSomeWork();
            });
            Thread t5 = new Thread(() =>
            {
                Console.WriteLine("Thread 5");
                //DoSomeWork();
            });
            t1.Priority = ThreadPriority.AboveNormal;
            t3.Priority = ThreadPriority.BelowNormal;
            t4.Priority = ThreadPriority.Highest;
            t2.Priority = ThreadPriority.Lowest;
            t1.Name = "Thread1";
            t2.Name = "Thread2";
            t3.Name = "Thread3";
            t4.Name = "Thread4";
            t5.Name = "Thread5";
            t2.Start();
            t1.Start();
            t3.Start();
            t4.Start();
            t5.Start();
        }

        public static void Test3()
        {
            Thread t1 = new Thread(() =>
            {
                Console.WriteLine("this is a foreground thread");
                DoSomeWork(1000);
            });
            Thread t2 = new Thread(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                Console.WriteLine("this is a background thread");
                DoSomeWork(100);
            });
            t2.IsBackground = true;
            t1.Start();
            t2.Start();
        }

        // if don't have mutex i will not equal 2000000
        public static void Test4()
        {
            int i = 0;
            Mutex t = new Mutex();
            Thread t1 = new Thread(() =>
            {
                t.WaitOne();
                for (int j = 0; j < 1000000; j++)
                    i = i + 1;
                t.ReleaseMutex();
            });
            Thread t2 = new Thread(() =>
            {
                t.WaitOne();
                for (int j = 0; j < 1000000; j++)
                    i = i + 1;
                t.ReleaseMutex();
            });
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine(i);
        }
        public static void Test5()
        {
            int i = 0;
            AutoResetEvent a = new AutoResetEvent(false);
            Thread t1 = new Thread(() =>
            {
                a.WaitOne();
                for (int j = 0; j < 1000000; j++)
                    i = i + 1;
                a.Set();
            });
            Thread t2 = new Thread(() =>
            {
                a.WaitOne();
                for (int j = 0; j < 1000000; j++)
                    i = i + 1;
                a.Set();
            });
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine(i);
        }


        public static void Test6()
        {
            int i = 0;
            Thread t1 = new Thread(() =>
            {
                lock (_syncRoot)
                {
                    for (int j = 0; j < 1000000; j++)
                        i = i + 1;
                }

            });
            Thread t2 = new Thread(() =>
            {
                lock (_syncRoot)
                {
                    for (int j = 0; j < 1000000; j++)
                        i = i + 1;
                }
            });
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine(i);
        }

        public static void Test7()
        {
            object lock1 = new object();
            object lock2 = new object();

            new Thread(() => {
                lock (lock1)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    //wait lock2 release
                    lock (lock2) ;
                }
            }).Start();

            new Thread(() =>
            {
                lock (lock2)
                {
                    Thread.Sleep(1000);
                    //wait lock1 release
                    if (Monitor.TryEnter(lock1, TimeSpan.FromSeconds(5)))
                    {
                        Console.WriteLine("Accquired a protected resources successfully");
                    }
                    else
                    {
                        Console.WriteLine("Timeout Accquired a resource");
                    }
                }
            }).Start();
        }

        private static void DoSomeWork(int loop)
        {
            Int64 sum = 0;
            for(Int64 i = 0; i < loop;i++)
            {
                sum += i;
            }
            Console.WriteLine("CurrentThread is {0},Sum={1}", Thread.CurrentThread.Name, sum);
        }

        private static readonly object _syncRoot = new object();

        private static void ThreadFunc()
        {
            Console.WriteLine("This is thread test...");
            Console.WriteLine();
        }
    }
} 