using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PlainUDPReceiver
{
    class UDPReceiver
    {
        private readonly int PORT;

        public UDPReceiver(int port)
        {
            PORT = port;
        }
        public void Start()
        {
            byte[] buffer = new byte[2048];

            using (UdpClient client = new UdpClient(PORT))
            {
                IPEndPoint senderEP = new IPEndPoint(IPAddress.Any, PORT);

                buffer = client.Receive(ref senderEP);
                Console.WriteLine($"UDP Datagram received lgt={buffer.Length}");
                Console.WriteLine($"Afsender {senderEP.Address}, port {senderEP.Port}");

                String incommingStr = Encoding.ASCII.GetString(buffer);
                Console.WriteLine(incommingStr);
                    

                String OutgoingStr = incommingStr.ToUpper();
                byte[] outBuffer = Encoding.ASCII.GetBytes(OutgoingStr);

                client.Send(outBuffer, outBuffer.Length, senderEP);

                
            }
            Console.ReadLine();
        }
    }
}
