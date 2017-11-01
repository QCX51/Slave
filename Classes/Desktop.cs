using System;
using System.Runtime.InteropServices;

namespace Classes
{
    internal sealed class Desktop
    {
        //private static IntPtr ThreadID = GetThreadDesktop(GetCurrentThreadId());
        //internal static IntPtr OldDesktop = ThreadID;
        internal static IntPtr NewDesktop = CreateDesktop(Forms.Slave.AppGUID, IntPtr.Zero, IntPtr.Zero, 0, (uint)DESKTOP_ACCESS.GENERIC_ALL, IntPtr.Zero);
        internal static IntPtr OldDesktop = OpenInputDesktop(0, false, (uint)DESKTOP_ACCESS.GENERIC_ALL);

        [DllImport("user32.dll")]
        internal static extern IntPtr CreateDesktop(string lpszDesktop, IntPtr lpszDevice, IntPtr pDevMode, int dwFlags, uint dwDesiredAccess, IntPtr lpsa);
        [DllImport("user32.dll")]
        internal static extern IntPtr OpenInputDesktop(int flags, bool inherit, uint desiredAccess);
        [DllImport("user32.dll", EntryPoint = "OpenDesktop")]
        internal static extern IntPtr OpenDesktop(IntPtr lpszDesktop, uint dwFlags, bool fInherit, uint dwDesiredAccess);
        [DllImport("user32.dll")]
        internal static extern bool SwitchDesktop(IntPtr handle);
        [DllImport("user32.dll")]
        internal static extern bool CloseDesktop(IntPtr handle);
        [DllImport("user32.dll")]
        internal static extern bool SetThreadDesktop(IntPtr hDesktop);
        [DllImport("user32.dll")]
        internal static extern IntPtr GetThreadDesktop(int dwThreadId);
        [DllImport("kernel32.dll")]
        internal static extern int GetCurrentThreadId();
        internal struct DESKTOP_ACCESS
        {
            internal const long DESKTOP_DELETE = 0x00010000L;
            internal const long DESKTOP_READ_CONTROL = 0x00020000L;
            internal const long DESKTOP_SYNCHRONIZE = 0x00100000L; // Not supported for desktop objects.
            internal const long DESKTOP_WRITE_DAC = 0x00040000L;
            internal const long DESKTOP_WRITE_OWNER = 0x00080000L;
            internal const long DESKTOP_CREATE_MENU = 0x0004L;
            internal const long DESKTOP_CREATE_WINDOW = 0x0002L;
            internal const long DESKTOP_ENUMERATE = 0x0040L;
            internal const long DESKTOP_HOOK_CONTROL = 0x0008L;
            internal const long DESKTOP_JOURNAL_PLAYBACK = 0x0020L;
            internal const long DESKTOP_JOURNAL_RECORD = 0x0010L;
            internal const long DESKTOP_READ_OBJECTS = 0x0001L;
            internal const long DESKTOP_SWITCH_DESKTOP = 0x0100L;
            internal const long DESKTOP_WRITE_OBJECTS = 0x0080L;

            internal const long STANDARD_RIGHTS_ALL = (DESKTOP_DELETE | DESKTOP_READ_CONTROL |
                    DESKTOP_WRITE_DAC | DESKTOP_WRITE_OWNER | DESKTOP_SYNCHRONIZE);

            internal const long STANDARD_RIGHTS_EXECUTE = DESKTOP_READ_CONTROL;

            internal const long STANDARD_RIGHTS_READ = DESKTOP_READ_CONTROL;

            internal const long STANDARD_RIGHTS_REQUIRED = (DESKTOP_DELETE | DESKTOP_READ_CONTROL | DESKTOP_WRITE_DAC |
                    DESKTOP_WRITE_OWNER);

            internal const long STANDARD_RIGHTS_WRITE = DESKTOP_READ_CONTROL;

            internal const long GENERIC_READ = (DESKTOP_ENUMERATE | DESKTOP_READ_OBJECTS | STANDARD_RIGHTS_READ);

            internal const long GENERIC_WRITE = (DESKTOP_CREATE_MENU | DESKTOP_CREATE_WINDOW | DESKTOP_HOOK_CONTROL |
                    DESKTOP_JOURNAL_PLAYBACK | DESKTOP_JOURNAL_RECORD | DESKTOP_WRITE_OBJECTS | STANDARD_RIGHTS_WRITE);

            internal const long GENERIC_EXECUTE = (DESKTOP_SWITCH_DESKTOP | STANDARD_RIGHTS_EXECUTE);

            internal const long GENERIC_ALL = (DESKTOP_CREATE_MENU | DESKTOP_CREATE_WINDOW | DESKTOP_ENUMERATE |
                    DESKTOP_HOOK_CONTROL | DESKTOP_JOURNAL_PLAYBACK | DESKTOP_JOURNAL_RECORD |
                    DESKTOP_READ_OBJECTS | DESKTOP_SWITCH_DESKTOP | DESKTOP_WRITE_OBJECTS | STANDARD_RIGHTS_REQUIRED);
        }
    }
}
