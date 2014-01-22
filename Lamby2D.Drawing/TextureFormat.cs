using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Drawing
{
    public enum TextureFormat : uint
    {
        ColourIndex = 0x1900,
        ColorIndex = 0x1900,
        Alpha = 0x1906,
        RGB = 0x1907,
        RGBA = 0x1908,
        BGR = 0x80E0,
        BGRA = 0x80E1,
        Luminance = 0x1909,
        LuminanceAlpha = 0x190A,
    }
}
