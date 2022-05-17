using Common.UDP;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Hive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UDPListener _udp;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            _udp = new UDPListener();
            _udp.Start();

            //TCPClient.StartClient();
        }
    }
}
