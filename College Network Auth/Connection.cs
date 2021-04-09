/** 对于socket进行一下简单封装方便使用 **/
/** Author: shinsya **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace College_Network_Auth
{
    class Connection
    {
        Socket client;
        IPEndPoint clientP;
        bool Inited = false;
        IPAddress addressBackup;
        int portBackup;
        public Connection(IPAddress Address, int port)
        {
            clientP = new IPEndPoint(Address, port);
            client = new Socket(clientP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            addressBackup = Address;
            portBackup = port;
            Inited = true;
        }

        public void Set(IPAddress Address, int port)
        {
            clientP = new IPEndPoint(Address, port);
            client = new Socket(clientP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            addressBackup = Address;
            portBackup = port;
            Inited = true;
        }

        public bool TryToConnect()
        {
            if (client == null)
            {
                if (Inited == false)
                    return false;
            }
            else
            {
                Set(addressBackup, portBackup);
            }
            try
            {
                client.Connect(clientP);
            }
            catch
            {
                return false;
            }
            return client.Connected;
        }

        public int Send(Byte [] Buffer, int DataLength)
        {
            try
            {
                return client.Send(Buffer, DataLength, SocketFlags.None);
            }
            catch
            {
                return -1;
            }
        }

        public int Recv(Byte [] Buffer, int MaxLength)
        {
            try
            {
                return client.Receive(Buffer, MaxLength, SocketFlags.None);
            }
            catch
            {
                return -1;
            }
        }

        public bool IsConnected()
        {
            return client.Connected;
        }

        public void Disconnect()
        {
            if (client.Connected)
            {
                client.Close();
            }
        }
    }
}
