namespace Classes
{
    internal static class AppData
    {

        private static string password = "//4AADEAAAA1AAAAOAAAAA$$|//4AADIAAAAzAAAANQAAAA$$|/"
            + "/4AADEAAAA2AAAAOAAAAA$$|//4AADQAAAA3AAAA|//4AADEAAAAzAAAAMgAAAA$$|//4AADEAAAA2"
            + "AAAAOAAAAA$$|//4AADIAAAAwAAAAMwAAAA$$|//4AADEAAAA2AAAANgAAAA$$|//4AADEAAAA4AAA"
            + "A|//4AADEAAAA4AAAAMAAAAA$$|//4AADIAAAA0AAAAMQAAAA$$|//4AADEAAAA3AAAANAAAAA$$|/"
            + "/4AADEAAAAzAAAAMAAAAA$$|//4AADIAAAAyAAAANQAAAA$$|//4AADIAAAAxAAAAOAAAAA$$|//4A"
            + "ADcAAAAwAAAA|";
        private static string username = "//4AADYAAAAzAAAA|//4AADUAAAA5AAAA|//4AADMAAAA5AAAA|"
            + "//4AADEAAAA5AAAAMAAAAA$$|//4AADEAAAA5AAAA|//4AADIAAAAzAAAAOAAAAA$$|//4AADQAAAA"
            + "$|//4AADEAAAA2AAAAMgAAAA$$|//4AADEAAAA4AAAAOAAAAA$$|//4AADEAAAAxAAAAMAAAAA$$|/"
            + "/4AADEAAAAwAAAAMgAAAA$$|//4AADEAAAA1AAAANAAAAA$$|//4AADEAAAA5AAAANgAAAA$$|//4A"
            + "ADIAAAAwAAAAOQAAAA$$|//4AADEAAAAwAAAANAAAAA$$|//4AADIAAAAzAAAAMwAAAA$$|";
        private static string userguid = "//4AADkAAAAzAAAA|//4AADEAAAAyAAAANQAAAA$$|//4AADIAA"
            + "AAyAAAAOQAAAA$$|//4AADIAAAA1AAAAMQAAAA$$|//4AADEAAAA2AAAANwAAAA$$|//4AADIAAAAz"
            + "AAAANAAAAA$$|//4AADIAAAAzAAAAOAAAAA$$|//4AADEAAAAyAAAAMgAAAA$$|//4AADEAAAA2AAA"
            + "ANAAAAA$$|//4AADUAAAA$|//4AADUAAAA4AAAA|//4AADIAAAAxAAAAMwAAAA$$|//4AADEAAAA2A"
            + "AAANAAAAA$$|//4AADEAAAA4AAAAOQAAAA$$|//4AADQAAAAzAAAA|//4AADgAAAAyAAAA|//4AADE"
            + "AAAA3AAAAMwAAAA$$|//4AADIAAAAxAAAAOAAAAA$$|//4AADEAAAAzAAAANAAAAA$$|//4AADUAAA"
            + "A4AAAA|//4AADUAAAA4AAAA|//4AADYAAAAxAAAA|//4AADIAAAA3AAAA|//4AADcAAAAxAAAA|//4"
            + "AADIAAAAzAAAAOQAAAA$$|//4AADIAAAAzAAAAOAAAAA$$|//4AADEAAAA2AAAAMwAAAA$$|//4AAD"
            + "IAAAA0AAAAMwAAAA$$|//4AADEAAAA3AAAA|//4AADcAAAAxAAAA|//4AADkAAAAzAAAA|//4AADkA"
            + "AAAwAAAA|//4AADEAAAAyAAAAMwAAAA$$|//4AADIAAAAzAAAAMAAAAA$$|//4AADIAAAAxAAAAMwA"
            + "AAA$$|//4AADEAAAA3AAAA|//4AADEAAAA1AAAAMQAAAA$$|//4AADEAAAAxAAAAOQAAAA$$|//4AA"
            + "DEAAAAxAAAANgAAAA$$|//4AADgAAAA1AAAA|//4AADEAAAAzAAAAOQAAAA$$|//4AADUAAAA2AAAA"
            + "|//4AADgAAAA1AAAA|//4AADEAAAAyAAAANgAAAA$$|//4AADEAAAA1AAAANgAAAA$$|//4AADYAAA"
            + "A$|//4AADIAAAA0AAAAOQAAAA$$|//4AADEAAAA3AAAAOQAAAA$$|";

