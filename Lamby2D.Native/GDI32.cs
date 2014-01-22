using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Native
{
    public static class GDI32
    {
        [DllImport("gdi32.dll", EntryPoint = "ChoosePixelFormat")]
        static extern int ChoosePixelFormat(IntPtr dc, [In] IntPtr pfd);
        public static int ChoosePixelFormat(IntPtr dc, PixelFormatDescriptor pfd)
        {
            int format = 0;
            GCHandle pointer = GCHandle.Alloc(pfd, GCHandleType.Pinned);
            try {
                format = ChoosePixelFormat(dc, pointer.AddrOfPinnedObject());
            } finally {
                pointer.Free();
            }
            return format;
        }
        [DllImport("gdi32.dll")]
        public static extern void SwapBuffers(IntPtr dc);
        [DllImport("gdi32.dll")]
        public static extern bool SetPixelFormat(IntPtr dc, int format, [In, MarshalAs(UnmanagedType.LPStruct)] PixelFormatDescriptor pfd);
    }
}
