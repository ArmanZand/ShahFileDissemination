namespace Networking.Messages
{
    public class SocketEvents
    {
        protected internal delegate void HandleConnectedEvent(SocketHandle socketHandle);
        protected internal event HandleConnectedEvent Connected;
        protected internal delegate void HandleDisconnectedEvent(SocketHandle socketHandle);
        protected internal event HandleDisconnectedEvent Disconnected;
        protected internal delegate void HandleReadEvent(SocketHandle socketHandle, ProtobufMessage message);
        protected internal event HandleReadEvent Receive;
        protected internal delegate void HandleReady(SocketHandle socketHandle, bool initiator);
        protected internal event HandleReady Ready;
        protected void OnConnected(SocketHandle socketHandle) => Connected?.Invoke(socketHandle);
        protected void OnDisconnected(SocketHandle socketHandle) => Disconnected?.Invoke(socketHandle);
        protected void OnReceive(SocketHandle socketHandle, ProtobufMessage message) => Receive?.Invoke(socketHandle, message);
        protected void OnReady(SocketHandle socketHandle, bool initiator) => Ready?.Invoke(socketHandle, initiator);
    }
}
