using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Console;
using static System.Threading.Thread;

namespace ConsoleApplicationTest.TheadTest
{
    public class ThreadSync
    {
        public static void Main()
        {
            //Test1();
            //Test2();
            //Test3();
            //Test4();
            //Test5();
            //Test6();
            //Test7();
            //Test8();
            Test9();    
        }

        public static void Test1()
        {
            const string MutexName = "CSharpThreadingCookBook";
            using (var m = new Mutex(false, MutexName))
            {
                if(!m.WaitOne(TimeSpan.FromSeconds(5),false))
                {
                    Console.WriteLine("Second Instance is running");
                }else
                {
                    Console.WriteLine("running");
                    Console.WriteLine();
                    m.ReleaseMutex();
                }
            }
        }
        public static void Test2()
        {
            for(Int32 i = 0;i < 6;i++)
            {
                string threadName = "Thread_" + i;
                new Thread(() => AccessDatabase(threadName, i)).Start();
            }
        }

        public static void Test3()
        {
            var t = new Thread(() => Process(5));
            t.Start();
            WriteLine("Wating for another work done...");
            _workerEvent.WaitOne();
            WriteLine("Starting main work...");
            Sleep(TimeSpan.FromSeconds(5));
            WriteLine("Main work is done!");
            _mainEvent.Set();
            WriteLine("Waiting for second work done...");
            _workerEvent.WaitOne();
            WriteLine("Second work is done");
        }

        public static void Test4()
        {
            ThroughGate();

            Console.WriteLine("gate is open");
            _manualEvent.Set();
            Sleep(TimeSpan.FromSeconds(2));
            _manualEvent.Reset();
            Console.WriteLine("gate is closed");

            Console.WriteLine("gate is open again");
            _manualEvent.Set();
            Sleep(TimeSpan.FromSeconds(3));
            _manualEvent.Reset();
            Console.WriteLine("gate is closed again");
        }

        public static void Test5()
        {
            var t1 = new Thread(() =>
            {
                Console.WriteLine("first operation");
                Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine("first operation done");
                _countDownEvent.Signal();
            });
            var t2 = new Thread(() =>
            {
                Console.WriteLine("second operation");
                Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine("second operation done");
                _countDownEvent.Signal();
            });

            //just singal twice no matter in which thread will cause wait wait() return.
            //_countDownEvent.Signal();
            //_countDownEvent.Signal();
            t1.Start();
            t2.Start();
            _countDownEvent.Wait();
            Console.WriteLine("two operations has been completed");
            _countDownEvent.Dispose();
        }

        public static void Test6()
        {
            Thread t1 = new Thread(() =>
            {
                Console.WriteLine("t1 do something");
                _barrier.SignalAndWait();
                Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine("t1 do otherthing");
                _barrier.SignalAndWait();
                Console.WriteLine("t1 do otherthing again");
                _barrier.SignalAndWait();
            });
            Thread t2 = new Thread(() =>
            {
                Console.WriteLine("t2 do something");
                _barrier.SignalAndWait();
                Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine("t2 do otherthing");
                _barrier.SignalAndWait();
                Console.WriteLine("t2 do otherthing again");
                _barrier.SignalAndWait();
            });
            Thread t3 = new Thread(() =>
            {
                Console.WriteLine("t3 do something");
                _barrier.SignalAndWait();
                Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine("t3 do otherthing");
                _barrier.SignalAndWait();
                Console.WriteLine("t3 do otherthing again");
                _barrier.SignalAndWait();

            });
            Thread t4 = new Thread(() =>
            {
                Console.WriteLine("t4 do something");
                _barrier.SignalAndWait();
                Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine("t4 do otherthing");
                _barrier.SignalAndWait();
                Console.WriteLine("t4 do otherthing again");
                _barrier.SignalAndWait();
            });
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

        }
        public static void Test7()
        {
            int newKey = new Random().Next(250);
            _items[newKey] = 1;
            new Thread(() => Write()).Start();
            Read();
        }

        public static void Test8()
        {
            new Thread(() => Read2()).Start();
            new Thread(() => Read2()).Start();
            new Thread(() => Read2()).Start();
            new Thread(() => Write2("WriteThread1")).Start();
            new Thread(() => Write2("WriteThread2")).Start();
        }
        public static void Test9()
        {
            var t1 = new Thread(() => UserModeWait());
            var t2 = new Thread(() => HybridSpinWait());
            Console.WriteLine("user mode wait");
            Sleep(TimeSpan.FromSeconds(20));
            t1.Start();
            _isCompleted = true;
            Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine("hybird mode wait");
            Sleep(TimeSpan.FromSeconds(20));
            t2.Start();
            _isCompleted = true;
            Sleep(TimeSpan.FromSeconds(1));
        }

