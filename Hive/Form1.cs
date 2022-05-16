using Common;
using System;
using System.Windows.Forms;

namespace Hive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            UDP udp = new UDP();
            udp.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UDP.Send();
        }
    }
}
