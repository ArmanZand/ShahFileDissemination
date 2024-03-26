using Networking.Messages;
using ShahFileDissemination.Crypto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShahFileDissemination
{
    internal class PublicMemory
    {
        public static List<SocketHandle> connectedHandles = new List<SocketHandle>();
        public static SocketListener Listener = new SocketListener();
        public static int NodeId = 0;
        public static int MaxSecretSize = 0;

        //public static Dictionary<int, List<UnivariatePoly>> ReceivedPolynomials = new Dictionary<int, List<UnivariatePoly>>();
        public static Dictionary<int, PolynomialSequence> PolysBySecretId = new Dictionary<int, PolynomialSequence>();
        //public static Dictionary<(int,int), List<Crypto.Scalar>> ReceivedScalars = new Dictionary<(int,int), List<Crypto.Scalar>>();
        public static Dictionary<int, ScalarSequence> ScalarsBySecretId = new Dictionary<int, ScalarSequence>();
        public static Dictionary<int, ShareSequence> SharesBySecretId = new Dictionary<int, ShareSequence>();
        public static SDParameters SDParameters { get; set; }
    }
    public class DefaultParameters
    {
        public static string ListenerIP = "192.168.1.30";
        public static int ListenerPort = 4444;
        public static string RemoteIP = "192.168.1.30";
        public static int RemotePort = 4444;
        public static bool KeepReconnecting = false;
        public static int RetryPause = 1000;
        public static int dPropagation = 2;
        public static int kThreshold = 2;
        //Read Only
        public static readonly BigInteger Prime = BigInteger.Parse("0FFFFFFFFFFFFFFFFC90FDAA22168C234C4C6628B80DC1CD129024E088A67CC74020BBEA63B139B22514A08798E3404DDEF9519B3CD3A431B302B0A6DF25F14374FE1356D6D51C245E485B576625E7EC6F44C42E9A637ED6B0BFF5CB6F406B7EDEE386BFB5A899FA5AE9F24117C4B1FE649286651ECE45B3DC2007CB8A163BF0598DA48361C55D39A69163FA8FD24CF5F83655D23DCA3AD961C62F356208552BB9ED529077096966D670C354E4ABC9804F1746C08CA18217C32905E462E36CE3BE39E772C180E86039B2783A2EC07A28FB5C55DF06F4C52C9DE2BCBF6955817183995497CEA956AE515D2261898FA051015728E5A8AAAC42DAD33170D04507A33A85521ABDF1CBA64ECFB850458DBEF0A8AEA71575D060C7DB3970F85A6E1E4C7ABF5AE8CDB0933D71E8C94E04A25619DCEE3D2261AD2EE6BF12FFA06D98A0864D87602733EC86A64521F2B18177B200CBBE117577A615D6C770988C0BAD946E208E24FA074E5AB3143DB5BFCE0FD108E4B82D120A92108011A723C12A787E6D788719A10BDBA5B2699C327186AF4E23C1A946834B6150BDA2583E9CA2AD44CE8DBBBC2DB04DE8EF92E8EFC141FBECAA6287C59474E6BC05D99B2964FA090C3A2233BA186515BE7ED1F612970CEE2D7AFB81BDD762170481CD0069127D5B05AA993B4EA988D8FDDC186FFB7DC90A6C08F4DF435C934063199FFFFFFFFFFFFFFFF", NumberStyles.HexNumber);
        //public static readonly BigInteger Prime = 509;
    }
    public class PolynomialSequence
    {
        public int NodeFromId { get; set; }
        public Dictionary<int, UnivariatePoly> PolyByIndex = new Dictionary<int, UnivariatePoly>();

    }
    public class ScalarsFromIndex
    {
        public Dictionary<int, Crypto.Scalar> ScalarsByNodeId = new Dictionary<int, Crypto.Scalar>();
    }
    public class ScalarSequence
    {
        public Dictionary<int, ScalarsFromIndex> ItemByIndex = new Dictionary<int, ScalarsFromIndex>();
    }
    public class SharesFromIndex
    {
        public Dictionary<int, Crypto.Scalar> SharesByNodeId = new Dictionary<int, Crypto.Scalar>();
    }
    public class ShareSequence
    {
        public Dictionary<int, SharesFromIndex> ItemByIndex = new Dictionary<int, SharesFromIndex>();
    }
}
