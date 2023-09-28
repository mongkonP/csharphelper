
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

  namespace  howto_find_window_partial_name

 { 

public static class DesktopWindowsStuff
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowText",
        ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd,
            StringBuilder lpWindowText, int nMaxCount);

        [DllImport("user32.dll", EntryPoint = "EnumDesktopWindows",
        ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool EnumDesktopWindows(IntPtr hDesktop,
            EnumDelegate lpEnumCallbackFunction, IntPtr lParam);

        // Define the FindWindow API function.
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        // Define the SetWindowPos API function.
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

        // Define the SetWindowPosFlags enumeration.
        [Flags()]
        private enum SetWindowPosFlags : uint
        {
            SynchronousWindowPosition = 0x4000,
            DeferErase = 0x2000,
            DrawFrame = 0x0020,
            FrameChanged = 0x0020,
            HideWindow = 0x0080,
            DoNotActivate = 0x0010,
            DoNotCopyBits = 0x0100,
            IgnoreMove = 0x0002,
            DoNotChangeOwnerZOrder = 0x0200,
            DoNotRedraw = 0x0008,
            DoNotReposition = 0x0200,
            DoNotSendChangingEvent = 0x0400,
            IgnoreResize = 0x0001,
            IgnoreZOrder = 0x0004,
            ShowWindow = 0x0040,
        }

#region "SetWindowPlacement"
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetWindowPlacement(IntPtr hWnd,
           [In] ref WINDOWPLACEMENT lpwndpl);

        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        internal struct WINDOWPLACEMENT
        {
            public int Length;
            public int Flags;
            public ShowWindowCommands ShowCmd;
            public POINT MinPosition;
            public POINT MaxPosition;
            public RECT NormalPosition;
            public static WINDOWPLACEMENT Default
            {
                get
                {
                    WINDOWPLACEMENT result = new WINDOWPLACEMENT();
                    result.Length = Marshal.SizeOf(result);
                    return result;
                }
            }
        }

        public enum ShowWindowCommands : int
        {
            Hide = 0,
            Normal = 1,
            ShowMinimized = 2,
            Maximize = 3, // is this the right value?
            ShowMaximized = 3,
            ShowNoActivate = 4,
            Show = 5,
            Minimize = 6,
            ShowMinNoActive = 7,
            ShowNA = 8,
            Restore = 9,
            ShowDefault = 10,
            ForceMinimize = 11
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public static implicit operator System.Drawing.Point(POINT p)
            {
                return new System.Drawing.Point(p.X, p.Y);
            }

            public static implicit operator POINT(System.Drawing.Point p)
            {
                return new POINT(p.X, p.Y);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            private int _Left;
            private int _Top;
            private int _Right;
            private int _Bottom;
        }

        // Wrapper for SetWindowPlacement.
        public static void SetWindowPlacement(IntPtr handle,
            ShowWindowCommands show_command)
        {
            // Prepare the WINDOWPLACEMENT structure.
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            placement.Length = Marshal.SizeOf(placement);

            // Get the window's current placement.
            GetWindowPlacement(handle, out placement);

            // Perform the action.
            placement.ShowCmd = show_command;
            SetWindowPlacement(handle, ref placement);
        }
#endregion "SetWindowPlacement"

        // Extension to add a Matches method to the string class.
        public static bool Matches(this string the_string, string pattern)
        {
            Regex reg_exp = new Regex(pattern);
            return reg_exp.IsMatch(the_string);
        }

        // Define the callback delegate's type.
        private delegate bool EnumDelegate(IntPtr hWnd, int lParam);

        // The target window's pattern to match and the found handle and title.
        private static string MatchPattern;
        private static IntPtr MatchedHandle;
        private static string MatchedTitle;

        // Return a list of the desktop windows' handles and titles.
        public static void FindWindowTitleMatch(string pattern, out IntPtr handle, out string title)
        {
            MatchPattern = pattern;
            MatchedHandle = IntPtr.Zero;
            MatchedTitle = "";

            EnumDesktopWindows(IntPtr.Zero, FilterCallback, IntPtr.Zero);

            handle = MatchedHandle;
            title = MatchedTitle;
        }

        // Select the first window that matches the target pattern.
        private static bool FilterCallback(IntPtr hWnd, int lParam)
        {
            // Get the window's title.
            StringBuilder sb_title = new StringBuilder(1024);
            int length = GetWindowText(hWnd, sb_title, sb_title.Capacity);
            string title = sb_title.ToString();

            // If the window is visible and has a title, see if it matches.
            if (IsWindowVisible(hWnd) && string.IsNullOrEmpty(title) == false)
            {
                if (title.Matches(MatchPattern))
                {
                    MatchedHandle = hWnd;
                    MatchedTitle = title;
                    // Return false to indicate that we
                    // don't need to continue enumerating windows.
                    return false;
                }
            }

            // Return true to indicate that we
            // should continue enumerating windows.
            return true;
        }

        // Set a window's size and position.
        public static void SetWindowPosition(IntPtr handle,
            int x, int y, int width, int height)
        {
            SetWindowPos(handle, IntPtr.Zero, x, y, width, height, 0);
        }
    }

}