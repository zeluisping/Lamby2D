using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public class PixelFormatDescriptor
    {
        public enum LAYER_TYPE : byte { MAIN_PLANE = 0, OVERLAY_PLANE = 1, UDERLAY_PLANE = 255 };
        public enum PIXEL_TYPE : byte { RGBA = 0, COLORINDEX = 1 };
        public enum FLAGS : uint
        {
            DOUBLEBUFFER = 0x00000001,
            STEREO = 0x00000002,
            DRAW_TO_WINDOW = 0x00000004,
            DRAW_TO_BITMAP = 0x00000008,
            SUPPORT_GDI = 0x00000010,
            SUPPORT_OPENGL = 0x00000020,
            GENERIC_FORMAT = 0x00000040,
            NEED_PALETTE = 0x00000080,
            NEED_SYSTEM_PALETTE = 0x00000100,
            SWAP_EXCHANGE = 0x00000200,
            SWAP_COPY = 0x00000400,
            SWAP_LAYER_BUFFERS = 0x00000800,
            GENERIC_ACCELERATED = 0x00001000,
            SUPPORT_DIRECTDRAW = 0x00002000,
            DEPTH_DONTCARE = 0x20000000,
            DOUBLEBUFFER_DONTCARE = 0x40000000,
            STEREO_DONTCARE = 0x80000000
        };

        public short Size = 40;
        public short Version = 1;
        public FLAGS Flags = FLAGS.DOUBLEBUFFER | FLAGS.DRAW_TO_WINDOW | FLAGS.SUPPORT_OPENGL;
        public PIXEL_TYPE PixelType;
        public byte ColorBits = 24;
        public byte RedBits;
        public byte RedShift;
        public byte GreenBits;
        public byte GreenShift;
        public byte BlueBits;
        public byte BlueShift;
        public byte AlphaBits = 8;
        public byte AlphaShift;
        public byte AccumBits;
        public byte AccumRedBits;
        public byte AccumGreenBits;
        public byte AccumBlueBits;
        public byte AccumAlphaBits;
        public byte DepthBits = 24;
        public byte StencilBits = 8;
        public byte AuxBuffers;
        public LAYER_TYPE LayerType;
        public byte Reserved;
        public int dwLayerMask;
        public int dwVisibleMask;
        public int dwDamageMask;
    }
}
