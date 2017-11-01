using System;
using System.Runtime.InteropServices;

namespace Classes
{
    internal static class ExitWinEx
    {

        private const uint SE_PRIVILEGE_ENABLED                          = 0x00000002;
        private const uint SE_PRIVILEGE_ENABLED_BY_DEFAULT               = 0x00000001;
        private const uint SE_PRIVILEGE_REMOVED                          = 0x00000004;
        private const uint SE_PRIVILEGE_USED_FOR_ACCESS                  = 0x80000000;
        
        private struct SE_PRIVILEGE_NAME
        {

            internal const string SE_ASSIGNPRIMARYTOKEN_NAME             = "SeAssignPrimaryTokenPrivilege";
            internal const string SE_AUDIT_NAME                          = "SeAuditPrivilege";
            internal const string SE_BACKUP_NAME                         = "SeBackupPrivilege";
            internal const string SE_CHANGE_NOTIFY_NAME                  = "SeChangeNotifyPrivilege";
            internal const string SE_CREATE_GLOBAL_NAME                  = "SeCreateGlobalPrivilege";
            internal const string SE_CREATE_PAGEFILE_NAME                = "SeCreatePagefilePrivilege";
            internal const string SE_CREATE_PERMANENT_NAME               = "SeCreatePermanentPrivilege";
            internal const string SE_CREATE_SYMBOLIC_LINK_NAME           = "SeCreateSymbolicLinkPrivilege";
            internal const string SE_CREATE_TOKEN_NAME                   = "SeCreateTokenPrivilege";
            internal const string SE_DEBUG_NAME                          = "SeDebugPrivilege";
            internal const string SE_ENABLE_DELEGATION_NAME              = "SeEnableDelegationPrivilege";
            internal const string SE_IMPERSONATE_NAME                    = "SeImpersonatePrivilege";
            internal const string SE_INC_BASE_PRIORITY_NAME              = "SeIncreaseBasePriorityPrivilege";
            internal const string SE_INCREASE_QUOTA_NAME                 = "SeIncreaseQuotaPrivilege";
            internal const string SE_INC_WORKING_SET_NAME                = "SeIncreaseWorkingSetPrivilege";
            internal const string SE_LOAD_DRIVER_NAME                    = "SeLoadDriverPrivilege";
            internal const string SE_LOCK_MEMORY_NAME                    = "SeLockMemoryPrivilege";
            internal const string SE_MACHINE_ACCOUNT_NAME                = "SeMachineAccountPrivilege";
            internal const string SE_MANAGE_VOLUME_NAME                  = "SeManageVolumePrivilege";
            internal const string SE_PROF_SINGLE_PROCESS_NAME            = "SeProfileSingleProcessPrivilege";
            internal const string SE_RELABEL_NAME                        = "SeRelabelPrivilege";
            internal const string SE_REMOTE_SHUTDOWN_NAME                = "SeRemoteShutdownPrivilege";
            internal const string SE_RESTORE_NAME                        = "SeRestorePrivilege";
            internal const string SE_SECURITY_NAME                       = "SeSecurityPrivilege";
            internal const string SE_SHUTDOWN_NAME                       = "SeShutdownPrivilege";
            internal const string SE_SYNC_AGENT_NAME                     = "SeSyncAgentPrivilege";
            internal const string SE_SYSTEM_ENVIRONMENT_NAME             = "SeSystemEnvironmentPrivilege";
            internal const string SE_SYSTEM_PROFILE_NAME                 = "SeSystemProfilePrivilege";
            internal const string SE_SYSTEMTIME_NAME                     = "SeSystemtimePrivilege";
            internal const string SE_TAKE_OWNERSHIP_NAME                 = "SeTakeOwnershipPrivilege";
            internal const string SE_TCB_NAME                            = "SeTcbPrivilege";
            internal const string SE_TIME_ZONE_NAME                      = "SeTimeZonePrivilege";
            internal const string SE_TRUSTED_CREDMAN_ACCESS_NAME         = "SeTrustedCredManAccessPrivilege";
            internal const string SE_UNDOCK_NAME                         = "SeUndockPrivilege";
            internal const string SE_UNSOLICITED_INPUT_NAME              = "SeUnsolicitedInputPrivilege";

        }
        private struct ACCESS_MASK
        {

