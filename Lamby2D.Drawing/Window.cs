using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Lamby2D.Input;
using Lamby2D.Native;

namespace Lamby2D.Drawing
{
    public class Window : IDisposable
    {
        // Static
        IntPtr WndProc(IntPtr hWnd, WindowMessages uMsg, IntPtr wParam, IntPtr lParam)
        {
            if (uMsg == WindowMessages.CLOSE) {
                if (this.Closing != null) {
                    this.Closing(this, EventArgs.Empty);
                }
                
                User32.DestroyWindow(this.Handle);
            } else if (uMsg == WindowMessages.DESTROY) {
                if (this.Closed != null) {
                    this.Closed(this, EventArgs.Empty);
                }
            } else if (uMsg == WindowMessages.KEYDOWN && this.KeyDown != null) {
                this.KeyDown(this, new KeyEventArgs((Key) wParam));
            } else if (uMsg == WindowMessages.KEYUP && this.KeyUp != null) {
                this.KeyUp(this, new KeyEventArgs((Key) wParam));
            }

            return User32.DefWindowProcW(hWnd, uMsg, wParam, lParam);
        }

        // Variables
        User32.WndProc _wndprocdelegate;
        int _width;
        int _height;
        string _title;

        // Properties
        public IntPtr Handle { get; private set; }
        public int Width
        {
            get { return _width; }
        }
        public int Height
        {
            get { return _height; }
        }
        public string Title
        {
            get { return _title; }
            set
            {
                if (this.Handle == IntPtr.Zero) {
                    throw new ObjectDisposedException("Lamby2D.Drawing.Window instance.");
                }

                if (_title != value) {
                    _title = value;
                    User32.SetWindowText(this.Handle, value);
                }
            }
        }

        // Events
        public event EventHandler Closing;
        public event EventHandler Closed;
        public event KeyEventHandler KeyDown;
        public event KeyEventHandler KeyUp;

        // Public
        public void Show()
        {
            User32.ShowWindow(this.Handle, ShowWindowCommands.Show);
        }
        public void Hide()
        {
            User32.ShowWindow(this.Handle, ShowWindowCommands.Hide);
        }
        public void PollMessages()
        {
            MSG msg;
            while (User32.PeekMessage(out msg, new HandleRef(this, this.Handle), 0, 0, RemoveMessage.PM_REMOVE) == true) {
                User32.TranslateMessage(ref msg);
                User32.DispatchMessage(ref msg);
            }
        }
        public void Dispose()
        {
            if (this.Handle != IntPtr.Zero) {
                User32.DestroyWindow(this.Handle);
                this.Handle = IntPtr.Zero;
            }
        }

        // Constructors
        public Window()
        {
            _width = 800;
            _height = 600;
            _title = "Window";

            _wndprocdelegate = WndProc;

            WNDCLASSEX wc = new WNDCLASSEX() {
                cbSize = (uint) Marshal.SizeOf(typeof(WNDCLASSEX)),
                style = 0x0002 | 0x0001,
                lpfnWndProc = Marshal.GetFunctionPointerForDelegate(_wndprocdelegate),
                cbClsExtra = 0,
                cbWndExtra = 0,
                hInstance = Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]),
                lpszMenuName = null,
                lpszClassName = typeof(Window).FullName,
            };

            if (User32.RegisterClassExW(ref wc) == 0) {
                throw new Exception("Window registration failed.");
            }

            int CW_USEDEFAULT = 0;
            unchecked { CW_USEDEFAULT = (int) 0x80000000; }

            this.Handle = User32.CreateWindowExW(
                0,
                typeof(Window).FullName,
                this.Title,
                WindowStyles.WS_OVERLAPPED | WindowStyles.WS_CAPTION | WindowStyles.WS_SYSMENU | WindowStyles.WS_MINIMIZEBOX | WindowStyles.WS_MAXIMIZEBOX,
                CW_USEDEFAULT,
                CW_USEDEFAULT,
                this.Width,
                this.Height,
                IntPtr.Zero,
                IntPtr.Zero,
                Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]),
                IntPtr.Zero
            );

            if (this.Handle == IntPtr.Zero) {
                throw new Exception("Window creation failed.");
            }
        }
    }
}
