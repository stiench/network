using Common;
using Common.TCP;
using Common.UDP;
using System;
using System.Windows.Forms;

namespace Hive
{
    public partial class Hive : Form
    {
        public Hive()
        {
            InitializeComponent();

            UDPListener udp = new UDPListener();
            udp.Start();

            //TCPClient.StartClient();
        }
    }
}
