using System;
using Microsoft.Win32;

namespace Classes
{
    internal static class Registry
    {
        private const string DEFAULT_REG_KEY = "Software\\CyberCtrl\\Slave";
        private static RegistryKey Key
        {
            get { return Microsoft.Win32.Registry.CurrentUser; }
        }
        internal static void SaveIPEndPoint(string IPvX, int PtNo)
        {
            RegistryKey RegKey = Key.CreateSubKey(DEFAULT_REG_KEY, RegistryKeyPermissionCheck.ReadWriteSubTree);
            RegKey.SetValue("IPvX", IPvX, RegistryValueKind.String);
            RegKey.SetValue("PtNo", PtNo, RegistryValueKind.DWord);
            AppData.ENDPOINT.IPvX = IPvX; AppData.ENDPOINT.PtNo = PtNo;
            RegKey.Close(); RegKey = null;
        }

        internal static void SaveKeyData(string Username, string Password, string UserGUID)
        {
            RegistryKey RegKey = Key.CreateSubKey(DEFAULT_REG_KEY, RegistryKeyPermissionCheck.ReadWriteSubTree);
            RegKey.SetValue("Username", Username, RegistryValueKind.String);
            RegKey.SetValue("Password", Password, RegistryValueKind.String);
            RegKey.SetValue("UserGUID", UserGUID, RegistryValueKind.String);
            RegKey.Close(); RegKey = null;
        }

        internal static void ReadRegData()
        {
            RegistryKey RegKey = Key.CreateSubKey(DEFAULT_REG_KEY, RegistryKeyPermissionCheck.ReadWriteSubTree);
            AppData.ENDPOINT.IPvX = Convert.ToString(RegKey.GetValue("IPvX", AppData.ENDPOINT.IPvX));
            AppData.ENDPOINT.PtNo = Convert.ToInt32(RegKey.GetValue("PtNo", AppData.ENDPOINT.PtNo));
            AppData.SECURITY.UserName = Convert.ToString(RegKey.GetValue("Username", AppData.SECURITY.UserName));
            AppData.SECURITY.Password = Convert.ToString(RegKey.GetValue("Password", AppData.SECURITY.Password));
            AppData.SECURITY.UserGUID = Convert.ToString(RegKey.GetValue("UserGUID", AppData.SECURITY.UserGUID));
            AppData.TIME.Time = Convert.ToInt32(RegKey.GetValue("TimeUsed", AppData.TIME.Time));
            AppData.PROPERTIES.Command = Convert.ToString(RegKey.GetValue("Command", AppData.PROPERTIES.Command));
            AppData.TIME.Total = Convert.ToInt32(RegKey.GetValue("TimeLeft", AppData.TIME.Total));
            RegKey.Close(); RegKey = null;
        }

        internal static void SaveElapsedTime(string Time)
        {
            RegistryKey RegKey = Key.CreateSubKey(DEFAULT_REG_KEY, RegistryKeyPermissionCheck.ReadWriteSubTree);
            RegKey.SetValue("TimeUsed", AppData.TIME.Time, RegistryValueKind.DWord);
            RegKey.SetValue("Command", AppData.PROPERTIES.Command, RegistryValueKind.String);
            RegKey.SetValue("TimeLeft", AppData.TIME.Total, RegistryValueKind.DWord);
            RegKey.Close(); RegKey = null;
        }
    }
}
