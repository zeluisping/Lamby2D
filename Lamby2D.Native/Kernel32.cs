using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Native
{
    public static class Kernel32
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string name);
    }
}
