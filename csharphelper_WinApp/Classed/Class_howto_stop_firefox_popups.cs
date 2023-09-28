
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;

  namespace  howto_stop_firefox_popups

 { 

static class DesktopWindowsStuff
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowText",
        ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpWindowText, int nMaxCount);

        [DllImport("user32.dll", EntryPoint = "EnumDesktopWindows",
        ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumDelegate lpEnumCallbackFunction, IntPtr lParam);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private const UInt32 WM_CLOSE = 0x0010;

        // Define the callback delegate's type.
        private delegate bool EnumDelegate(IntPtr hWnd, int lParam);

        // Return a list of the desktop windows' handles and titles.
        public static void GetDesktopWindowHandlesAndTitles(out List<IntPtr> handles, out List<string> titles)
        {
            WindowHandles = new List<IntPtr>();
            WindowTitles = new List<string>();

            if (!EnumDesktopWindows(IntPtr.Zero, FilterCallback, IntPtr.Zero))
            {
                handles = null;
                titles = null;
            }
            else
            {
                handles = WindowHandles;
                titles = WindowTitles;
            }
        }

        // Save window titles and handles in these lists.
        private static List<IntPtr> WindowHandles;
        private static List<string> WindowTitles;

        // We use this function to filter windows.
        // This version selects visible windows that have titles.
        private static bool FilterCallback(IntPtr hWnd, int lParam)
        {
            // Get the window's title.
            StringBuilder sb_title = new StringBuilder(1024);
            int length = GetWindowText(hWnd, sb_title, sb_title.Capacity);
            string title = sb_title.ToString();

            // If the window is visible and has a title, save it.
            if (IsWindowVisible(hWnd) && string.IsNullOrEmpty(title) == false)
            {
                WindowHandles.Add(hWnd);
                WindowTitles.Add(title);
            }

            // Return true to indicate that we
            // should continue enumerating windows.
            return true;
        }

        // Send a message to a process.
        private static void PostMessageToWindow(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            if (!PostMessage(hWnd, msg, wParam, lParam))
            {
                // An error occured.
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        // Stop a window.
        public static void StopWindow(IntPtr hWnd)
        {
            PostMessageToWindow(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }
    }

}