using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplicationTest.Generics;
using System.Windows;
using ConsoleApplicationTest.TheadTest;

namespace ConsoleApplicationTest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //AttributeTest
            //AttributeTest attributeTest = new AttributeTest();
            //attributeTest.TestAttributeUsage();

            //LambdaTest
            //LambdaTest lambdaTest = new LambdaTest();
            //lambdaTest.Test();

            //TimerTest
            //TimerTest timerTest = new TimerTest();
            //timerTest.SetTimer();
            //Console.WriteLine("\nPress the Enter key to exit the application...\n");
            //Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            //Console.ReadLine();
            //timerTest.aTimer.Stop();
            //timerTest.aTimer.Dispose();
            //Console.WriteLine("Terminating the application...");

            //ObservableCollectionTest
            //CollectionTest collectionTest = new CollectionTest();
            //collectionTest.ObservableCollectionTest();

            //ListTest
            //var doubleList = new Generics.DoubleListT<int>();
            //doubleList.AddLast(1);
            //doubleList.AddLast(2);
            //doubleList.AddLast(3);

            //foreach (var i in doubleList)
            //    Console.WriteLine(i);

            //var documentManager = new DocumentManager<Document>();
            //documentManager.AddDocument(new Document("Title A", "Sample A"));
            //documentManager.AddDocument(new Document("Title B", "Sample B"));
            //documentManager.DisplayAllDocument();
            //if(documentManager.IsDocumentAvailable)
            //{
            //    var dm = documentManager.GetDocument();
            //    Console.WriteLine("Title is {0},Content is {1}", dm.Title, dm.Content);
            //}

            //ActionTest
            //ActionTest actionTest = new ActionTest();
            //actionTest.Test();            

            //Delegate Test
            //DelegateTest delegateTest = new DelegateTest();
            //delegateTest.Test();
            // error
            //var v = x => x;

            //DependencyProperty Test
            //DependencyPropertyTest dpt = new DependencyPropertyTest();
            //dpt.Test();

            //var obj = new DependencyPropertyTest();
            //obj.ValueChanged += (send,e) =>
            //{
            //    Console.WriteLine("value changed from {0} to {1}", e.OldValue, e.NewValue);
            //};
            //obj.MyValue = 23;
            //Console.WriteLine(obj.Maximum);
            //obj.MyValue = 223;
            //Console.WriteLine(obj.MyValue);

            //ArrayTest
            //ArrayTest.InitTest();
            //ArrayTest.Test1();
            //ArrayTest.MultiArrayTest();

            //StringTest.StringTest1();
            //StringTest.StringTest2();
            //StringTest.StringTest3();
            //StringTest.StringTest4();
            //StringTest.StringTest5();
            //StringBuilder sp = new StringBuilder();

            //sp.Append("symbolname+errmessage");
            //sp.AppendLine();
            //sp.Append("symbolname+errmessage");
            //sp.AppendLine();
            //sp.Append("symbolname+errmessage");
            //sp.AppendLine();
            //sp.Append("symbolname+errmessage");
            //sp.AppendLine();

            //string msg = sp.ToString();

            //MessageBoxResult result = MessageBox.Show(msg,"YES",MessageBoxButton.YesNo,MessageBoxImage.Information,MessageBoxResult.OK);

            //if (result == MessageBoxResult.Yes)
            //    Console.WriteLine("Yes");
            //else
            //    Console.WriteLine("No");

            //ExpressionTest.Test();

            //LinqXmlTest.Test1();
            //LinqXmlTest.Test2();
            //LinqXmlTest.Test3();
            //LinqXmlTest.Test4();
            //LinqXmlTest.Test5();
            //LinqTest.Test1();
            //TupleTest.Test1();
            //DictionaryTest.Test1();
            //StringTest.Test6();
            //HashSetTest.Test1();
            //TupleTest.Test2();
            //ClassTest.Main();
            //GenericTest.Main();
            //Network.TcpClientTest.Main();
            //DelegateTest.Main();
            //BaseThread.Main();
            //ThreadSync.Main();
            //Events.Main();
            //ThreadASync.Main();
            PrimitiveReferenceValueTypesTest.Main();
        }
    }
}
