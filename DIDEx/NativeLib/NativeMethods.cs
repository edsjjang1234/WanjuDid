using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NativeLib
{
    public class NativeMethods
    {
        public const string USER32 = "User32.Dll";

        public enum ShowWindowCommands
        {
            SW_HIDE = 0,
            SHOWNORMAL = 1,
            SHOWMINIMIZED = 2,
            MAXIMIZE = 3,
            SHOWNOACTIVATE = 4,
            SW_SHOW = 5,
            MINIMIZE = 6,
            SHOWMINNOACTIVE = 7,
            SHOWNA = 8,
            RESTORE = 9,
            SHOWDEFAULT = 10,
            FORCEMINIMIZE = 11
        }

        [DllImport(USER32, EntryPoint = "ShowWindow")]
        public static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands cmdShow);
        [DllImport(USER32, EntryPoint = "FindWindow")]
        public static extern Int32 FindWindow(String lpClassName, String lpWindowName);
        [DllImport(USER32, SetLastError = true)]
        public static extern int FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);
    }
}
