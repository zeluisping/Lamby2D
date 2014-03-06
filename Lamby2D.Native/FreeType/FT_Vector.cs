using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Native.FreeType
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FT_Vector
    {
        public int x;
        public int y;
    }
}
