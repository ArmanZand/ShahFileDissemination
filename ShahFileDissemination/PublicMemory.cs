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
}
