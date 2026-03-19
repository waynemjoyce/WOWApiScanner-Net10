using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace WOWAuctionApi_Net10
{
    public static class HelpProc
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void ActivateApp(int ProcessId, int delayBefore = 100, int delayAfter = 100)
        {
            Thread.Sleep(delayBefore);
            Process proc = Process.GetProcessById(ProcessId);
            if (proc != null)
            {
                SetForegroundWindow(proc.MainWindowHandle);
            }
            Thread.Sleep(delayAfter);
        }       

        public static Process[] GetWowProcesses()
        {
            Process[] allProcs = Process.GetProcessesByName("wow");
            return allProcs;        
        }
    }
}
