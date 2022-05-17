using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Common.UDP
{
    public class UDPListener
    {
        private readonly UdpClient udp = new UdpClient(Config.GetInstance().GetIntValue("UPD_PORT_NUMBER"));
        
        public void Start()
        {
            Console.WriteLine("UDP Server Started");
            StartListening();
        }

        public void Stop()
        {
            try
            {
                udp.Close();
                Console.WriteLine("UDP Stopped listening");
            }
            catch { /* don't care */ }
        }

        private void StartListening()
        {
            udp.BeginReceive(Receive, new object());
        }

        private void Receive(IAsyncResult ar)
        {
            IPEndPoint ip = new IPEndPoint(address: IPAddress.Any, Config.GetInstance().GetIntValue("UPD_PORT_NUMBER"));
            Drone drone = NetMessage.Deserialize(udp.EndReceive(ar, ref ip)) as Drone;
            Drones.GetInstance().Add(drone);
            Console.WriteLine("UDP received: {0} ", drone);
            StartListening();
        }
    }
}
