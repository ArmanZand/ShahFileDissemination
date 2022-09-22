using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking.Messages
{
    public class SocketHandle : SocketEvents
    {
        public static volatile int m_bufferSize = 1024;
        private static volatile byte[] EOFSignature = { 0x45, 0x4F, 0x46 };
        public byte[] m_buffer = new byte[m_bufferSize];
        private byte[] m_message = new byte[0];
        private bool m_isConnected;

    }
}
