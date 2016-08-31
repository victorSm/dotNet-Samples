using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace cvx200datamgr_02
{
    class SocketSender
    {
        private string hostAddress = "";
        private Int32 portNumber = 0;
        public SocketSender(string ip, Int32 port)
        {
            hostAddress = ip;
            portNumber = port;
        }
        public void SendData(String output)
        {
            byte[] byteArray = new byte[1024];

            try
            {
                IPAddress ipAddress = IPAddress.Parse(hostAddress);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, portNumber);

                Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    sender.Connect(remoteEP);
                    Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());

                    byte[] msg = Encoding.ASCII.GetBytes(output);
                    int bytesSent = sender.Send(msg);
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException: {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException: {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected Exception: {0}", e.ToString());
                }
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }
    }
}
