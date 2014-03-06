using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Native.FreeType
{
    public enum FT_Glyph_Format : uint
    {
        None = ((uint) 0 << 24) | ((uint) 0 << 16) | ((uint) 0 << 8) | (uint) 0,
        Composite = ((uint) 'c' << 24) | ((uint) 'o' << 16) | ((uint) 'm' << 8) | (uint) 'p',
        Bitmap = ((uint) 'b' << 24) | ((uint) 'i' << 16) | ((uint) 't' << 8) | (uint) 's',
        Outline = ((uint) 'o' << 24) | ((uint) 'u' << 16) | ((uint) 't' << 8) | (uint) 'l',
        Plotter = ((uint) 'p' << 24) | ((uint) 'l' << 16) | ((uint) 'o' << 8) | (uint) 't',
    }
}
