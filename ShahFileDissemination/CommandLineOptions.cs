using CommandLine.Text;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahFileDissemination
{
    public class Options
    {
        [Option('l', "listen", Required = false, HelpText = "Start listener on IP:PORT.")]
        public string cl_ip_port { get; set; }
    }
}
