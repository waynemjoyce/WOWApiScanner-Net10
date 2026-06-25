using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace WOWAuctionApi_Net10
{ 
    public static class FocusDetector
    {
        // Native API declaration to fetch the active window handle
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        // Native API declaration to get the process ID from a window handle
        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        /// <summary>
        /// Retrieves the System.Diagnostics.Process object of the application currently in focus.
        /// </summary>
        public static Process? GetFocusedApplication()
        {
            IntPtr hwnd = GetForegroundWindow();
            if (hwnd == IntPtr.Zero)
            {
                return null; // No window currently has focus
            }

            GetWindowThreadProcessId(hwnd, out uint processId);

            try
            {
                return Process.GetProcessById((int)processId);
            }
            catch (ArgumentException)
            {
                // The process may have exited immediately after fetching its ID
                return null;
            }
        }
    }
}
