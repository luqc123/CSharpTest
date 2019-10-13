using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApplicationTest
{
    public class LinqXmlTest
    {
        public static void Test1()
        {
            XElement xmlTree1 = new XElement("Root",
                new XElement("Child1", 1),
                new XElement("Child2", 2),
                new XElement("Child3", 3),
                new XElement("Child3", 4),
                new XElement("Child3", 5),
                new XElement("Child4", 6));

            XElement xmlTree2 = new XElement("Root",
                from el in xmlTree1.Elements()
                where ((int)el >= 3 && (int)el <= 6)
                select el);

            Console.WriteLine(xmlTree2);
        }

        public static void Test2()
        {
            XNamespace aw = "http://www.croot.com";

            XElement xmlTree1 = new XElement(aw + "Root",
                new XElement("Child1",1),
                new XElement("Child2",2),
                new XElement("Child3",3)
                );

            XElement xmlTree2 = new XElement(aw + "Root",
                from el in xmlTree1.Elements()
                where ((int)el > 0 && (int)el < 3)
                select el
                );

            Console.WriteLine(xmlTree2);
        }

        public static void Test3()
        {
            XElement root1 = XElement.Parse("<Root Att1 = 'abc'/>");
            XElement root2 = new XElement(root1);
            if (root1.Attribute("Att1") == root2.Attribute("Att1"))
                Console.WriteLine("this won't be printed");
            else
                Console.WriteLine("root2 is a deep copy from root1");
        }

        public static void Test4()
        {
            XElement root;
            double dbl = 12.1233;
            XAttribute[] attArray =
            {
                new XAttribute("Att1",1),
                new XAttribute("Att2",2)
            };
            DateTime dt = DateTime.Now;

            //Attribute can't repeat in same XElement
            root = new XElement("Root",
                new XAttribute("Att3", "Some"),
                new XAttribute("Att4",dt), 
                attArray,
                dbl,
                XElement.Parse("<R/>")
                );
            Console.WriteLine(root);
        }

        public static void Test5()
        {
            XDocument srcTree = new XDocument(
                new XComment("this is a comment"),
                new XElement("Root",
                    new XElement("Child1",1),
                    new XElement("Child2",
                        new XAttribute("Att1","abc"),
                        new XAttribute("Att2","abcd"),
                        2)
                ));

            Console.WriteLine(srcTree);
            Console.WriteLine(srcTree.FirstNode);
            srcTree.AddFirst(new XComment("df2"));
            XElement xElement = srcTree.Element("Root").Element("Child2");
            if (xElement != null)
                xElement.AddAfterSelf(new XElement("Child3", 3));
            Console.WriteLine(srcTree);
        }


    }
}