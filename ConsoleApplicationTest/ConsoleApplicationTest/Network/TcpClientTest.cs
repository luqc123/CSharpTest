using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ConsoleApplicationTest.Network
{
    public sealed class TcpClientTest
    {
        public static void Main()
        {
            IPEndPoint p = new IPEndPoint(0, 6000);
            Connect(p, "hell,world");
        }
        private static void Connect(IPEndPoint p, String message)
        {
            try
            {
                TcpClient client = new TcpClient(p);

                Byte[] data = Encoding.ASCII.GetBytes(message);

                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Send:{0}", message);

                data = new Byte[256];
                String responseData = String.Empty;
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received : {0}", responseData);

                stream.Close();
                client.Close();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("ArgumentNullException : {0}", e);
            }
            catch(SocketException e)
            {
                Console.WriteLine("SocketExceptiono : {0}", e);
            }
            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }
    }
}
