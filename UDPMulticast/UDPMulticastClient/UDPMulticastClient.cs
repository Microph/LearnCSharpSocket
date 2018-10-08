using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class UDPMulticastClient
{
    public static void Main()
    {
        UdpClient subscriber = new UdpClient(8899);
        IPAddress addr = IPAddress.Parse("230.0.0.1");
        subscriber.JoinMulticastGroup(addr);
        IPEndPoint ep = null;
        for (int i = 0; i < 10; i++)
        {
            byte[] pdata = subscriber.Receive(ref ep);
            string price = Encoding.ASCII.GetString(pdata);
            Console.WriteLine(price);
        }
        subscriber.DropMulticastGroup(addr);
    }
}