            internal const uint STANDARD_RIGHTS_REQUIRED                 = 0x000F0000;
            internal const uint STANDARD_RIGHTS_READ                     = 0x00020000;
            internal const uint TOKEN_ASSIGN_PRIMARY                     = 0x0001;
            internal const uint TOKEN_DUPLICATE                          = 0x0002;
            internal const uint TOKEN_IMPERSONATE                        = 0x0004;
            internal const uint TOKEN_QUERY                              = 0x0008;
            internal const uint TOKEN_QUERY_SOURCE                       = 0x0010;
            internal const uint TOKEN_ADJUST_PRIVILEGES                  = 0x0020;
            internal const uint TOKEN_ADJUST_GROUPS                      = 0x0040;
            internal const uint TOKEN_ADJUST_DEFAULT                     = 0x0080;
            internal const uint TOKEN_ADJUST_SESSIONID                   = 0x0100;
            internal const uint TOKEN_ALL_ACCESS                         = 0xF003F;

        }
        private struct uFlags
        {

            internal const uint EWX_HYBRID_SHUTDOWN                      = 0x00400000;
            internal const uint EWX_LOGOFF                               = 0x00000000;
            internal const uint EWX_POWEROFF                             = 0x00000008;
            internal const uint EWX_REBOOT                               = 0x00000002;
            internal const uint EWX_RESTARTAPPS                          = 0x00000040;
            internal const uint EWX_SHUTDOWN                             = 0x00000001;
            internal const uint EWX_FORCE                                = 0x00000004;
            internal const uint EWX_FORCEIFHUNG                          = 0x00000010;

        }
        private struct dwReason
        {

