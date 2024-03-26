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
        public static int ComputeMessageBlockSize(BigInteger Prime)
        {
            string hexPrime = Prime.ToString("X");
            int primeLen = hexPrime.Length-1;
            for(int i = primeLen-1; i --> 0;)
            {
                string testHex = new string('F', i);
                testHex = "0" + testHex;
                if(BigInteger.Parse(testHex, System.Globalization.NumberStyles.HexNumber) < Prime)
                {
                    return i;
                }
            }
            throw new Exception("Cannot find an appropriate message block size given the input value.");
            
        }
        public static (BigInteger LeftFactor, BigInteger RightFactor, BigInteger Gcd) Egcd(BigInteger left, BigInteger right)
        {
            //https://stackoverflow.com/questions/66645125/how-to-perform-multiplicative-inverse-in-c-sharp
            BigInteger leftFactor = 0;
            BigInteger rightFactor = 1;

            BigInteger u = 1;
            BigInteger v = 0;
            BigInteger gcd = 0;

            while (left != 0)
            {
                BigInteger q = right / left;
                BigInteger r = right % left;

                BigInteger m = leftFactor - u * q;
                BigInteger n = rightFactor - v * q;

                right = left;
                left = r;
                leftFactor = u;
                rightFactor = v;
                u = m;
                v = n;

                gcd = right;
            }

            return (LeftFactor: leftFactor,
                    RightFactor: rightFactor,
                    Gcd: gcd);
        }
        public static BigInteger ModInversion(BigInteger value, BigInteger modulo)
        {
            var egcd = Egcd(value, modulo);

            if (egcd.Gcd != 1)
                throw new ArgumentException("Invalid modulo", nameof(modulo));

            BigInteger result = egcd.LeftFactor;

            if (result < 0)
                result += modulo;

            return result % modulo;
        }
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
