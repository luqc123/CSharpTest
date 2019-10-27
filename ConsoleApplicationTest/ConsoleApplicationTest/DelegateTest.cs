using System;
using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Reflection;
using System.Threading;
using System.Linq;

namespace ConsoleApplicationTest
{
    public sealed class DelegateTest
    {
        public static void Main()
        {
            //StaticDelegateDemo();
            //InstanceDelegateDemo();
            //ChainDelegateDemo1(new DelegateTest());
            //ChainDelegateDemo2(new DelegateTest());
            //GetInvocationList.Go();
            //AnonymousMethods.Go();
            //String[] s = new string[] { "TwoInt32s", "Add", "123", "321" };
            //DelegateReflection.Go(s);
            DelegateReflection.Go("TwoInt32s", "Add", "123", "321");
        }

        internal delegate void FeedBack(Int32 value);

        private static void StaticDelegateDemo()
        {
            Console.WriteLine("Start Static Deletate Demo...");
            Counter(1, 3, new FeedBack(DelegateTest.FeedBackToConsole));
            Counter(1, 3, new FeedBack(FeedBackToMessageBox));
            Console.WriteLine();
        }
        private static void InstanceDelegateDemo()
        {
            Console.WriteLine("Start Instance Deletate Demo...");
            DelegateTest t = new DelegateTest();
            Counter(1, 3, t.FeedBackToFile);
            Console.WriteLine();
        }
        private static void ChainDelegateDemo1(DelegateTest t)
        {
            Console.WriteLine("Start Chain Delegate Demo1...");
            FeedBack fb1 = new FeedBack(t.FeedBackToFile);
            FeedBack fb2 = new FeedBack(FeedBackToConsole);
            FeedBack fb3 = new FeedBack(FeedBackToMessageBox);
            FeedBack fbChain = null;
            fbChain = (FeedBack)Delegate.Combine(fbChain, fb1);
            fbChain = (FeedBack)Delegate.Combine(fbChain, fb2);
            fbChain = (FeedBack)Delegate.Combine(fbChain, fb3);
            //Counter(1, 2, fbChain);
            Console.WriteLine();
            fbChain = (FeedBack)Delegate.Remove(fbChain,fb1);
            fbChain = (FeedBack)Delegate.Remove(fbChain,new FeedBack(FeedBackToMessageBox));
            Counter(1, 2, fbChain);
        }
        private static void ChainDelegateDemo2(DelegateTest t)
        {
            FeedBack fb = null;
            fb += new FeedBack(t.FeedBackToFile);
            fb += new FeedBack(FeedBackToConsole);
            fb += new FeedBack(FeedBackToMessageBox);
            Counter(3, 4, fb);
            fb -= new FeedBack(FeedBackToMessageBox);
            Counter(5, 6, fb);
        }
        private static void Counter(Int32 from,Int32 to,FeedBack fb)
        {
            for(Int32 value = from;value <= to;value++)
            {
                if (fb != null)
                    fb.Invoke(value);
            }
        }
        private static void FeedBackToConsole(Int32 value)
        {
            Console.WriteLine("Item={0}", value);
        }
        private static void FeedBackToMessageBox(Int32 value)
        {
            MessageBox.Show("Item="+value);
        }
        private void FeedBackToFile(Int32 value)
        {
            using (StreamWriter sw = new StreamWriter("Status", true))
            {
                sw.WriteLine("Item={0}", value);
            }
        }
    }

    internal static class GetInvocationList
    {
        internal sealed class Light
        {
            public String SwitchPosition()
            {
                return "The light is off";
            }
        }

        internal sealed class Fan
        {
            public String Speed()
            {
                throw new InvalidOperationException("The fan broke due to overheating.");
            }
        }

        internal sealed class Speaker
        {
            public String Volume()
            {
                return "The volume is loud";
            }
        }

        private delegate String GetStatus();

        public static void Go()
        {
            GetStatus getStatus = null;
            getStatus += new GetStatus(new Light().SwitchPosition);
            getStatus += new GetStatus(new Fan().Speed);
            getStatus += new GetStatus(new Speaker().Volume);
            Console.WriteLine(GetComponentStatusReport(getStatus));
        }