            internal const uint SHTDN_REASON_MAJOR_APPLICATION           = 0x00040000;
            internal const uint SHTDN_REASON_MAJOR_HARDWARE              = 0x00010000;
            internal const uint SHTDN_REASON_MAJOR_LEGACY_API            = 0x00070000;
            internal const uint SHTDN_REASON_MAJOR_OPERATINGSYSTEM       = 0x00020000;
            internal const uint SHTDN_REASON_MAJOR_OTHER                 = 0x00000000;
            internal const uint SHTDN_REASON_MAJOR_POWER                 = 0x00060000;
            internal const uint SHTDN_REASON_MAJOR_SOFTWARE              = 0x00030000;
            internal const uint SHTDN_REASON_MAJOR_SYSTEM                = 0x00050000;
            internal const uint SHTDN_REASON_MINOR_BLUESCREEN            = 0x0000000F;
            internal const uint SHTDN_REASON_MINOR_CORDUNPLUGGED         = 0x0000000b;
            internal const uint SHTDN_REASON_MINOR_DISK                  = 0x00000007;
            internal const uint SHTDN_REASON_MINOR_EVIRONMENT            = 0x0000000c;
            internal const uint SHTDN_REASON_MINOR_HARDWARE_DRIVER       = 0x0000000d;
            internal const uint SHTDN_REASON_MINOR_HOTFIX                = 0x00000011;
            internal const uint SHTDN_REASON_MINOR_HOTFIX_UNINSTALL      = 0x00000017;
            internal const uint SHTDN_REASON_MINOR_HUNG                  = 0x00000005;
            internal const uint SHTDN_REASON_MINOR_INSTALLATION          = 0x00000002;
            internal const uint SHTDN_REASON_MINOR_MAINTENANCE           = 0x00000001;
            internal const uint SHTDN_REASON_MINOR_MMC                   = 0x00000019;
            internal const uint SHTDN_REASON_MINOR_NETWORK_CONNECTIVITY  = 0x00000014;
            internal const uint SHTDN_REASON_MINOR_NETWORKCARD           = 0x00000009;
            internal const uint SHTDN_REASON_MINOR_OTHER                 = 0x00000000;
            internal const uint SHTDN_REASON_MINOR_OTHERDRIVE            = 0x0000000e;
            internal const uint SHTDN_REASON_MINOR_POWER_SUPPLY          = 0x0000000a;
            internal const uint SHTDN_REASON_MINOR_PROCESSOR             = 0x00000008;
            internal const uint SHTDN_REASON_MINOR_RECONFIG              = 0x00000004;
            internal const uint SHTDN_REASON_MINOR_SECURITYFIX           = 0x00000012;
            internal const uint SHTDN_REASON_MINOR_SECURITYFIX_UNINSTALL = 0x00000018;
            internal const uint SHTDN_REASON_MINOR_SERVICEPACK           = 0x00000010;
            internal const uint SHTDN_REASON_MINOR_SERVICEPACK_UNINSTALL = 0x00000016;
            internal const uint SHTDN_REASON_MINOR_TERMSRV               = 0x00000020;
            internal const uint SHTDN_REASON_MINOR_UNSTABLE              = 0x00000006;
            internal const uint SHTDN_REASON_MINOR_UPGRADE               = 0x00000003;
            internal const uint SHTDN_REASON_MINOR_WMI                   = 0x00000015;
            internal const uint SHTDN_REASON_FLAG_USER_DEFINED           = 0x40000000;
            internal const uint SHTDN_REASON_FLAG_PLANNED                = 0x80000000;

        }
        //###########################################################################
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetCurrentProcess();
        //###########################################################################
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetSystemPowerState(bool fSuspend, bool fForce);
        //###########################################################################
        [DllImport("Powrprof.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetSuspendState(bool Hibernate, bool ForceCritical, bool DisableWakeEvent);
        //###########################################################################
        [DllImport("advapi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool OpenProcessToken(IntPtr ProcessHandle, uint DesiredAccess, out IntPtr TokenHandle);
        //###########################################################################
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AdjustTokenPrivileges(IntPtr TokenHandle, bool DisableAllPrivileges,
            ref TOKEN_PRIVILEGES NewState, uint BufferLength, UIntPtr PreviousState, UIntPtr ReturnLength);
        //###########################################################################
        [DllImport("advapi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool LookupPrivilegeValue(string lpSystemName, string lpName, out LUID lpLuid);
        //###########################################################################
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ExitWindowsEx(uint uFlags, uint dwReason);
        //###########################################################################
        private struct LUID
        {
            internal uint LowPart;
            internal int HighPart;
        }
        private struct LUID_AND_ATTRIBUTES
        {
            internal LUID Luid;
            internal uint Attributes;
        }
        private struct TOKEN_PRIVILEGES
        {
            internal uint PrivilegeCount;
            internal LUID_AND_ATTRIBUTES Privileges;
        }
        private static void GetPrivileges()
        {
            IntPtr token = IntPtr.Zero;
            TOKEN_PRIVILEGES tkp;
            tkp.PrivilegeCount = 1;
            tkp.Privileges.Attributes = SE_PRIVILEGE_ENABLED;
            OpenProcessToken(GetCurrentProcess(), ACCESS_MASK.TOKEN_ALL_ACCESS, out token);
            LookupPrivilegeValue(string.Empty, SE_PRIVILEGE_NAME.SE_SHUTDOWN_NAME, out tkp.Privileges.Luid);
            AdjustTokenPrivileges(token, false, ref tkp, 0U, UIntPtr.Zero, UIntPtr.Zero);
        }
        internal static void Restart() { Restart(false); }
        internal static void Restart(bool force)
        {
            GetPrivileges();
            ExitWindowsEx(uFlags.EWX_REBOOT | (force ? uFlags.EWX_FORCE : 0), dwReason.SHTDN_REASON_MAJOR_OTHER);
        }
        internal static void LogOff() { LogOff(false); }
        internal static void LogOff(bool force)
        {
            GetPrivileges();
            ExitWindowsEx(uFlags.EWX_LOGOFF | (force ? uFlags.EWX_FORCE : 0), dwReason.SHTDN_REASON_MAJOR_OTHER);
        }
        internal static void Shutdown() { Shutdown(false); }
        internal static void Shutdown(bool force)
        {
            GetPrivileges();
            ExitWindowsEx(uFlags.EWX_SHUTDOWN | (force ? uFlags.EWX_FORCE : 0), dwReason.SHTDN_REASON_MAJOR_OTHER);
        }
        internal static void Sleep() { Sleep(false); }
        internal static void Sleep(bool force)
        {
            GetPrivileges();
            if (SetSystemPowerState(true, force)) { return; }
            if (SetSuspendState(false, force, false)) { return; }
        }
        internal static void Hibernate() { Hibernate(false); }
        internal static void Hibernate(bool force)
        {
            GetPrivileges();
            if (SetSystemPowerState(false, force)) { return; }
            if (SetSuspendState(true, force, false)) { return; }
        }
    }
}
