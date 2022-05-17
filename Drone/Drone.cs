using Common.TCP;
using Common.UDP;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Drone
{
    public partial class Drone : Form
    {
        public Drone()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                TCPServer.StartListening();
            }).Start();
        }

        private void udp_Tick(object sender, EventArgs e)
        {
            UDPSender.Send(new Common.Drone("127.0.0.1"));
        }
    }
}
