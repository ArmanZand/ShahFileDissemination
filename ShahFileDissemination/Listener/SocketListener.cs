using ShahFileDissemination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Networking.Messages
{
    public class SocketListener : SocketEvents
    {
        private ManualResetEvent m_hangThread = new ManualResetEvent(false);
        private bool m_IsListening = true;
        public bool IsListening { get { return m_IsListening; } }
        public string IP = "127.0.0.1";
        public int Port = 0;
        

        protected internal delegate void HandleListenerStatus(bool listening,string ip, int port);
        protected internal event HandleListenerStatus Listening;
        protected void OnListeningStatus(bool listening,string ip, int port) => Listening?.Invoke(listening, ip, port);

        public SocketListener()
        {
            this.IP = DefaultParameters.ListenerIP;
            this.Port = DefaultParameters.ListenerPort;
        }
        public void SubscribeEvents(SocketHandle socketHandle)
        {
            socketHandle.Connected += OnConnected;
            socketHandle.Disconnected += OnDisconnected;
            socketHandle.Read += (handle, message) => OnRead(handle, message);
        }
        public void Start(string localAddress, int localPort)
        {
            try
            {
                Port = localPort;
                IP = localAddress;
                Thread listeningThread = new Thread(ListeningInstance);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(localAddress), localPort);
                listeningThread.Start(endPoint);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Stop()
        {
            m_IsListening = false;
            m_hangThread.Set();
        }

        private void AcceptSocket(SocketAsyncEventArgs e)
        {
            m_hangThread.Set();
            try
            {
                Socket pendingHandle = e.AcceptSocket;
                SocketHandle socketHandle = new SocketHandle
                {
                    Socket = pendingHandle,
                    EndPoint = pendingHandle.RemoteEndPoint
                };
                SubscribeEvents(socketHandle);
                if (!socketHandle.IsConnected) return;
                pendingHandle.BeginReceive(socketHandle.m_buffer, 0, SocketHandle.m_bufferSize, 0, socketHandle.ReceiveCallback, socketHandle);
            }
            catch(ArgumentException) { }
            catch(ObjectDisposedException) { }
            catch(SocketException) { }
            catch(Exception error)
            {
                Console.WriteLine(error);
            }
        }
        private void SocketEventArgs_Completed(object sender, SocketAsyncEventArgs e)
        {
            switch(e.LastOperation)
            {
                case SocketAsyncOperation.Accept:
                    switch (e.SocketError)
                    {
                        case SocketError.Success:
                            AcceptSocket(e);
                            break;
                        case SocketError.OperationAborted:
                            Console.WriteLine($"Socket aborted.");
                            break;
                        default:
                            Console.WriteLine($"Socket error: {e.SocketError}.");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine($"No implementation for socket operation: {e.LastOperation}.");
                    break;
            }
        }

        private void ListeningInstance(object endPoint)
        {
            IPEndPoint localEndPoint = endPoint as IPEndPoint;
            Socket listenSocket = new Socket(localEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(localEndPoint);
            listenSocket.Listen(100);
            OnListeningStatus(true,IP, Port);
            while (IsListening)
            {
                m_hangThread.Reset();
                SocketAsyncEventArgs socketEventArgs = new SocketAsyncEventArgs();
                socketEventArgs.Completed += SocketEventArgs_Completed;
                socketEventArgs.UserToken = listenSocket;
                listenSocket.AcceptAsync(socketEventArgs);
                m_hangThread.WaitOne();
            }
            listenSocket.Close();
            OnListeningStatus(false,IP, Port);
        }

    }
}
