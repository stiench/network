using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Common
{
    public class TCPClient
    {	
		private TcpClient _client;
		private Thread _thread;
		
		void Start()
		{
			Connect();
		}

		private void Connect()
		{
			try
			{
				_thread = new Thread(new ThreadStart(ListenForData));
				_thread.IsBackground = true;
				_thread.Start();
			}
			catch (Exception e)
			{
				Console.WriteLine("On client connect exception " + e);
			}
		}

		private void ListenForData()
		{
			try
			{
				_client = new TcpClient("localhost", 8052);
				Byte[] bytes = new Byte[1024];
				while (true)
				{		
					using (NetworkStream stream = _client.GetStream())
					{
						int length;			
						while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
						{
							var incommingData = new byte[length];
							Array.Copy(bytes, 0, incommingData, 0, length);			
							string serverMessage = Encoding.ASCII.GetString(incommingData);
							Console.WriteLine("Received : " + serverMessage);
						}
					}
				}
			}
			catch (SocketException socketException)
			{
				Console.WriteLine("Socket exception: " + socketException);
			}
		}

		private void Send(string message)
		{
			if (_client == null)
			{
				Connect();
			}
			try
			{		
				NetworkStream stream = _client.GetStream();
				if (stream.CanWrite)
				{
					byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(message);          
					stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
				}
			}
			catch (SocketException socketException)
			{
				Console.WriteLine("Socket exception: " + socketException);
			}
		}
	}
}
