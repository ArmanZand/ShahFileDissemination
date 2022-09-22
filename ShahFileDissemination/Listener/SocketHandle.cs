using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Google.Protobuf;
using System.Threading.Tasks;
using System.Threading;

namespace Networking.Messages
{
    public class SocketHandle : SocketEvents
    {
        public static volatile int m_bufferSize = 1024;
        private static volatile byte[] EOFSignature = { 0x45, 0x4F, 0x46 };
        public byte[] m_buffer = new byte[m_bufferSize];
        private byte[] m_message = new byte[0];
        private bool m_isConnected;

        private bool m_isInitiator = false;
        public EndPoint EndPoint { get; set; }
        public Socket Socket { get; set; }
        public bool isConnected
        {
            get
            {
                bool actuallyConnected = false;
                try
                {
                    actuallyConnected = !(Socket.Poll(1000, SelectMode.SelectRead) && Socket.Available == 0);
                }catch (SocketException) { }
                catch (NullReferenceException) { }
                catch (ObjectDisposedException) { }
                finally
                {
                    if(m_isConnected != actuallyConnected)
                    {
                        if (actuallyConnected) OnConnected(this);
                        else OnDisconnected(this);
                        m_isConnected = actuallyConnected;
                    }
                }
                return actuallyConnected;
            }
        }

        

        public void Send(ProtobufMessage message)
        {
            if (!isConnected) return;
            byte[] b_msg = message.ToByteArray();
            Array.Resize(ref b_msg, b_msg.Length + EOFSignature.Length);
            Buffer.BlockCopy(EOFSignature, 0, b_msg, b_msg.Length - EOFSignature.Length, EOFSignature.Length);
            Socket.Send(b_msg);
        }
        private void EOFCheck()
        {
            if (m_message.Length <= EOFSignature.Length) return;
            for (int i = 0; i < EOFSignature.Length; i++)
            {
                if (m_message[m_message.Length - EOFSignature.Length + i] != EOFSignature[i])
                {
                    return;
                }
            }
            Array.Resize(ref m_message, m_message.Length - EOFSignature.Length);
            try
            {
                ProtobufMessage pm = ProtobufMessage.Parser.ParseFrom(m_message);
                OnRead(this, pm);
            }catch(InvalidProtocolBufferException e)
            {
                Console.WriteLine(e.Message);
            }
            Array.Clear(m_buffer, 0, m_buffer.Length);
            Array.Resize(ref m_message, 0);
        }

        public void ReceiveCallback(IAsyncResult ar)
        {
            SocketHandle socketHandle = ar.AsyncState as SocketHandle;
            if (!isConnected) return;
            int bytesReceived = Socket.EndReceive(ar);
            if (bytesReceived <= 0) return;
            if(m_message.Length == 0)
            {
                m_message = new byte[bytesReceived];
                Buffer.BlockCopy(m_buffer, 0, m_message, 0, bytesReceived);
            }else
            {
                Array.Resize(ref m_message, m_message.Length + bytesReceived);
                Buffer.BlockCopy(m_buffer, 0, m_message, m_message.Length - bytesReceived, bytesReceived);
            }
            EOFCheck();
            Socket.BeginReceive(m_buffer, 0, m_bufferSize, 0, result => ReceiveCallback(result), ar);
        }

        public void Connect(string remoteAddress, int remotePort)
        {
            Thread connectionThread = new Thread(ConnectionInstance);
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(remoteAddress), remotePort);
            connectionThread.Start(remoteEP);
        }
        private void ConnectionInstance(object param)
        {
            
        }

    }
}
