using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Common
{
    public class TCPServer
    {
		private TcpListener _server;
		private Thread _thread;
		private TcpClient _client;

		void Start()
		{
			_thread = new Thread(new ThreadStart(Listen));
			_thread.IsBackground = true;
			_thread.Start();
		}

		private void Listen()
		{
			try
			{	
				_server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8052);
				_server.Start();
				Console.WriteLine("Server is listening");
				Byte[] bytes = new Byte[1024];
				while (true)
				{
					using (_client = _server.AcceptTcpClient())
					{				
						using (NetworkStream stream = _client.GetStream())
						{
							int length;					
							while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
							{
								var incommingData = new byte[length];
								Array.Copy(bytes, 0, incommingData, 0, length);						
								string clientMessage = Encoding.ASCII.GetString(incommingData);
								Console.WriteLine("Received : " + clientMessage);
							}
						}
					}
				}
			}
			catch (SocketException socketException)
			{
				Console.WriteLine("SocketException " + socketException.ToString());
			}
		}

		private void Send(string message)
		{
			if (_client == null)
			{
				Start();
			}

			try
			{		
				NetworkStream stream = _client.GetStream();
				if (stream.CanWrite)
				{          
					byte[] serverMessageAsByteArray = Encoding.ASCII.GetBytes(message);           
					stream.Write(serverMessageAsByteArray, 0, serverMessageAsByteArray.Length);
				}
			}
			catch (SocketException socketException)
			{
				Console.WriteLine("Socket exception: " + socketException);
			}
		}
	}
}