        private static String GetComponentStatusReport(GetStatus status)
        {
            if (status == null) return null;
            StringBuilder report = new StringBuilder();
            Delegate[] arrayOfDelegates = status.GetInvocationList();
            foreach(GetStatus getStatus in arrayOfDelegates)
            {
                try
                {
                    report.AppendFormat("{0}{1}{1}", getStatus(), Environment.NewLine);
                }catch(InvalidOperationException e)
                {
                    Object component = getStatus.Target;
                    report.AppendFormat("Failed to get status from {1}{2}{0} Error: {3}{0}{0}",
                        Environment.NewLine,
                        (component == null ? "" : component.GetType() + "."),
                        getStatus.GetMethodInfo().Name,e.Message);
                }
            }
            return report.ToString();
        }
    }

    internal static class AnonymousMethods
    {
        public static void Go()
        {
            String[] names = { "Jeff", "Kristin", "Aidan" };
            Char charToFind = 'i';
            names = Array.FindAll(names, delegate (String name) { return name.IndexOf(charToFind) >= 0; });
            names = Array.ConvertAll<String, String>(names, delegate (String name) { return name.ToUpper(); });
            Array.Sort(names, delegate (String name1, String name2) { return String.Compare(name1, name2); });
            Array.ForEach(names, delegate (String name) { Console.WriteLine(name); });
            AClass.CallBackWithoutNewingADelegateObject();
            AClass2.UsingLocalVariblesInTheCallbackCode(20);
        }

        sealed class AClass
        {
            public static void CallBackWithoutNewingADelegateObject()
            {
                ThreadPool.QueueUserWorkItem(delegate (Object obj) { Console.WriteLine(obj); }, 5);
            }
        }

        sealed class AClass2
        {
            public static void UsingLocalVariblesInTheCallbackCode(Int32 numToDo)
            {
                Int32[] squares = new Int32[numToDo];
                AutoResetEvent done = new AutoResetEvent(false);
                for(Int32 n = 0; n < squares.Length;n++)
                {
                    ThreadPool.QueueUserWorkItem(delegate (Object obj)
                    {
                        Int32 num = (Int32)obj;
                        squares[num] = num * num;
                        if (Interlocked.Decrement(ref numToDo) == 0)
                            done.Set();
                    }, n);
                }

                done.WaitOne();

                for(Int32 n = 0; n < squares.Length;n++)
                {
                    Console.WriteLine("Index {0},Square={1}", n, squares[n]);
                }
            }
        }
    }

    internal delegate Object TwoInt32s(Int32 n1, Int32 n2);
    internal delegate Object OneString(String s1);



    internal static class DelegateReflection
    {
        public static void Go(params String[] s)
        {
            //get type
            Type delType = Type.GetType(s[0]);
            if (delType == null)
            {
                Console.WriteLine("Invaild delType argument: " + s[0]);
                return;
            }

            Delegate d;
            try
            {
                MethodInfo mi = typeof(DelegateReflection).GetTypeInfo().GetDeclaredMethod(s[1]);
                d = mi.CreateDelegate(delType);
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Invaild methodName argument:" + s[1]);
                return;
            }

            //get parameters
            object[] callbackArgs = new object[s.Length - 2];
            if (d.GetType() == typeof(TwoInt32s))
            {
                try
                {
                    for (Int32 a = 2; a < s.Length; a++)
                    {
                        callbackArgs[a - 2] = Int32.Parse(s[a]);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Parameters must be integers.");
                    return;
                }
            }

            if(d.GetType()==typeof(OneString))
            {
                Array.Copy(s, 2, callbackArgs, 0, callbackArgs.Length);
            }

            //dynamic invoke
            try
            {
                Object result = d.DynamicInvoke(callbackArgs);
                Console.WriteLine("Result= " + result);
            }catch(TargetParameterCountException)
            {
                Console.WriteLine("Incorrect number of parameters specified.");
            }

        }
        private static Object Add(Int32 n1, Int32 n2)
        {
            return n1 + n2;
        }
        private static Object Substract(Int32 n1,Int32 n2)
        {
            return n1 - n2;
        }
        private static Object NumChars(String s1)
        {
            return s1.Length;
        }
        private static Object Reverse(String s1)
        {
            return new String(s1.Reverse().ToArray());
        }
    }
}
