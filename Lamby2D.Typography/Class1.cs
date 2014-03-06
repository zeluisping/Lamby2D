using Lamby2D.Native.FreeType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Typography
{
    class Class1
    {
        static bool Initialize()
        {
            IntPtr library;
            FT_Face face;
            int error;

            error = FreeType.FT_Init_FreeType(out library);
            if (error != 0) {
                return false;
            }

            error = FreeType.FT_New_Face(library, "myfont.ttf", 0, out face);
            if (error != 0) {
                return false;
            }

            // error: FT_Err_Unknown_File_Format

            error = FreeType.FT_Set_Pixel_Sizes(face, 0, 16);
            if (error != 0) {
                return false;
            }

            return true;
        }
    }
}
