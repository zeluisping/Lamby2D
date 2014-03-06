using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Native.FreeType
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FT_GlyphSlot
    {
        public IntPtr library;
        public IntPtr face;
        public IntPtr next;
        public uint reserved;       /* retained for binary compatibility */
        public FT_Generic generic;

        public FT_Glyph_Metrics metrics;
        public int linearHoriAdvance;
        public int linearVertAdvance;
        public FT_Vector advance;

        public FT_Glyph_Format format;

        public FT_Bitmap bitmap;
        public int bitmap_left;
        public int bitmap_top;

        public FT_Outline outline;

        public uint num_subglyphs;
        public IntPtr subglyphs;

        public IntPtr control_data;
        public long control_len;

        public int lsb_delta;
        public int rsb_delta;

        public IntPtr other;

        public IntPtr _internal;
    }
}