        private static void UserModeWait()
        {
            while(!_isCompleted)
            {
                Console.WriteLine("waiting");
            }
            Console.WriteLine();
            Console.WriteLine("waiting end");
        }
        private static void HybridSpinWait()
        {
            var s = new SpinWait();
            while (!_isCompleted)
            {
                s.SpinOnce();
                Console.WriteLine(s.NextSpinWillYield);
            }
            Console.WriteLine();
            Console.WriteLine("spin waiting end");
        }

        private static volatile bool _isCompleted = false;
        public static void ThroughGate()
        {
            Action<String, Int32> travelThroughGate = (threadName, seconds) => {
                WriteLine("{0} is wating for gate...",threadName);
                Sleep(TimeSpan.FromSeconds(seconds));
                _manualEvent.Wait();
                Console.WriteLine("{0} enters the gate", threadName);
            };

            var t1 = new Thread(() => travelThroughGate("Thread1", 1));
            var t2 = new Thread(() => travelThroughGate("Thread2", 2));
            var t3 = new Thread(() => travelThroughGate("Thread3", 3));
            t1.Start();
            t2.Start();
            t3.Start();
        }

        public static void Process(Int32 seconds)
        {
            WriteLine("Starting a long running work...");
            Sleep(TimeSpan.FromSeconds(seconds));
            WriteLine("work is done!");
            _workerEvent.Set();
            WriteLine("Waiting for another thread to complete work!");
            _mainEvent.WaitOne();
            WriteLine("Starting another task...");
            Sleep(TimeSpan.FromSeconds(seconds));
            WriteLine("work is done again!");
            _workerEvent.Set();
        }

        private static SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(4);
        private static AutoResetEvent _workerEvent = new AutoResetEvent(false);
        private static AutoResetEvent _mainEvent = new AutoResetEvent(false);
        private static ManualResetEventSlim _manualEvent = new ManualResetEventSlim(false);
        private static CountdownEvent _countDownEvent = new CountdownEvent(2);
        private static Barrier _barrier = new Barrier(4, (b) =>
        {
            Console.WriteLine($"End of phrase {b.CurrentPhaseNumber + 1}");
        });
        private static ReaderWriterLockSlim _readerwriterLock = new ReaderWriterLockSlim();
        private static Dictionary<Int32, Int32> _items = new Dictionary<int, int>();

        private static void Read()
        {
            while(true)

            {
                try
                {
                    if(_readerwriterLock.TryEnterReadLock(TimeSpan.FromSeconds(1)))
                    {
                        Console.WriteLine("Reading contents of a dictionary");
                        foreach(var key in _items.Keys)
                        {
                            Console.WriteLine(key);
                            Sleep(TimeSpan.FromSeconds(0.1));
                        }
                        _readerwriterLock.ExitReadLock();
                    }
                    else
                    {
                        Console.WriteLine("Now it's write mode,wait...");
                    }
                }finally
                {

                }
            }
        }
        private static void Write()
        {
            Sleep(TimeSpan.FromSeconds(1));
            //enter writelock will block readlock 
            //execute line 226
            _readerwriterLock.EnterWriteLock();
            Sleep(TimeSpan.FromSeconds(5));
            _readerwriterLock.ExitWriteLock();
        }

        private static void Read2()
        {
            while(true)
            {
                try
                {
                    if(_readerwriterLock.TryEnterReadLock(TimeSpan.FromSeconds(1)))
                    {
                        foreach (var key in _items.Keys)
                            Console.WriteLine(key);
                    }
                }
                finally
                {
                    _readerwriterLock.ExitReadLock();
                    Sleep(TimeSpan.FromSeconds(1));
                }
            }
        }
        private static void Write2(string threadName)
        {
            while(true)
            {
                try
                {
                    int newKey = new Random().Next(250);
                    _readerwriterLock.EnterUpgradeableReadLock();
                    if(!_items.ContainsKey(newKey))
                    {
                        try
                        {
                            _readerwriterLock.EnterWriteLock();
                            _items[newKey] = newKey % 100;
                            Console.WriteLine("New value {0}-{1} is put into items by {2}", newKey, _items[newKey], threadName);
                        }finally
                        {
                            _readerwriterLock.ExitWriteLock();
                        }
                    }
                    Sleep(TimeSpan.FromSeconds(0.1));
                }
                finally
                {
                    _readerwriterLock.ExitUpgradeableReadLock();
                }
            }
        }

        private static void AccessDatabase(string threadName,int waitseconds)
        {
            Console.WriteLine("{0} wait to access database",threadName);
            _semaphoreSlim.Wait();
            Console.WriteLine("{0} was granded to access database",threadName);
            Thread.Sleep(TimeSpan.FromSeconds(waitseconds));
            Console.WriteLine("{0} is completed", threadName);
            _semaphoreSlim.Release();

        }
    }
}
