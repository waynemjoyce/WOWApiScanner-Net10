using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;

namespace WOWAuctionApi_Net10
{
    public static class MouseHelper
    {
        // Define the INPUT type
        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            public int type;
            public InputUnion U;
        }

        // Define the InputUnion
        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)]
            public MOUSEINPUT mi;
            // Keyboard and hardware inputs can also be defined here if needed
        }

        // Define the MOUSEINPUT type
        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        // Define MouseEventFlags
        [Flags]
        public enum MouseEventFlags : uint
        {
            MOUSEEVENTF_ABSOLUTE = 0x0008,
            MOUSEEVENTF_LEFTDOWN = 0x0002,
            MOUSEEVENTF_LEFTUP = 0x0004,
            MOUSEEVENTF_MOVE = 0x0001,
            MOUSEEVENTF_RIGHTDOWN = 0x0008,
            MOUSEEVENTF_RIGHTUP = 0x0010
        }

        // Define the SendInput function (P/Invoke)
        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        // Define SetCursorPos to move the cursor before clicking, if not using MOUSEEVENTF_ABSOLUTE
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        // Get screen size for absolute coordinates conversion
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        private enum DeviceCap { HORZRES = 8, VERTRES = 10 }

        private static int screenWidth = GetDeviceCaps(Graphics.FromHwnd(IntPtr.Zero).GetHdc(), (int)DeviceCap.HORZRES);
        private static int screenHeight = GetDeviceCaps(Graphics.FromHwnd(IntPtr.Zero).GetHdc(), (int)DeviceCap.VERTRES);


        public static void Move(
            int x, 
            int y)
        {
            MoveAndClick(x, y, null, 0);
        }

        public static void MoveAndClick(
            int x, 
            int y,
            InteractionMouseClickType? clickType,
            int delayBetween = 100,
            int numClicks = 1
            )
        {
            SetCursorPos(x, y);
            for (int i = 0; i < numClicks; i++)
            {
                if (clickType != null)
                {
                    Thread.Sleep(delayBetween);
                    if (clickType == InteractionMouseClickType.Left)
                    {
                        DoClick(MouseEventFlags.MOUSEEVENTF_LEFTDOWN, MouseEventFlags.MOUSEEVENTF_LEFTUP);
                    }
                    else
                    {
                        DoClick(MouseEventFlags.MOUSEEVENTF_RIGHTDOWN, MouseEventFlags.MOUSEEVENTF_RIGHTUP);
                    }
                }
            }
        }

        public static void DoLeftClick()
        {
            DoClick(MouseEventFlags.MOUSEEVENTF_LEFTDOWN, MouseEventFlags.MOUSEEVENTF_LEFTUP);
        }

        public static void DoRightClick()
        {
            DoClick(MouseEventFlags.MOUSEEVENTF_RIGHTDOWN, MouseEventFlags.MOUSEEVENTF_RIGHTUP);
        }

        private static void DoClick(MouseEventFlags downEvent, MouseEventFlags upEvent)
        {
            INPUT[] inputs = new INPUT[2];

            // Right Down event
            inputs[0].type = 0; // INPUT_MOUSE
            inputs[0].U.mi.dwFlags = (uint)downEvent;

            // Right Up event
            inputs[1].type = 0; // INPUT_MOUSE
            inputs[1].U.mi.dwFlags = (uint)upEvent;

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
        }
    }
}
