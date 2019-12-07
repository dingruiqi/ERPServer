using System.Collections.Generic;

namespace ERPServer.Models.SystemInfo
{
    public class SystemEnvironment
    {
        public SystemEnvironment()
        {
            MACAddress = new List<string>();
            BoardID = new List<string>();
            CpuID = new List<string>();
            DriverNumber = new List<string>();
        }

        public List<string> MACAddress { get; set; }

        public List<string> BoardID { get; set; }

        public List<string> CpuID { get; set; }

        public List<string> DriverNumber { get; set; }
    }
}