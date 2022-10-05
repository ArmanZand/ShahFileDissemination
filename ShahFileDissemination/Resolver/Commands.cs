using Networking.Messages;
using ShahFileDissemination;
using ShahFileDissemination.Crypto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Commands
{
    public class Resolver
    {
        public static StartupForm Form { get; set; }
        public static void Execute(SocketHandle socketHandle, ProtobufMessage pm)
        {
            try
            {
                commands[pm.CommandCase]?.Invoke(socketHandle, pm);
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static volatile Dictionary<ProtobufMessage.CommandOneofCase, Action<SocketHandle, ProtobufMessage>> commands
        = new Dictionary<ProtobufMessage.CommandOneofCase, Action<SocketHandle, ProtobufMessage>>
        {
            [ProtobufMessage.CommandOneofCase.None] = Commands.NullCommand,
            [ProtobufMessage.CommandOneofCase.NodeInfo] = Commands.NodeInfo,
            [ProtobufMessage.CommandOneofCase.NodeInfoReply] = Commands.NodeInfoReply,
            [ProtobufMessage.CommandOneofCase.StreamEnd] = Commands.StreamEnd,
            [ProtobufMessage.CommandOneofCase.UnivariatePolynomial] = Commands.UnivariatePolynomial,
            [ProtobufMessage.CommandOneofCase.Scalar] = Commands.Scalar,
            [ProtobufMessage.CommandOneofCase.RequestShare] = Commands.RequestShare,
            [ProtobufMessage.CommandOneofCase.SecretShare] = Commands.SecretShare,
            
        };
        private class Commands
        {
            internal static void NullCommand(SocketHandle sh, ProtobufMessage pm)
            {
                throw new NotImplementedException();
            }
            internal static void NodeInfo(SocketHandle sh, ProtobufMessage pm)
            {
                sh.Id = pm.NodeInfo.Id;
                Form.Invoke(new MethodInvoker(() =>
                {
                    Form.ConnectionsView.SearchHandle(sh).Text = pm.NodeInfo.Id.ToString();
                }));
                ProtobufMessage rm = new ProtobufMessage
                {
                    NodeInfoReply = new NodeInfoReply
                    {
                        Id = PublicMemory.NodeId
                    }
                };
                sh.Send(rm);
                
            }
            internal static void NodeInfoReply(SocketHandle sh, ProtobufMessage pm)
            {
                sh.Id = pm.NodeInfoReply.Id;
                Form.Invoke(new MethodInvoker(() =>
                {
                    Form.ConnectionsView.SearchHandle(sh).Text = pm.NodeInfoReply.Id.ToString();
                }));
            }
            internal static void StreamEnd(SocketHandle sh, ProtobufMessage pm)
            {
                switch (pm.StreamEnd.MessageTypeCase)
                {
                    case Networking.Messages.StreamEnd.MessageTypeOneofCase.UnivariatePolynomial:
                        pm = new ProtobufMessage { UnivariatePolynomial = pm.StreamEnd.UnivariatePolynomial };
                        UnivariatePolynomial(sh, pm, true);
                        break;
                    case Networking.Messages.StreamEnd.MessageTypeOneofCase.Scalar:
                        pm = new ProtobufMessage { Scalar = pm.StreamEnd.Scalar };
                        Scalar(sh, pm, true);
                        break;
                    case Networking.Messages.StreamEnd.MessageTypeOneofCase.SecretShare:
                        pm = new ProtobufMessage { SecretShare = pm.StreamEnd.SecretShare };
                        SecretShare(sh, pm, true);
                        break;
                    default:
                        break;
                }
            }
            internal static void UnivariatePolynomial(SocketHandle sh, ProtobufMessage pm)
            {
                UnivariatePolynomial(sh, pm, false);
            }
            internal static void UnivariatePolynomial(SocketHandle sh, ProtobufMessage pm, bool lastMessage)
            {
                int nodeId = sh.Id;
                int secretId = pm.UnivariatePolynomial.SecretId;
                if (!PublicMemory.PolysBySecretId.ContainsKey(secretId))
                {
                    PublicMemory.PolysBySecretId[secretId] = new PolynomialSequence { NodeFromId = nodeId};
                }
                UnivariatePoly poly = new UnivariatePoly(DefaultParameters.dPropagation, pm.UnivariatePolynomial);

                PublicMemory.PolysBySecretId[secretId].PolyByIndex[pm.UnivariatePolynomial.Index] = poly;

                if (!PublicMemory.SharesBySecretId.ContainsKey(secretId))
                    PublicMemory.SharesBySecretId[secretId] = new ShareSequence();
                if (!PublicMemory.SharesBySecretId[secretId].ItemByIndex.ContainsKey(pm.UnivariatePolynomial.Index))
                    PublicMemory.SharesBySecretId[secretId].ItemByIndex[pm.UnivariatePolynomial.Index] = new SharesFromIndex();
                PublicMemory.SharesBySecretId[secretId].ItemByIndex[pm.UnivariatePolynomial.Index].SharesByNodeId[PublicMemory.NodeId] = poly.Eval(0);

                Form.Invoke(new MethodInvoker(() => {
                    lock (Form.ReceivedPolyListView)
                    {
                        bool newItem = true;
                        foreach(ListViewItem lvi in Form.ReceivedPolyListView.Items)
                        {
                            if(lvi.Text == secretId.ToString())
                            {
                                lvi.SubItems[2].Text = PublicMemory.PolysBySecretId[secretId].PolyByIndex.Count.ToString();
                                if (lastMessage)
                                    lvi.SubItems[3].Text = "True";
                                newItem = false;
                                break;
                            }
                        }
                        if (newItem)
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.Text = secretId.ToString();
                            lvi.SubItems.Add(nodeId.ToString());
                            lvi.SubItems.Add("1");
                            lvi.SubItems.Add((lastMessage) ? "True" : "False");
                            Form.ReceivedPolyListView.Items.Add(lvi);

                            ListViewItem sharelvi = new ListViewItem();
                            sharelvi.Text = secretId.ToString();
                            sharelvi.SubItems.Add("1");
                            sharelvi.SubItems.Add("False");
                            sharelvi.SubItems.Add("True");
                            Form.SharesListView.Items.Add(sharelvi);
                        }
                    }
                
                if (lastMessage)
                {
                    Form.ConnectionsView.SearchHandle(sh).SubItems[2].Text = Role.Dealer.ToString();
                    sh.Role = Role.Dealer;
                }
                }));
            }
            internal static void Scalar(SocketHandle sh, ProtobufMessage pm)
            {
                Scalar(sh, pm, false);
            }
            internal static void Scalar(SocketHandle sh, ProtobufMessage pm, bool lastMessage)
            {
                int nodeId = sh.Id;
                int secretId = pm.Scalar.SecretId;
                if (!PublicMemory.ScalarsBySecretId.ContainsKey(secretId))
                {
                    PublicMemory.ScalarsBySecretId[secretId] = new ScalarSequence();
                }
                if (!PublicMemory.ScalarsBySecretId[secretId].ItemByIndex.ContainsKey(pm.Scalar.Index))
                {
                    PublicMemory.ScalarsBySecretId[secretId].ItemByIndex[pm.Scalar.Index] = new ScalarsFromIndex();
                }
                ShahFileDissemination.Crypto.Scalar scalar = new ShahFileDissemination.Crypto.Scalar(pm.Scalar);
                PublicMemory.ScalarsBySecretId[secretId].ItemByIndex[pm.Scalar.Index].ScalarsByNodeId[nodeId] = scalar;
                Form.Invoke(new MethodInvoker(() => {
                    lock (Form.ReceivedScalarsListView)
                    {
                        bool newItem = true;
                        foreach(ListViewItem lvi in Form.ReceivedScalarsListView.Items)
                        {
                            if(lvi.Text == secretId.ToString())
                            {
                                lvi.SubItems[1].Text = PublicMemory.ScalarsBySecretId[secretId].ItemByIndex[pm.Scalar.Index].ScalarsByNodeId.Count.ToString();
                                if (lastMessage && PublicMemory.ScalarsBySecretId[secretId].ItemByIndex[pm.Scalar.Index].ScalarsByNodeId.Count >= DefaultParameters.dPropagation)
                                    lvi.SubItems[2].Text = "True";
                                if (lastMessage)
                                    lvi.SubItems[3].Text = "True";
                                newItem = false;
                                break;
                            }
                        }
                        if (newItem)
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.Text = secretId.ToString();
                            lvi.SubItems.Add("1");
                            lvi.SubItems.Add((lastMessage && PublicMemory.ScalarsBySecretId[secretId].ItemByIndex[pm.Scalar.Index].ScalarsByNodeId.Count >= DefaultParameters.dPropagation) ? "True" : "False");
                            lvi.SubItems.Add((lastMessage) ? "True" : "False");
                            Form.ReceivedScalarsListView.Items.Add(lvi);
                        }
                    }
                
                if (lastMessage)
                {
                    Form.ConnectionsView.SearchHandle(sh).SubItems[2].Text = Role.Sender.ToString();
                    sh.Role = Role.Sender;
                }
                }));
            }
            internal static void RequestShare(SocketHandle sh, ProtobufMessage pm)
            {
                int SecretId = pm.RequestShare.SecretId;
                if (!PublicMemory.PolysBySecretId.ContainsKey(SecretId)) return;
                int[] indexes = PublicMemory.PolysBySecretId[SecretId].PolyByIndex.Keys.ToArray();
                for(int i = 0; i < indexes.Length; i ++)
                {
                    UnivariatePoly poly = PublicMemory.PolysBySecretId[SecretId].PolyByIndex[indexes[i]];
                    ProtobufMessage rm = poly.Eval(0).ToShareMessage(indexes[i]);
                    if(i == indexes.Length - 1)
                    {
                        rm = new ProtobufMessage
                        {
                            StreamEnd = new StreamEnd
                            {
                                SecretShare = rm.SecretShare
                            }
                        };
                    }
                    sh.Send(rm);
                }
            }
            internal static void SecretShare(SocketHandle sh, ProtobufMessage pm)
            {
                SecretShare(sh, pm, false);
            }
            internal static void SecretShare(SocketHandle sh, ProtobufMessage pm, bool lastMessage)
            {
                int nodeId = sh.Id;
                int SecretId = pm.SecretShare.SecretId;
                if (!PublicMemory.SharesBySecretId.ContainsKey(SecretId))
                {
                    PublicMemory.SharesBySecretId[SecretId] = new ShareSequence();
                }
                if (!PublicMemory.SharesBySecretId[SecretId].ItemByIndex.ContainsKey(pm.SecretShare.Index))
                {
                    PublicMemory.SharesBySecretId[SecretId].ItemByIndex[pm.SecretShare.Index] = new SharesFromIndex();
                }
                ShahFileDissemination.Crypto.Scalar share = new ShahFileDissemination.Crypto.Scalar(pm.SecretShare);
                PublicMemory.SharesBySecretId[SecretId].ItemByIndex[pm.SecretShare.Index].SharesByNodeId[nodeId] = share;
                Form.Invoke(new MethodInvoker(() => {
                    lock (Form.SharesListView)
                    {
                        bool newItem = true;
                        int numShares = PublicMemory.SharesBySecretId[SecretId].ItemByIndex[pm.SecretShare.Index].SharesByNodeId.Count;
                        foreach (ListViewItem lvi in Form.SharesListView.Items)
                        {
                            if(lvi.Text == SecretId.ToString())
                            {
                                lvi.SubItems[1].Text = numShares.ToString();
                                if (numShares >= DefaultParameters.dPropagation)
                                    lvi.SubItems[2].Text = "True";
                                if(lastMessage)
                                    lvi.SubItems[3].Text = "True";
                                newItem = false;
                                break;
                            }
                        }
                        if (newItem)
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.Text = SecretId.ToString();
                            lvi.SubItems.Add("1");
                            lvi.SubItems.Add((numShares >= DefaultParameters.dPropagation) ? "True" : "False");
                            lvi.SubItems.Add((lastMessage) ? "True" : "False");
                            Form.SharesListView.Items.Add(lvi);
                        }
                    }
                }));
            }
        }
    }
}
