using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommandLine;
using Commands;
using Networking.Messages;
using ShahFileDissemination.Crypto;

namespace ShahFileDissemination
{
    public partial class StartupForm : Form
    {
        private string[] m_cmdargs = null;
        public StartupForm(string[] args)
        {
            InitializeComponent();
            m_cmdargs = args;
            Resolver.Form = this;
            
        }
        private Thread WorkThread;
        private void SubscribeListener()
        {
            PublicMemory.Listener.Listening += OnListenerStatus;
            PublicMemory.Listener.Connected += OnConnected;
            PublicMemory.Listener.Disconnected += OnDisconnected;
            PublicMemory.Listener.Receive += OnReceive;
            PublicMemory.Listener.Ready += OnReady;
        }
        private void UnsubscribeListener()
        {
            PublicMemory.Listener.Listening -= OnListenerStatus;
            PublicMemory.Listener.Connected -= OnConnected;
            PublicMemory.Listener.Disconnected -= OnDisconnected;
            PublicMemory.Listener.Receive -= OnReceive;
            PublicMemory.Listener.Ready -= OnReady;
        }
        public void SubscribeHandle(SocketHandle socketHandle)
        {
            socketHandle.Connected += OnConnected;
            socketHandle.Disconnected += OnDisconnected;
            socketHandle.Receive += OnReceive;
            socketHandle.Ready += OnReady;
        }
        public void UnsubscribeHandle(SocketHandle socketHandle)
        {
            socketHandle.Connected -= OnConnected;
            socketHandle.Disconnected -= OnDisconnected;
            socketHandle.Receive -= OnReceive;
            socketHandle.Ready -= OnReady;
        }
        #region CommandLine Parsing
        private void RunOptions(Options parseResults)
        {
            if (parseResults.cl_ip_port != null)
            {
                string[] inputAddress = parseResults.cl_ip_port.Split(':');


                SubscribeListener();
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
        #endregion
        #region Event Methods
        private void OnListenerStatus(bool listening, string ip, int port)
        {
            try
            {
                Invoke(new MethodInvoker(() =>
                {
                    ListenerCheckBox.Checked = listening;
                    ListenerIPTextBox.Enabled = !listening;
                    ListenerPortTextBox.Enabled = !listening;
                    if (listening == true)
                        ListenerStatusLabel.Text = $"Listener: On ({ip}:{port}) | Node Id: {PublicMemory.NodeId}";
                    else
                    {
                        ListenerStatusLabel.Text = "Listener: Off";
                        UnsubscribeListener();
                    }
                }));
            }
            catch (ObjectDisposedException) { }
        }
        
        private void OnConnected(SocketHandle socketHandle)
        {
            PublicMemory.connectedHandles.Add(socketHandle);
            SocketListViewItem slvi = new SocketListViewItem();
            slvi.Text = "#";
            slvi.SubItems.Add($"{socketHandle.EndPoint}");
            slvi.SubItems.Add($"{Role.Undefined}");
            slvi.SocketHandle = socketHandle;
            Invoke(new MethodInvoker(() =>
            {
                ConnectionsView.Items.Add(slvi);
            }
            ));
        }

        private void OnDisconnected(SocketHandle socketHandle)
        {
            PublicMemory.connectedHandles.Remove(socketHandle);
            try
            {
                Invoke(new MethodInvoker(() =>
                {
                    foreach (SocketListViewItem slvi in ConnectionsView.Items)
                    {
                        if (socketHandle == slvi.SocketHandle)
                        {
                            ConnectionsView.Items.Remove(slvi);
                            return;
                        }
                    }
                }));
            }
            catch (Exception) { }
            //Console.WriteLine($"{secureHandle.EndPoint} has disconnected.");
        }

        private void OnReceive(SocketHandle socketHandle, ProtobufMessage pm)
        {
            Resolver.Execute(socketHandle, pm);
        }
        private void OnReady(SocketHandle socketHandle, bool initiator)
        {
            if (initiator)
            {
                ProtobufMessage pm = new ProtobufMessage
                {
                    NodeInfo = new NodeInfo
                    {
                        Id = PublicMemory.NodeId
                    }
                };
                socketHandle.Send(pm);
            }
        }
        #endregion
        #region Form Events
        #region OnChange
        private void IDTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(((TextBox)sender).Text, out PublicMemory.NodeId);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
        private void dPropagationTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(((TextBox)sender).Text, out DefaultParameters.dPropagation);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        private void kThresholdTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(((TextBox)sender).Text, out DefaultParameters.kThreshold);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
        private void ListenerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ListenerCheckBox.Checked)
                {
                    if (!PublicMemory.Listener.IsListening)
                    {
                        PublicMemory.Listener = new SocketListener();
                        SubscribeListener();
                        PublicMemory.Listener.Start(ListenerIPTextBox.Text, int.Parse(ListenerPortTextBox.Text));
                    }
                }
                else
                {
                    PublicMemory.Listener.Stop();

                }
            }
            catch(Exception)
            {

            }
        }
        #endregion
        #region Buttons

