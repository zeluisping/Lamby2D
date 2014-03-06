using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Native.FreeType
{
    public enum FT_Render_Mode : uint
    {
        Normal = 0,
        Light,
        Mono,
        LCD,
        LCD_V,
        FT_RENDER_MODE_MAX,
    }
}
