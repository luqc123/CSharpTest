using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplicationTest.Generics;

namespace ConsoleApplicationTest
{
    class Program
    {
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

            var documentManager = new DocumentManager<Document>();
            documentManager.AddDocument(new Document("Title A", "Sample A"));
            documentManager.AddDocument(new Document("Title B", "Sample B"));
            documentManager.DisplayAllDocument();
            if(documentManager.IsDocumentAvailable)
            {
                var dm = documentManager.GetDocument();
                Console.WriteLine("Title is {0},Content is {1}", dm.Title, dm.Content);
            }

            //ActionTest
            //ActionTest actionTest = new ActionTest();
            //actionTest.Test();            
        }
    }
}
