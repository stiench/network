using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Common
{
    public class UDP
    {
        Thread t = null;
        public void Start()
        {
            if (t != null)
            {
                throw new Exception("Already started, stop first");
            }
            Console.WriteLine("Started listening");
            StartListening();
        }
        public void Stop()
        {
            try
            {
                udp.Close();
                Console.WriteLine("Stopped listening");
            }
            catch { /* don't care */ }
        }

        private readonly UdpClient udp = new UdpClient(Config.GetInstance().GetIntValue("UPD_PORT_NUMBER"));
        IAsyncResult ar_ = null;

        private void StartListening()
        {
            ar_ = udp.BeginReceive(Receive, new object());
        }
        private void Receive(IAsyncResult ar)
        {
            IPEndPoint ip = new IPEndPoint(address: IPAddress.Any, Config.GetInstance().GetIntValue("UPD_PORT_NUMBER"));
            byte[] bytes = udp.EndReceive(ar, ref ip);
            string id = Encoding.ASCII.GetString(bytes);
            Drones.GetInstance().Add(id, ip.Address.ToString());
            Console.WriteLine("From {0} received: {1} ", ip.Address.ToString(), id);
            StartListening();
        }
        public static void Send()
        {
            var id = Helpers.GetComputerId();
            UdpClient client = new UdpClient();
            IPEndPoint ip = new IPEndPoint(address: IPAddress.Parse("255.255.255.255"), Config.GetInstance().GetIntValue("UPD_PORT_NUMBER"));
            byte[] bytes = Encoding.ASCII.GetBytes(id);
            client.Send(bytes, bytes.Length, ip);
            client.Close();
            Console.WriteLine("Sent: {0} ", id);
        }
    }
}
