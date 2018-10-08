using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class UDPMulticastServer
{
    static string[] symbols = { "ABCD", "EFGH", "IJKL", "MNOP" };
    public static void Main()
    {
        UdpClient publisher = new UdpClient("230.0.0.1", 8899);
        Console.WriteLine("Publishing stock prices to 230.0.0.1:8899");
        Random gen = new Random();
        while (true)
        {
            int i = gen.Next(0, symbols.Length);
            double price = 400 * gen.NextDouble() + 100;
            string msg = String.Format("{0} {1:#.00}", symbols, price);
            byte[] sdata = Encoding.ASCII.GetBytes(msg);
            publisher.Send(sdata, sdata.Length);
            System.Threading.Thread.Sleep(5000);
        }
    }
}