        private void DisseminateBtn_Click(object sender, EventArgs e)
        {
            WorkThread = new Thread(() => {
                workThreadLabel.Text = "Sending Univariate Polynomials to Neighbours...";
                List<BigInteger> secretParts = new List<BigInteger>();

                ShahDissemination shah = new ShahDissemination(PublicMemory.SDParameters);
                if (SecretTextBox.Text.Length != 0)
                {
                    secretParts.AddRange(SecretTextBox.Text.SplitToBigIntegers(PublicMemory.PrimeByteSize));
                    string rev = secretParts.ToArray().GetString();
                }
                else
                {
                    secretParts = new List<BigInteger> { 0 };
                }
                Dictionary<int, List<Crypto.Scalar>> secretShares = new Dictionary<int, List<Crypto.Scalar>>();
                
                this.Invoke(new MethodInvoker(() =>
                {
                    for (int i = 0; i < secretParts.Count; i++)
                    {
                        secretShares[i] = new List<Crypto.Scalar>();
                        shah.GenerateMatrix(secretParts[i]);
                        foreach (SocketListViewItem item in ConnectionsView.Items)
                        {
                            SocketHandle handle = item.SocketHandle;
                            var poly = shah.ComputeUniPoly(handle.Id);

                            secretShares[i].Add(poly.Eval(0));

                            ProtobufMessage pm = poly.ToPolyMessage(i);
                            if (i == secretParts.Count - 1)
                            {
                                pm = new ProtobufMessage
                                {
                                    StreamEnd = new StreamEnd
                                    {
                                        UnivariatePolynomial = pm.UnivariatePolynomial
                                    }
                                };
                            }
                            handle.Send(pm);

                        }
                    }
                    DisseminateBtn.Enabled = true;
                    workThreadLabel.Text = "Done sending univariate polynomials.";

                }));
                List<BigInteger> resultBigInt = new List<BigInteger>();
                foreach(var shareListIndex in secretShares)
                {
                    UnivariatePoly poly = new UnivariatePoly(3, shah.SecretId);
                    foreach(var share in shareListIndex.Value)
                    {
                        poly.AddScalar(share);
                    }
                    poly.ReconstructPoly();
                    resultBigInt.Add(poly.Eval(0).Value);
                }
                string res = resultBigInt.ToArray().GetString();

            });
            (sender as Button).Enabled = false;
            WorkThread.Start();
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            SocketHandle socketHandle = new SocketHandle();
            SubscribeHandle(socketHandle);
            socketHandle.Connect(RemoteIPTextBox.Text, int.Parse(RemotePortTextBox.Text));
        }
        private void sendScalarBtn_Click(object sender, EventArgs e)
        {
            if (ReceivedPolyListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("No items selected.");
                return;
            }
            WorkThread = new Thread(() => {
                this.Invoke(new MethodInvoker(() => {
                    string ogText = workThreadLabel.Text;
                    workThreadLabel.Text = "Sending Scalars...";
                    int secretId = int.Parse(ReceivedPolyListView.SelectedItems[0].Text);
                    for (int i = 0; i < PublicMemory.connectedHandles.Count; i++)
                    {
                        if (PublicMemory.connectedHandles[i].Role == Role.Undefined)
                        {
                            SocketHandle targetHandle = PublicMemory.connectedHandles[i];
                            Dictionary<int, UnivariatePoly> polynomialsByIndex = PublicMemory.PolysBySecretId[secretId].PolyByIndex;
                            foreach(var kvp in polynomialsByIndex)
                            {
                                Crypto.Scalar scalar = kvp.Value.Eval(targetHandle.Id);
                                ProtobufMessage pm = scalar.ToScalarMessage(kvp.Key);
                                if(kvp.Key == polynomialsByIndex.Count - 1)
                                {
                                    pm = new ProtobufMessage { StreamEnd = new StreamEnd { Scalar = pm.Scalar } };
                                }
                                targetHandle.Send(pm);
                            }
                        }
                    }
                    workThreadLabel.Text = "Done sending scalars.";
                    sendScalarBtn.Enabled = true;
                }));
            });

            WorkThread.Start();
        }

