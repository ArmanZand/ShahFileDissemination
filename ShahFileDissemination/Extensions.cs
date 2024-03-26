using Networking.Messages;
using ShahFileDissemination.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace ShahFileDissemination
{
    public static class StaticExtensions
    {
        public static string ToHex(this string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            return BitConverter.ToString(bytes).Replace("-", "");
        }
        public static byte[] ToBytes(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }
        public static BigInteger[] SplitToBigIntegers(this string str, int splitSize)
        {
            if (splitSize <= 0) throw new ArgumentException("Split size must be greater than 1");
            if (str.Length == 0) return new BigInteger[] { 0 };
            List<BigInteger> bigInts = new List<BigInteger>();
            for (int i = 0; i < str.Length; i += splitSize)
            {

                string split = str.Substring(i, (i + splitSize > str.Length) ? str.Length - i : splitSize);

                bigInts.Add(new BigInteger(split.ToBytes().Concat(new byte[] { 0 }).ToArray()));
            }
            return bigInts.ToArray();
        }
        public static string GetString(this BigInteger[] bigInts)
        {
            StringBuilder sb = new StringBuilder();
            foreach (BigInteger bI in bigInts)
            {
                sb.Append(Encoding.UTF8.GetString(bI.ToByteArray()));
            }
            return sb.ToString();
        }
    }
        
    
   public class SocketListViewItem : ListViewItem
   {
        public SocketHandle SocketHandle { get; set; }
   }
    public class SocketListView : ListView
    {
        public SocketListViewItem SearchHandle(SocketHandle handle)
        {
            foreach(SocketListViewItem item in this.Items)
            {
                if(item.SocketHandle == handle)
                {
                    return item;
                }
            }
            return null;
        }
    }

}
