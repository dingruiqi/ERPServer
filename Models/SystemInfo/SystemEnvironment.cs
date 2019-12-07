using System.Collections.Generic;

namespace ERPServer.Models.SystemInfo
{
    public class SystemEnvironment
    {
        public SystemEnvironment()
        {
            MACAddress = new List<string>();
            BoardID = "UnKnown Board";
        }

        public List<string> MACAddress { get; set; }

        public string BoardID { get; set; }
    }
}