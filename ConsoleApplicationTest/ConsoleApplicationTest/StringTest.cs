using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    public class StringTest
    {
        public static void StringTest1()
        {
            char[] words = { 'w', 'o', 'r', 'd' };
            string word = new string(words);
            Console.WriteLine(word);

            string string1 = new string('c', 30);
            Console.WriteLine(string1);

            sbyte[] bytes = { 0x41, 0x42, 0x43, 0x44, 0x45, 0x00 };

            string stringFromBytes = null;
            string stringFromChars = null;
            unsafe
            {
                fixed (sbyte* pbytes = bytes)
                {
                    stringFromBytes = new string(pbytes);
                }
                fixed (char* pchars = words)
                {
                    stringFromChars = new string(pchars);
                }
            }
            Console.WriteLine(stringFromBytes);
            Console.WriteLine(stringFromChars);
        }

        public static void StringTest2()
        {
            string sentence = "This sentence has five words.";
            int startPosition = sentence.IndexOf(" ") + 1;
            string word = sentence.Substring(startPosition,
                sentence.IndexOf(" ", startPosition) - startPosition);
            Console.WriteLine("Second word: " + word);
        }

        public static void StringTest3()
        {
            DateTime dateAndTime = new DateTime(2019, 10, 7, 22, 16, 0);
            double temperature = 68.3;
            string result = String.Format("At {0:t} on {0:D},the temperature is {1:F1} degrees.", dateAndTime, temperature);
            Console.WriteLine(result);
        }
        public static void StringTest4()
        {
            string s1 = "abcd";
            string s2 = "";
            string s3 = null;

            Console.WriteLine("String s1: {0}", Test(s1));
            Console.WriteLine("String s2: {0}", Test(s2));
            Console.WriteLine("String s3: {0}", Test(s3));
        }

        static String Test(string s)
        {
            if (String.IsNullOrEmpty(s))
                return "is null or empty";
            else
                return String.Format("(\"{0}\") is neither null nor empty", s);
        }

        static bool Test2(string s)
        {
            return String.IsNullOrEmpty(s) || s.Trim().Length == 0;
        }

        public static void StringTest5()
        {
            string[] values = {null,
                String.Empty,
                "ABCDE",
                new String(' ',10),
                "  \t  ",
                new String('\u2000',10)};

            foreach (var value in values)
            {
                Console.WriteLine(String.IsNullOrWhiteSpace(value));
                Console.WriteLine(Test2(value));
            }
        }
    }
}