        private void viewPolynomialBtn_Click(object sender, EventArgs e)
        {
            if (ReceivedPolyListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("No items selected.");
                return;
            }
            int secretId = int.Parse(ReceivedPolyListView.SelectedItems[0].Text);
            ViewPolynomialForm form = new ViewPolynomialForm(PublicMemory.PolysBySecretId[secretId]);
            form.Show();
        }
        private void evaluateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ReceivedPolyListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("No items selected.");
                return;
            }
            int secretId = int.Parse(ReceivedPolyListView.SelectedItems[0].Text);
            EvaluatePolynomialForm form = new EvaluatePolynomialForm(PublicMemory.PolysBySecretId[secretId]);
            form.Show();

        }
        private void viewScalarBtn_Click(object sender, EventArgs e)
        {
            if (ReceivedScalarsListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("No items selected.");
                return;
            }
            int secretId = int.Parse(ReceivedScalarsListView.SelectedItems[0].Text);
            ///ViewScalarForm form = new ViewScalarForm(((ScalarListViewItem)ReceivedScalarsListView.SelectedItems[0]).Scalars);
            ViewScalarForm form = new ViewScalarForm(PublicMemory.ScalarsBySecretId[secretId].ItemByIndex);
            form.Show();
        }


        private void reconstructPolynomialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ReceivedScalarsListView.SelectedItems.Count == 0) {
                MessageBox.Show("No items selected.");
                return; }
            workThreadLabel.Text = "Reconstructing Polynomial...";
            WorkThread = new Thread(() =>
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    string ogText = workThreadLabel.Text;
                    
                    if (ReceivedScalarsListView.SelectedItems.Count == 0) return;
                    
                    ListViewItem slvi = ReceivedScalarsListView.SelectedItems[0];
                    int secretId = int.Parse(slvi.Text);
                    var scalarsByIndex = PublicMemory.ScalarsBySecretId[secretId].ItemByIndex;
                    int firstIndexForNode = scalarsByIndex.Keys.ToArray()[0];
                    if (slvi.SubItems[3].Text == "True" && scalarsByIndex[firstIndexForNode].ScalarsByNodeId.Count >= DefaultParameters.dPropagation)
                    {
                        List<UnivariatePoly> polynomials = new List<UnivariatePoly>();
                        PublicMemory.PolysBySecretId[secretId] = new PolynomialSequence
                        {
                            NodeFromId = PublicMemory.NodeId,
                        };
                        foreach (var itemByIndex in scalarsByIndex)
                        {
                            UnivariatePoly poly = new UnivariatePoly(PublicMemory.NodeId, secretId);
                            
                            foreach (var scalarbyNodeId in itemByIndex.Value.ScalarsByNodeId)
                            {
                                poly.AddScalar(scalarbyNodeId.Value);
                            }
                            poly.ReconstructPoly();
                            polynomials.Add(poly);
                            PublicMemory.PolysBySecretId[secretId].PolyByIndex[itemByIndex.Key] = poly;
                            AddShare(secretId, itemByIndex.Key, poly);
                            
                        }
                        
                        ListViewItem plvi = new ListViewItem();
                        plvi.Text = secretId.ToString();
                        plvi.SubItems.Add(PublicMemory.NodeId.ToString());
                        plvi.SubItems.Add(polynomials.Count.ToString());
                        plvi.SubItems.Add("True");
                        ReceivedPolyListView.Items.Add(plvi);

                        ListViewItem sharelvi = new ListViewItem();
                        sharelvi.Text = secretId.ToString();
                        sharelvi.SubItems.Add("1");
                        sharelvi.SubItems.Add("False");
                        sharelvi.SubItems.Add("True");
                        
                        SharesListView.Items.Add(sharelvi);
                        workThreadLabel.Text = $"Reconstruction Complete for Secret Id: {secretId.ToString()}";
                    }
                    else
                    {
                        workThreadLabel.Text = ogText;
                        MessageBox.Show("Not enough scalars have been received for polynomial reconstruction", "Scalar Reconstruction Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }));
            });
            WorkThread.Start();
        }
        private void AddShare(int secretId, int index, UnivariatePoly poly)
        {
            if (!PublicMemory.SharesBySecretId.ContainsKey(secretId))
                PublicMemory.SharesBySecretId[secretId] = new ShareSequence();
            if (!PublicMemory.SharesBySecretId[secretId].ItemByIndex.ContainsKey(index))
                PublicMemory.SharesBySecretId[secretId].ItemByIndex[index] = new SharesFromIndex();
            PublicMemory.SharesBySecretId[secretId].ItemByIndex[index].SharesByNodeId[PublicMemory.NodeId] = poly.Eval(0);

            
        } 
        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConnectionsView.SelectedItems.Count == 0) return;
            foreach (SocketListViewItem item in ConnectionsView.SelectedItems)
            {
                item.SocketHandle.Disconnect();
            }
        }

        private void requestShareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConnectionsView.SelectedItems.Count == 0) return;
            List<int> validSecretIds = new List<int>(PublicMemory.PolysBySecretId.Keys.ToArray());
            if (validSecretIds.Count == 0)
            {
                MessageBox.Show("Cannot request shares without a reconstructed polynomial.", "Request Polynomial Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            RequestShareSecretIdForm form = new RequestShareSecretIdForm(validSecretIds);
            form.ShowDialog();
            int selectedSecretId = form.SelectedSecretId;
            ProtobufMessage pm = new ProtobufMessage
            {
                RequestShare = new RequestShare
                {
                    SecretId = selectedSecretId
                }
            };
            foreach (SocketListViewItem item in ConnectionsView.SelectedItems)
            {
                item.SocketHandle.Send(pm);
            }
        }

        #endregion
        private void StartupForm_Load(object sender, EventArgs e)
        {
            Parser.Default.ParseArguments<Options>(m_cmdargs).WithParsed(RunOptions).WithNotParsed(HandleParseError);

            Invoke(new MethodInvoker(() =>
            {
                ListenerIPTextBox.Text = PublicMemory.Listener.IP;
                ListenerPortTextBox.Text = PublicMemory.Listener.Port.ToString();
                RemoteIPTextBox.Text = DefaultParameters.RemoteIP;
                RemotePortTextBox.Text = DefaultParameters.RemotePort.ToString();
                IDTextBox.Text = ((int)SecurityUtils.NextBigInteger(1, 99)).ToString();
                dPropagationTextBox.Text = DefaultParameters.dPropagation.ToString();
                kThresholdTextBox.Text = DefaultParameters.kThreshold.ToString();
                PrimeSizeLabel.Text = (PublicMemory.PrimeByteSize).ToString();
            }));

        }

        private void StartupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PublicMemory.Listener.Stop();
            DefaultParameters.KeepReconnecting = false;
            for (int i = PublicMemory.connectedHandles.Count; i-- > 0;)
            {
                PublicMemory.connectedHandles[i].Disconnect();
                UnsubscribeHandle(PublicMemory.connectedHandles[i]);
            }
        }

        #endregion

        private void viewShareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(SharesListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("No items selected.");
                return;
            }
            int secretId = int.Parse(SharesListView.SelectedItems[0].Text);
            ViewShareForm form = new ViewShareForm(PublicMemory.SharesBySecretId[secretId].ItemByIndex);
            form.Show();
        }

        private void recoverSecretToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(SharesListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("No items selected.");
                return;
            }
            int secretId = int.Parse(SharesListView.SelectedItems[0].Text);
            BigInteger[] resIntegers = new BigInteger[PublicMemory.SharesBySecretId[secretId].ItemByIndex.Count];
            foreach (var shareIndex in PublicMemory.SharesBySecretId[secretId].ItemByIndex)
            {

                UnivariatePoly poly = new UnivariatePoly(PublicMemory.NodeId, secretId);
                foreach (var shareByNodeId in shareIndex.Value.SharesByNodeId)
                {
                    poly.AddScalar(shareByNodeId.Value);
                }
                poly.ReconstructPoly();
                resIntegers[shareIndex.Key] = poly.Eval(0).Value;
                
            }
            SecretTextBox.Text = resIntegers.GetString();
        }
    }
}
