using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Native.FreeType
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FT_Face
    {
        public int num_faces;
        public int face_index;

        public int face_flags;
        public int style_flags;

        public int num_glyphs;

        public string family_name;
        public string style_name;

        public int num_fixed_sizes;
        public IntPtr available_sizes;

        public int num_charmaps;
        public IntPtr charmaps;

        public FT_Generic generic;

        /*# The following member variables (down to `underline_thickness') */
        /*# are only relevant to scalable outlines; cf. @FT_Bitmap_Size    */
        /*# for bitmap fonts.                                              */
        public FT_BBox bbox;

        public ushort units_per_EM;
        public short ascender;
        public short descender;
        public short height;

        public short max_advance_width;
        public short max_advance_height;

        public short underline_position;
        public short underline_thickness;

        public FT_GlyphSlot glyph;
        public IntPtr size;
        public IntPtr charmap;

        /*@private begin */

        public IntPtr driver;
        public IntPtr memory;
        public IntPtr stream;

        public FT_ListRec sizes_list;

        public FT_Generic autohint;   /* face-specific auto-hinter data */
        public IntPtr extensions; /* unused                         */

        public IntPtr _internal;
    }
}
