using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking.Messages
{
    public class SocketEvents
    {
        protected internal delegate void HandleConnectedEvent(SocketHandle socketHandle);
        protected internal event HandleConnectedEvent Connected;
        protected internal delegate void HandleDisconnectedEvent(SocketHandle socketHandle);
        protected internal event HandleDisconnectedEvent Disconnected;
        protected internal delegate void HandleReadEvent(SocketHandle socketHandle, ProtobufMessage message);
        protected internal event HandleReadEvent Read;
        protected void OnConnected(SocketHandle socketHandle) => Connected?.Invoke(socketHandle);
        protected void OnDisconnected(SocketHandle socketHandle) => Disconnected?.Invoke(socketHandle);
        protected void OnRead(SocketHandle socketHandle, ProtobufMessage message) => Read?.Invoke(socketHandle, message);

        public Delegate[] ConnectedInvocationList()
        {
            return Connected.GetInvocationList();
        }
        public Delegate[] DisconnectedInvocationList()
        {
            return Disconnected.GetInvocationList();
        }
        public Delegate[] ReadInvocationList()
        {
            return Read.GetInvocationList();
        }
    }
}
