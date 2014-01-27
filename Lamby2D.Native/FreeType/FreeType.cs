using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Native.FreeType
{
    public static class FreeType
    {
        // Public constants
        public const int FT_LOAD_DEFAULT = 0;

        // Private constants
        const string dll = "freetype252.dll";

        [DllImport(dll)]
        public static extern int FT_Init_FreeType(out IntPtr alibrary);
        [DllImport(dll)]
        public static extern int FT_New_Face(IntPtr library, string filepathname, int face_index, out IntPtr aface);
        [DllImport(dll)]
        public static extern int FT_Set_Pixel_Sizes(IntPtr face, uint pixel_width, uint pixel_height);
        [DllImport(dll)]
        public static extern int FT_Set_Char_Size(IntPtr face, int char_width, int char_height, uint horz_resolution, uint vert_resolution);
        [DllImport(dll)]
        public static extern int FT_Load_Char(IntPtr face, uint char_code, int load_flags);

    }
}
