using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShahFileDissemination.Crypto
{
    public class SecurityUtils
    {
        public static string ComputeHash(byte[] data)
        {
            using (SHA384 sha = SHA384.Create())
            {
                return Convert.ToBase64String(sha.ComputeHash(data));
            }
        }
        public static string ComputeFileHash(string filePath)
        {
            if(!File.Exists(filePath))
                throw new ArgumentException($"{nameof(ComputeFileHash)}() -- Could not find file at {filePath}.");
            using (FileStream obj_fs = File.OpenRead(filePath))
            {
                using (SHA384 sha = SHA384.Create())
                {
                    return Convert.ToBase64String(sha.ComputeHash(obj_fs));
                }
            }

        }
        public static byte[] RandomBytes(int len_bytes)
        {
            using (var CRNG = RandomNumberGenerator.Create())
            {
                byte[] rbytes = new byte[len_bytes];
                CRNG.GetBytes(rbytes);
                return rbytes;
            }
        }
        public static BigInteger NextBigInteger(BigInteger min, BigInteger max)
        {
            //https://github.com/sdrapkin/SecurityDriven.Inferno/blob/master/CryptoRandom.cs
            if (min == max) return min;
            if (min > max) throw new ArgumentOutOfRangeException(nameof(min));

            BigInteger range = (BigInteger)(max - min);
            if (range == 0) return min;

            BigInteger mask = range;
            int numSize = range.ToByteArray().Length;
            int iter = (int)Math.Log(numSize*8, 2);
            for(int i = 0; i < (int)iter; i++)
            {
                int bitshift = (int)BigInteger.Pow(2, i);
                mask |= mask >> bitshift;
            }

            BigInteger result;
            do
            {
                byte[] randomBytes = RandomBytes(numSize);
                result = new BigInteger(randomBytes.Concat(new byte[] { 0}).ToArray()) & mask;
            } while (result > range);
            result += min;
            return result;
        }
        
    }
}
