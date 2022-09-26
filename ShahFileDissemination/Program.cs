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
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            SDParameters parameters = new SDParameters
            {
                d = 4,
                k = 3,
                g = DefaultParameters.Generator,
                p = DefaultParameters.Prime
            };
            ShahDissemination sd = new ShahDissemination(parameters);
            sd.GeneratePoly(new BigInteger[] { 11, 11 });
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartupForm(args));
        }
    }
}