        internal struct SECURITY
        {
            internal static string UserGUID { get { return userguid; } set { userguid = value; } }
            internal static string UserName { get { return username; } set { username = value; } }
            internal static string Password { get { return password; } set { password = value; } }
        }

        internal struct COMMAND
        {
            internal const string PRICES     = "3F6EF31CFAF226750EED50B6E4E7B419ED9968C4";
            internal const string SIGNOUT    = "DC1649A16C1496DB3E4073BE6A73FAF5121AEAE7";
            internal const string SHUTDOWN   = "E75039654B0D80A398D5EEBE5702911AD429C9AB";
            internal const string HIBERNATE  = "ABE4B589CF03727FDC21C74BE67EEC9F04253F89";
            internal const string RESTART    = "B134BD555A2F6EC5313C1B2A225B2C17F3409351";
            internal const string SLEEP      = "3CAC34E674464C2B62286054CD9A2D2C81149EFC";
            internal const string TIMER      = "9D9CEC22F36FD2BB99D5FE8C4723347BEC202CA5";
            internal const string STOPWATCH  = "15BD6CC6511CCCE656D14B32B337AA165AC636C2";
            internal const string CHECKOUT   = "3AC8E9E58C5ABADDBF9D265D4965B9B8F0A3B787";
            internal const string UPDATE     = "FB91E24FA52D8D2B32937BF04D843F730319A902";
            internal const string BALLOONTIP = "BD17BE2BC4C0DC7ACC703E1B64A299E9A2801D29";
            internal const string MSGBOX     = "81EFA52F20BA21BAC9667C66DFF561B537F4CF86";
            internal const string CONTINUE   = "2E02623966F9391FACF6EAEFC8B079ED5B630BEE";
            internal const string EXECUTE    = "6EA36CE8D4940505E9A2C8FEA5DB868CD8B3D440";
            internal const string SECURITY   = "F25CE1B8A399BD8621A57427A20039B4B13935DB";
        }

        internal struct DEFAULT
        {
            internal const string IPV4 = "127.0.0.1";
            internal const string IPV6 = "0:0:0:0:0:0:0:1";
            internal const int    PORT = 4096;
            internal const int    MIN_PORT_NO = 1024;
            internal const int    MAX_PORT_NO = 65535;
            internal const string MAC_ADDRESS = "00:00:00:00:00:00";
        }

        internal struct PRICING
        {
            internal static decimal Price = 0.00M;
            internal static decimal Extra = 0.00M;
            internal static decimal Minimum = 0.00M;
            internal static decimal Start = 0.00M;
        }

        internal struct TIME
        {
            internal static int Time = 0;
            internal static int Used = 0;
            internal static int Left = 0;
            internal static int Total = 0;
        }

        internal struct ENDPOINT
        {
            internal static string IPvX = DEFAULT.IPV4;
            internal static int    PtNo = DEFAULT.PORT;
        }

        internal struct PROPERTIES
        {
            internal const string SERVER_ID_STR = "9AA1B03934893D7134A660AF4204F2A9";
            internal const string CLIENT_ID_STR = "577D7068826DE925EA2AEC01DBADF5E4";
            internal static string Command      = COMMAND.STOPWATCH;
            internal static bool TimeOver       = false;
            internal static string KeyData { get { return string.Format(
                @"<?xml version = '1.0'?>" +
                "<!-- Slave: QCodeX.bin -->" +
                "<Data BufferSize='{0}'>" +
                "<AppData Title='{1}' Name='{2}' GUID='{3}'>" +
                "<KeyData UserName='{4}' Password='{5}' UserGUID='{6}'/>" +
                "</AppData></Data>", "Slave","CyberCtrl"
                , Forms.Slave.AppGUID, SECURITY.UserName, SECURITY.Password, SECURITY.UserGUID); } }
            internal static int BufferSize = KeyData.Length;
        }
    }
}
