using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

namespace ConsoleApplicationTest.TheadTest
{
    public static class ThreadASync
    {
        public static void Main()
        {
            //ThreadPoolDemo.Go();
            //ThreadPoolDemo.GetThreadNumber();
            //ExecutionContexts.Go();
            CancellationDemo.Go();
        }
    }

    internal sealed class ThreadPoolDemo
    {
        public static void Go()
        {
            Console.WriteLine("Main thread:queuing an asynchronous operation");
            ThreadPool.QueueUserWorkItem(ComputeBoundOp, 5);
            Thread.Sleep(1000);

            Console.ReadLine();
        }
        private static void ComputeBoundOp(Object state)
        {
            Console.WriteLine("In ComputeBoundOp state={0}", state);
            Thread.Sleep(1000);
        }
        public static void GetThreadNumber()
        {
            Int32 workerThreads;
            Int32 completionPortThreads;
            ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
            Console.WriteLine("GetAvailableThreads:");
            Console.WriteLine("workerThreads={0},competionPortThreads={1}", workerThreads, completionPortThreads);
            ThreadPool.GetMaxThreads(out workerThreads, out completionPortThreads);
            Console.WriteLine("GetMaxThreads:");
            Console.WriteLine("workerThreads={0},competionPortThreads={1}", workerThreads, completionPortThreads);
            ThreadPool.GetMinThreads(out workerThreads, out completionPortThreads);
            Console.WriteLine("GetMinThreads:");
            Console.WriteLine("workerThreads={0},competionPortThreads={1}", workerThreads, completionPortThreads);
        }
    }

    internal static class ExecutionContexts
    {
        public static void Go()
        {
            CallContext.LogicalSetData("Name", "Luqc");
            ThreadPool.QueueUserWorkItem((state) =>
            {
                Console.WriteLine("Name={0}", CallContext.LogicalGetData("Name"));
            });

            ExecutionContext.SuppressFlow();
            ThreadPool.QueueUserWorkItem((state) =>
            {
                Console.WriteLine("Name={0}", CallContext.LogicalGetData("Name"));
            });
        }
    }

    internal static class CancellationDemo
    {
        public static void Go()
        {
            CancellingAWorkItem();
        }

        private static void CancellingAWorkItem()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            ThreadPool.QueueUserWorkItem(o => Count(cts.Token, 1000));
            Console.WriteLine();
            Console.ReadLine();
            cts.Cancel();
            Console.ReadLine();
        }

        private static void Count(CancellationToken token, Int32 countTo)
        {
            for(Int32 count = 0; count < countTo; count++)
            {
                if(token.IsCancellationRequested)
                {
                    Console.WriteLine("Count is cancelled");
                    break;
                }
                Console.WriteLine(count);
                Thread.Sleep(1);
            }
            Console.WriteLine("Count is done");
        }
    }
}
