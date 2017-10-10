using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLib;

namespace PlainUDPSender
{
    class UDPSender
    {
        private readonly int PORT;

        public UDPSender(int port)
        {
            PORT = port;
        }
        public void Start()
        {
            Car tesla = new Car("Tesla", "Red", "EL23400");

            String SenderStr = tesla.ToString();
            byte[] buffer = Encoding.ASCII.GetBytes(SenderStr);

            using (UdpClient client = new UdpClient())
            {
                IPEndPoint OtherEP = new IPEndPoint(IPAddress.Broadcast, PORT);
                client.Send(buffer, buffer.Length, OtherEP);

                IPEndPoint ReceiverEP = new IPEndPoint(IPAddress.Any, PORT);
                byte[] receivebuffer = client.Receive(ref ReceiverEP);
                Console.WriteLine($"Udp datagram received lgt = {receivebuffer.Length}");
                String incommingStr = Encoding.ASCII.GetString(receivebuffer);
                Console.WriteLine(incommingStr);
            }
            Console.ReadLine();

        }
    }
}
