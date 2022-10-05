using CommandLine;
using ShahFileDissemination.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShahFileDissemination
{
    internal static class Program
    {
        static void ShahTest()
        {


            string input = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBCC";
            List<BigInteger> secretParts = new List<BigInteger>();
            ShahDissemination shah = new ShahDissemination(PublicMemory.SDParameters);
            secretParts.AddRange(input.SplitToBigIntegers(PublicMemory.PrimeByteSize));
            shah.GenerateMatrix(secretParts[0]);
            var p1i0 = shah.ComputeUniPoly(1);
            var p2i0 = shah.ComputeUniPoly(2);
            shah.GenerateMatrix(secretParts[1]);
            var p1i1 = shah.ComputeUniPoly(1);
            var p2i1 = shah.ComputeUniPoly(2);

            //Index 0 
            var p1t3i0 = p1i0.Eval(3);
            var p2t3i0 = p2i0.Eval(3);
            //Index 1
            var p1t3i1 = p1i1.Eval(3);
            var p2t3i1 = p2i1.Eval(3);

            var p3i0 = new UnivariatePoly(3, shah.SecretId);
            p3i0.AddScalar(p1t3i0);
            p3i0.AddScalar(p2t3i0);
            p3i0.ReconstructPoly();

            var p3i1 = new UnivariatePoly(3, shah.SecretId);
            p3i1.AddScalar(p1t3i1);
            p3i1.AddScalar(p2t3i1);
            p3i1.ReconstructPoly();

            var p3s0 = p3i0.Eval(0);
            var p3s1 = p3i1.Eval(0);

            var p2s0 = p2i0.Eval(0);
            var p2s1 = p2i1.Eval(0);

            var p0 = new UnivariatePoly(3, shah.SecretId);
            p0.AddScalar(p3s0);
            p0.AddScalar(p2s0);
            p0.ReconstructPoly();

            var p1 = new UnivariatePoly(3, shah.SecretId);
            p1.AddScalar(p3s1);
            p1.AddScalar(p2s1);
            p1.ReconstructPoly();

            BigInteger[] res = new BigInteger[] { p0.Eval(0).Value, p1.Eval(0).Value };
            string msg = res.GetString();

        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //PublicMemory.PrimeByteSize = DefaultParameters.Prime.ToByteArray().Length;
            PublicMemory.PrimeByteSize = 100;
            SDParameters parameters = new SDParameters();
            parameters.d = DefaultParameters.dPropagation;
            parameters.k = DefaultParameters.kThreshold;
            parameters.p = DefaultParameters.Prime;
            PublicMemory.SDParameters = parameters;
            //ShahTest();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartupForm(args));
        }
    }
}
