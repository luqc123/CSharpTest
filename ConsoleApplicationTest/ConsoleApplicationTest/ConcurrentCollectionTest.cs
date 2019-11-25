using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    public sealed class ConcurrentCollectionTest
    {
        public static void Main()
        {
        }

    }
}

    public class Info
    {
        public String Word { get; set; }
        public int Count { get; set; }
        public String Color { get; set; }

        public override string ToString()
        {
            return String.Format("{0} times: {1}", Word, Count);
        }
    }

    public class ConsoleHelper
    {
        private static object syncOutput = new object();

        public static void WriteLine(String Message)
        {
            lock (syncOutput)
                Console.WriteLine(Message);
        }

        public static void WriteLine(String message, String color)
        {
            lock(syncOutput)
            {
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
    }

    public static class ConcurrentDictionaryExtension
    {
        public static void AddOrIncrementValue(this ConcurrentDictionary<String, Int32> dict, String key)
        {
            bool success = false;
            while (!success)
            {
                Int32 value;
                if (dict.TryGetValue(key, out value))
                {
                    if (dict.TryUpdate(key, value + 1, value))
                    {
                        success = true;
                    }
                }
                else
                {
                    if (dict.TryAdd(key, 1))
                    {
                        success = true;
                    }
                }
            }
        }
    }

