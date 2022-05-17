using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Common.UDP
{
    public static class UDPSender
    {
        public static void Send(Drone drone)
        {
            NetMessage msg = NetMessage.Serialize(drone);
            UdpClient client = new UdpClient();
            IPEndPoint ip = new IPEndPoint(address: IPAddress.Parse("255.255.255.255"), Config.GetInstance().GetIntValue("UPD_PORT_NUMBER"));
            client.Send(msg.Data, msg.Data.Length, ip);
            client.Close();
            Console.WriteLine("UDP Sent: {0} ", drone);
        }
    }
}
