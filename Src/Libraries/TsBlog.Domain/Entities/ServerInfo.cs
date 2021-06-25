using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.Domain.Entities
{
    public class ServerInfo
    {
        public string ServerName { get; set; }

        public string OperatingSystem { get; set; }

        public int ProcessorCount { get; set; }

        public string StartDate { get; set; }

        public string IpLocation { get; set; }

        public string LanIP { get; set; }

        public string PublicIP { get; set; }

        public string SystemFramework { get; set; }

        public string FrameworkVersion { get; set; }

        public string RamUse { get; set; }

        public string StartTime { get; set; }
    }
}
