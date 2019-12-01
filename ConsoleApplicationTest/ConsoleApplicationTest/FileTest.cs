using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    public sealed class FileTest
    {
        public static void Main()
        {
            FileStream fileStream = new FileStream("ReadMe.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            byte[] data = new byte[] {1,2,4};
            fileStream.Write(data, 0, data.Length);
            fileStream.Close();

            FileInfo myFile = new FileInfo(@"ReadMe.txt");
            Console.WriteLine(myFile.FullName);
            Console.WriteLine(myFile.Name);
            Console.WriteLine(myFile.Extension);
            Console.WriteLine(myFile.DirectoryName);
            Console.WriteLine(myFile.Exists);
            Console.WriteLine(myFile.CreationTime);

            Console.WriteLine("\n");

            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Program Files");

            Console.WriteLine($"{directoryInfo.FullName}");
            Console.WriteLine($"{directoryInfo.CreationTime}");
            Console.WriteLine($"{directoryInfo.Name}");
            Console.WriteLine($"{directoryInfo.LastWriteTime}");
            Console.WriteLine($"{directoryInfo.Extension}");
            Console.WriteLine($"{directoryInfo.Parent}");
            Console.WriteLine($"{directoryInfo.Root}");
            Console.WriteLine($"{directoryInfo.GetFiles()}");
            Console.WriteLine($"{directoryInfo.GetDirectories()}");

            DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();
            Console.WriteLine(directoryInfos.Length);
            foreach (var d in directoryInfos)
                Console.WriteLine(d.FullName);
            FileInfo[] fileInfos = directoryInfo.GetFiles();
            Console.WriteLine(fileInfos.Length);
            foreach (var f in fileInfos)
                Console.WriteLine(f.FullName);
        }
    }
}
