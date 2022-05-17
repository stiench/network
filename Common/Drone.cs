using Common.Helpers;
using System;

namespace Common
{
    [SerializableAttribute]
    public class Drone
    {
        public string ComputerId { get; set; }
        public string HostName { get; set; }       
        public string UserName { get; set; }
        public string Ip { get; set; }
        public string OsVersion { get; set; }

        public Drone(string ip)
        {
            Ip = ip;
            ComputerId = Helpers.Common.GetComputerId();
            HostName = Network.GetHostName();
            UserName = Environment.UserName;
            OsVersion = Environment.OSVersion.VersionString;
        }

        override
        public string ToString()
        {
            return "Hostname : " + HostName + " - Username : " + UserName;
        }
    }
}
