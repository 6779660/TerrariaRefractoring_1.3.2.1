using System;
using System.Net.Sockets;
namespace Terraria
{
	public class ClientSock
	{
		public TcpClient tcpClient = new TcpClient();
		public NetworkStream networkStream;
		public string statusText;
		public int statusCount;
		public int statusMax;
		public int timeOut;
		public byte[] readBuffer;
		public byte[] writeBuffer;
		public bool active;
		public bool locked;
		public int state;
		public void ClientWriteCallBack(IAsyncResult ar)
		{
			NetMessage.buffer[256].spamCount--;
		}
		public void ClientReadCallBack(IAsyncResult ar)
		{
			if (!Netplay.disconnect)
			{
				int num = this.networkStream.EndRead(ar);
				if (num == 0)
				{
					Netplay.disconnect = true;
					Main.statusText = "Lost connection";
				}
				else
				{
                    if (Main.ignoreErrors)
                    {
                        try
                        {
                            NetMessage.RecieveBytes(this.readBuffer, num, 256);
                        }
                        catch { }
                        this.locked = false;
                    }
                    else
                    {
                        NetMessage.RecieveBytes(this.readBuffer, num, 256);
                    }
				}
                //this.locked = false; ??
			}
		}
	}
}
