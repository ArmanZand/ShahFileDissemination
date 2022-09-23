using Networking.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahFileDissemination
{
    internal class PublicMemory
    {
        public static List<SocketHandle> connectedHandles = new List<SocketHandle>();
        public static SocketListener Listener = new SocketListener();
    }
    public class DefaultParameters
    {
        public static string ListenerIP = "192.168.1.30";
        public static int ListenerPort = 4445;
        public static string RemoteIP = "192.168.1.30";
        public static int RemotePort = 4445;
        public static bool KeepReconnecting = true;
        public static int RetryPause = 1000;
    }
}
