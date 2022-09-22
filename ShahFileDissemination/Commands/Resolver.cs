using Networking.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Commands
{
    public class Resolver
    {
        public static void Execute(SocketHandle socketHandle, ProtobufMessage pm)
        {
            try
            {
                
            }
            catch(KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static volatile Dictionary<ProtobufMessage.CommandOneofCase, Action<SocketHandle, ProtobufMessage>> command
        = new Dictionary<ProtobufMessage.CommandOneofCase, Action<SocketHandle, ProtobufMessage>> {
            [ProtobufMessage.CommandOneofCase.None] = Commands.NullCommand,
            [ProtobufMessage.CommandOneofCase.ExampleMessage] = Commands.ExampleCommand,
        };
        private class Commands
        {
            public static void NullCommand(SocketHandle sh, ProtobufMessage pm)
            {
                throw new NotImplementedException();
            }
            public static void ExampleCommand(SocketHandle sh , ProtobufMessage pm)
            {
                ExampleMessage rm = pm.ExampleMessage;
                MessageBox.Show(rm.Message);
            }
        }
    }
}
