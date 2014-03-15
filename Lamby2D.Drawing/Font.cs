using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Drawing
{
    public class Font
    {
        #region native
        const string dll = "Lamby2D.FreeType.Native.dll";
        static bool initialized = false;

        [StructLayout(LayoutKind.Sequential)]
        internal struct glyphdata
        {
            public uint charcode;
            public int left;
            public int top;
            public int advance;
            public int width;
            public int height;
            public byte[] buffer;
        }

        [DllImport(dll)]
        internal static extern int font_init();
        [DllImport(dll)]
        internal static extern IntPtr font_fromfile(string file);
        [DllImport(dll)]
        internal static extern IntPtr font_frommemory(byte[] data);
        [DllImport(dll)]
        internal static extern int font_set_char_size(IntPtr font, int width, int height, uint hres, uint vres);
        [DllImport(dll)]
        internal static extern int font_set_pixel_sizes(IntPtr font, uint width, uint height);
        [DllImport(dll)]
        internal static extern glyphdata font_load_glyph(IntPtr font, uint charcode);
        [DllImport(dll)]
        internal static extern int font_delete(IntPtr font);
        #endregion

        // Variables
        List<FontGlyph> glyphs;
        IntPtr font;

        // Internal
        internal FontGlyph LoadGlyph(uint charcode)
        {
            FontGlyph glyph = glyphs.Find(x => x.Charcode == charcode);
            if (glyph != null) {
                return glyph;
            }

            glyphdata g = font_load_glyph(font, charcode);

            glyph = new FontGlyph(charcode, g.left, g.top, g.advance, g.width, g.height, g.buffer);
            glyphs.Add(glyph);

            return glyph;
        }

        // Constructors
        public Font(string file)
        {
            if (Font.initialized == false) {
                if (font_init() != 0) {
                    throw new Exception("FreeType initialization failed.");
                }
            }

            font = font_fromfile(file);
            font_set_pixel_sizes(font, 20, 20);
            this.glyphs = new List<FontGlyph>();
        }
        ~Font()
        {
            font_delete(font);
        }
    }
}
