using System;
using System.Net;
using System.Net.Sockets;

namespace SimpleServer
{
    class Program
    {
        private const int PORT = 1314;
        static void Main(string[] args)
        {
            Console.WriteLine("We are getting the server ready...");
            Socket sc = new Socket(SocketType.Stream, ProtocolType.Tcp);
            NetworkStream ns = null;
            sc.Bind(new IPEndPoint(IPAddress.Any, PORT));
            Console.WriteLine($"The server are listening for any request from port {PORT}");
            sc.Listen(3);
            try
            {
                ns = new NetworkStream(sc.Accept());
                ns.CopyTo(Console.OpenStandardOutput());
            }
            catch(Exception ex)
            {
                Console.WriteLine("\n\nSomething went wrong...");
                Console.WriteLine($"Exception type: {ex.GetType()}");
                Console.WriteLine($"\n\n\t{ex.StackTrace}");
            }
            finally
            {
                if (sc != null) sc.Close();
                if (ns != null) ns.Close();
            }

            Console.WriteLine("Bye bye!");
            
        }
    }
}
