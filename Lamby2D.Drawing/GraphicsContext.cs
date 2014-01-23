using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Lamby2D.Native;
using Lamby2D.OpenGL;

namespace Lamby2D.Drawing
{
    public class GraphicsContext : IDisposable
    {
        // Variables
        Window _window;
        IntPtr _dc;
        IntPtr _rc;
        PixelFormatDescriptor _pfd;
        bool _windowclosed;

        // Properties
        public int Width
        {
            get { return _window.Width; }
        }
        public int Height
        {
            get { return _window.Height; }
        }
        public string Title
        {
            get { return _window.Title; }
            set { _window.Title = value; }
        }
        internal Window Window
        {
            get { return (_windowclosed ? null : _window); }
        }
        internal IntPtr DrawingContext
        {
            get { return _dc; }
        }

        // Public
        public void Dispose()
        {
            if (_rc != IntPtr.Zero) {
                OpenGL11.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
                OpenGL11.wglDeleteContext(_rc);
                User32.ReleaseDC(_window.Handle, _dc);

                _rc = IntPtr.Zero;
                _dc = IntPtr.Zero;
                _window.Dispose();
                _window = null;
            }
        }
        public void Resize(int width, int height)
        {
            if (_window.Width == width && _window.Height == height) {
                return;
            }

            _window.Width = width;
            _window.Height = height;

            // TODO opengl resize routine
            OpenGL11.glViewport(0, 0, width, height);
        }

        // Constructors
        public GraphicsContext()
        {
            OpenGL11.LoadLibrary();

            _windowclosed = false;
            _window = new Window() {
                //Width = 800,
                //Height = 600,
            };
            _window.Closed += delegate { _windowclosed = true; };
            _dc = User32.GetDC(_window.Handle);
            _pfd = new PixelFormatDescriptor();
            _pfd.Flags = PixelFormatDescriptor.FLAGS.DOUBLEBUFFER |
                         PixelFormatDescriptor.FLAGS.SUPPORT_OPENGL |
                         PixelFormatDescriptor.FLAGS.DRAW_TO_WINDOW;
            _pfd.PixelType = PixelFormatDescriptor.PIXEL_TYPE.RGBA;
            _pfd.ColorBits = 32;
            _pfd.DepthBits = 0;
            _pfd.StencilBits = 0;

            int pixel = GDI32.ChoosePixelFormat(_dc, _pfd);
            GDI32.SetPixelFormat(_dc, pixel, _pfd);
            OpenGL11.wglDescribePixelFormat(_dc, pixel, (uint) _pfd.Size, _pfd);
            _rc = OpenGL11.wglCreateContext(_dc);
            if (_rc == IntPtr.Zero) {
                throw new Exception("Failed to create rendering context.");
            }
            OpenGL11.wglMakeCurrent(_dc, _rc);
        }
    }
}
