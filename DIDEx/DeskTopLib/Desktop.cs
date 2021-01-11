using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTopLib
{
    public class Desktop
    {
        /// <summary>
        /// 바탕화면을 숨김
        /// </summary>
        public static void HideDeskTop()
        {
            int hwnd = FindDesktop();

            if (hwnd != 0)
                ShowWindow(new IntPtr(hwnd), ShowWindowCommands.SW_HIDE);
        }

        /// <summary>
        /// 바탕화면을 보이게 설정
        /// </summary>
        public static void ShowDeskTop()
        {
            int hwnd = FindDesktop();

            if (hwnd != 0)
                ShowWindow(new IntPtr(hwnd), ShowWindowCommands.SW_SHOW);
        }



        private static int FindDesktop()
        {
            int hwnd = FindWindow("Progman", "Program Manager");

            if (hwnd == 0)
                hwnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Progman", null);

            return hwnd;
        }
    }
}
