using System.Net;
using System.Net.NetworkInformation;

namespace Common.Helpers
{
    public static class Network
    {
        public static string GetMacAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet && nic.OperationalStatus == OperationalStatus.Up)
                {
                    return nic.GetPhysicalAddress().ToString();
                }
            }
            return null;
        }

        public static string GetHostName()
        {
            return Dns.GetHostName();
        }
    }
}
