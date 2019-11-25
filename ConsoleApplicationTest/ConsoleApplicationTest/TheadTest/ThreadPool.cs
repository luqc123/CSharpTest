using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;

namespace ConsoleApplicationTest.TheadTest
{
    public class ThreadPoolTest
    {
        public static void Main()
        {
            new ThreadPoolTest().Test1();
        }

        private delegate string RunOnThreadPool(out int threadId);

        private static string Test(out int threadId)
        {
            WriteLine("Staring thread...");
            WriteLine($"Is threadpool thread: {CurrentThread.IsThreadPoolThread}");
            Sleep(TimeSpan.FromSeconds(2));
            threadId = CurrentThread.ManagedThreadId;
            return $"threadpool worker threadid is:{threadId}";
        }

        private static void Callback(IAsyncResult ar)
        {
            WriteLine("Staring a callback...");
            WriteLine($"State passed to a callback:{ar.AsyncState}");
            WriteLine($"Is threadpool thread:{CurrentThread.IsThreadPoolThread}");
            WriteLine($"threadpool worker thread id:{CurrentThread.ManagedThreadId}");
        }

        public void Test1()
        {
            int threadId = 0;
            RunOnThreadPool poolDelegate = Test;

            var t = new Thread(() => Test(out threadId));
            t.Start();
            t.Join();
            WriteLine($"thread id : {threadId}");

            IAsyncResult r = poolDelegate.BeginInvoke(out threadId, Callback, "a delegate asynchronous call");
            r.AsyncWaitHandle.WaitOne();

            string result = poolDelegate.EndInvoke(out threadId, r);

            WriteLine($"threadpool worker id : {threadId}");
            WriteLine($"Result : {result}");

            WriteLine($"Main Thread id : {CurrentThread.ManagedThreadId}");
            WriteLine($"Main Thread id : {CurrentThread.ThreadState}");
            Sleep(TimeSpan.FromSeconds(2));
        }
    }
}
