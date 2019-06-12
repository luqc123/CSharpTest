﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            TimerTest timerTest = new TimerTest();
            timerTest.SetTimer();
            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            timerTest.aTimer.Stop();
            timerTest.aTimer.Dispose();
            Console.WriteLine("Terminating the application...");
        }
    }
}
