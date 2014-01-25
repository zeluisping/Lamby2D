using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Native
{
    public static class User32
    {
        public delegate IntPtr WndProc(IntPtr hWnd, WindowMessages msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern int RegisterClassExW([MarshalAs(UnmanagedType.Struct)] ref WNDCLASSEX pcWndClassEx);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr CreateWindowExW(WindowStylesEx dwExStyle, [MarshalAs(UnmanagedType.LPWStr)] string lpClassName, [MarshalAs(UnmanagedType.LPWStr)] string lpWindowName, WindowStyles dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);
        [DllImport("user32.dll")]
        public static extern sbyte GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);
        [DllImport("user32.dll")]
        public static extern bool TranslateMessage([In] ref MSG lpMsg);
        [DllImport("user32.dll")]
        public static extern IntPtr DispatchMessage([In] ref MSG lpMsg);
        [DllImport("user32.dll")]
        public static extern IntPtr DefWindowProcW(IntPtr hWnd, WindowMessages uMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern bool DestroyWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PeekMessage(out MSG lpMsg, HandleRef hWnd, uint wMsgFilterMin, uint wMsgFilterMax, RemoveMessage wRemoveMsg);
        [DllImport("user32.dll")]
        public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("user32.dll")]
        public static extern bool SetWindowText(IntPtr hWnd, string lpString);
        [DllImport("user32.dll")]
        public static extern bool AdjustWindowRect(ref RECT lpREct, WindowStyles dwStyle, bool bMenu);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);
        [DllImport("user32.dll")]
        public static extern int ShowCursor(bool bShow);
    }
}
