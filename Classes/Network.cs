using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
namespace Classes
{
    internal sealed class Network
    {
        internal static string Hostname { get { return Dns.GetHostName(); } }
        internal static string Username { get { return System.Environment.UserName; } }
        internal static bool InternetAccess()
        {
            if (!NetworkInterface.GetIsNetworkAvailable()) { return false; }
            IPStatus Status;
            try { Status = new Ping().Send("www.google.com", 3000).Status; }
            catch { Status = IPStatus.DestinationHostUnreachable; }
            try { Status = new Ping().Send("www.facebook.com", 3000).Status; }
            catch { Status = IPStatus.DestinationHostUnreachable; }
            try { Status = new Ping().Send("www.youtube.com", 3000).Status; }
            catch { Status = IPStatus.DestinationHostUnreachable; }
            if (Status != IPStatus.Success) { return false; } else { return true; }
        }

        internal static string GatewayIPAddress
        {
            get
            {
                NetworkInterface[] NetInterfaces;
                try { NetInterfaces = NetworkInterface.GetAllNetworkInterfaces(); }
                catch { return "0.0.0.0"; }
                foreach (NetworkInterface NetInterface in NetInterfaces)
                {
                    if (!NetInterface.IsReceiveOnly && NetInterface.OperationalStatus.Equals(OperationalStatus.Up))
                    { return NetInterface.GetIPProperties().GatewayAddresses[0].Address.ToString(); }
                }
                return "0.0.0.0";
            }
            
        }

        internal static string PhysicalAddress
        {
            get
            {
                if (!NetworkInterface.GetIsNetworkAvailable()) { return AppData.DEFAULT.MAC_ADDRESS; }
                NetworkInterface[] NetInterfaces;
                try { NetInterfaces = NetworkInterface.GetAllNetworkInterfaces(); }
                catch { return AppData.DEFAULT.MAC_ADDRESS; }
                foreach (NetworkInterface NetInterface in NetInterfaces)
                { if (!NetInterface.IsReceiveOnly && NetInterface.OperationalStatus.Equals(OperationalStatus.Up))
                    { return NetInterface.GetPhysicalAddress().ToString(); } }
                return AppData.DEFAULT.MAC_ADDRESS;
            }

        }

        internal static string IPv4
        {
            get
            {
                IPHostEntry IPHE;
                try { IPHE = Dns.GetHostEntry(Dns.GetHostName()); }
                catch { return AppData.DEFAULT.IPV4; }
                foreach (IPAddress IP in IPHE.AddressList)
                { if (IP.ToString().Split('.').Length.Equals(4)) { return IP.ToString(); } }
                return AppData.DEFAULT.IPV4;
            }
        }
        internal static string IPv6
        {
            get
            {
                IPHostEntry IPHE;
                try { IPHE = Dns.GetHostEntry(Dns.GetHostName()); }
                catch { return AppData.DEFAULT.IPV6; }
                foreach (IPAddress IP in IPHE.AddressList)
                { if (IP.ToString().Split(':').Length.Equals(8)) { return IP.ToString(); } }
                return AppData.DEFAULT.IPV6;
            }
        }

        internal static bool GetIPHostEntry(ref string Hostname)
        {
            IPHostEntry IPHE;
            try { IPHE = Dns.GetHostEntry(Hostname); }
            catch (System.Exception ex) { Hostname = ex.Message; return false; }
            foreach (IPAddress IPv4 in IPHE.AddressList)
            {
                if (IPv4.AddressFamily == AddressFamily.InterNetwork)
                { Hostname = IPv4.ToString(); return true; }
            }
            return false;
        }

        internal static string LocalIPAddress(AddressFamily addressfamily)
        {
            foreach (IPAddress IPvX in Dns.GetHostAddresses(Hostname))
            {
                if (IPvX.AddressFamily.Equals(addressfamily)) { return IPvX.ToString(); }
            }
            return AppData.DEFAULT.IPV4;
        }

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        internal static bool IsConnectedToInternet()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }
    }
}
