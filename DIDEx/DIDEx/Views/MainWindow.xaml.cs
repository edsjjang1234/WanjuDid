using System;
using System.Windows;
using System.Windows.Input;
using static NativeLib.NativeMethods;

namespace DIDEx
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            HideDeskTop();
            HideTaskBar();

            this.WindowStyle = WindowStyle.None;
            this.WindowState = WindowState.Maximized;

            InitializeComponent();
            
            //Mouse.OverrideCursor = Cursors.None; //마우스포인터 숨김
        }

        /// <summary>
        /// 작업표시줄을 숨김
        /// </summary>
        public static void HideTaskBar()
        {
            int hwnd = FindTrayWindow();
            if (hwnd != 0)
                ShowWindow(new IntPtr(hwnd), ShowWindowCommands.SW_HIDE);

            hwnd = FindStartButton();
            if (hwnd != 0) // 시작 버튼은 있을 수도 있고 없을수도 있다.      
                ShowWindow(new IntPtr(hwnd), ShowWindowCommands.SW_HIDE);
        }

        /// <summary>
        /// 작업표시줄을 보이게 설정
        /// </summary>
        public static void ShowTaskBar()
        {
            int hwnd = FindTrayWindow();
            if (hwnd != 0)
                ShowWindow(new IntPtr(hwnd), ShowWindowCommands.SW_SHOW);

            hwnd = FindStartButton();
            if (hwnd != 0) // 시작 버튼은 있을 수도 있고 없을수도 있다.      
                ShowWindow(new IntPtr(hwnd), ShowWindowCommands.SW_SHOW);
        }

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
        /// 바탕화면을 보이게함
        /// </summary>
        public static void ShowDeskTop()
        {
            int hwnd = FindDesktop();

            if (hwnd != 0)
                ShowWindow(new IntPtr(hwnd), ShowWindowCommands.SW_SHOW);
        }

        private static int FindTrayWindow()
        {
            return FindWindow("Shell_TrayWnd", null);
        }

        private static int FindStartButton()
        {
            int hwnd = FindWindow("Button", "시작");

            if (hwnd == 0)
                hwnd = FindWindow("Start", "시작"); //윈도우10은 Class가 Start이다.

            return hwnd;
        }

        private static int FindDesktop()
        {
            int hwnd = FindWindow("MainWindowViewModel", "MainWindow");

            if (hwnd == 0)
                hwnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Progman", null);

            return hwnd;
        }

        private void MainMenuRadio_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
