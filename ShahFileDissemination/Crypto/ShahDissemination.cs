using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShahFileDissemination.Crypto
{
    public class ShahDissemination
    {
        public List<List<BigInteger>> M { get; set; }
        SDParameters Params { get; set; }
        public ShahDissemination(SDParameters parameters)
        {
            Params = parameters;
        }
        public int MaxSecretByteSize
        {
            get { return Params.p.ToByteArray().Length - 1; }
        }
        public void ComputePoly()
        {

        }
        public void GenerateMatrix(BigInteger[] secrets)
        {
            lock (M)
            {
                if (secrets.Length != Params.d - Params.k + 1) throw new ArgumentException("Number of secrets must be equal to d-k + 1.");
                int maxSecretByteSize = MaxSecretByteSize;
                for (int i = 0; i < secrets.Length; i++)
                {
                    if (!(secrets[i].ToByteArray().Length > maxSecretByteSize))
                        throw new ArgumentException("Secret is larger than prime");
                }
                M = new List<List<BigInteger>>(Params.d);
                for (int i = 0; i < Params.d; i++)
                {
                    M.Add(new List<BigInteger>());
                    for (int j = 0; j < Params.d; j++)
                    {
                        M[i].Add(new BigInteger(0));
                    }
                }
                List<(int, int)> skip = new List<(int, int)>();
                for (int i = 0; i < Params.d; i++)
                {
                    for (int j = 0; j < Params.d; j++)
                    {
                        if (!skip.Contains((j, i)) && (!((i >= Params.k) && (j >= Params.k))))
                        {
                            //BigInteger r = SecurityUtils.NextBigInteger(1, Params.p - 1);
                            BigInteger r = SecurityUtils.NextBigInteger(1, 9);
                            M[i][j] = r;
                            M[j][i] = r;
                            skip.Add((i, j));
                        }
                    }
                }
                M[0][0] = secrets[0];
                for (int i = 1; i < secrets.Length; i++)
                {
                    M[0][Params.k + i - 1] = secrets[i];
                    M[Params.k + i - 1][0] = secrets[i];
                }
            }
        }
    }
    public class ShahBivariatePoly {
    
        
    }

    public class SDParameters
    {
        public BigInteger p { get; set; }
        public BigInteger g { get; set; }
        public int d { get; set; }
        public int k { get; set; }
    }
}
