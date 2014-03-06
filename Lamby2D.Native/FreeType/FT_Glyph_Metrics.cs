using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Native.FreeType
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FT_Glyph_Metrics
    {
        public int width;
        public int height;

        public int horiBearingX;
        public int horiBearingY;
        public int horiAdvance;

        public int vertBearingX;
        public int vertBearingY;
        public int vertAdvance;
    }
}
