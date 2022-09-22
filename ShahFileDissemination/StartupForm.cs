using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommandLine;
using Commands;
using Networking.Messages;

namespace ShahFileDissemination
{

    public partial class StartupForm : Form
    {
        public StartupForm(string[] args)
        {
            InitializeComponent();
            Parser.Default.ParseArguments<Options>(args).WithParsed(RunOptions).WithNotParsed(HandleParseError);
        }
        private void RunOptions(Options parseResults)
        {
            if (parseResults.cl_ip_port != null)
            {
                string[] inputAddress = parseResults.cl_ip_port.Split(':');
                PublicMemory.Listener.Listening += OnListenerStatus;
                PublicMemory.Listener.Connected += OnConnected;
                PublicMemory.Listener.Disconnected += OnDisconnected;
                PublicMemory.Listener.Read += OnRead;

                PublicMemory.Listener.Start(inputAddress[0], int.Parse(inputAddress[1]));
            }
        }

        private void HandleParseError(IEnumerable<Error> errorList)
        {
            foreach (Error err in errorList)
            {
                Console.WriteLine(err);
            }
        }
        private void OnListenerStatus(bool listening,string ip, int port)
        {
            if (listening == true)
                listenerStatusLabel.Text = $"Listener: On ({ip}:{port})";
            else
                listenerStatusLabel.Text = "Listener: Off";
        }
        private void OnConnected(SocketHandle socketHandle)
        {
            PublicMemory.connectedHandles.Add(socketHandle);
            //Console.WriteLine($"{secureHandle.EndPoint} has connected.");
            //RuntimeMemory.connectedHandles.Add(secureHandle);

        }

        private void OnDisconnected(SocketHandle socketHandle)
        {
            PublicMemory.connectedHandles.Remove(socketHandle);
            //Console.WriteLine($"{secureHandle.EndPoint} has disconnected.");
        }

        private void OnRead(SocketHandle socketHandle, ProtobufMessage pm)
        {
            Resolver.Execute(socketHandle, pm);
        }

        private void StartupForm_Load(object sender, EventArgs e)
        {

        }

        private void StartupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PublicMemory.Listener.Stop();
        }
    }
}
