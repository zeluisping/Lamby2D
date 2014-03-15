using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Drawing
{
    class FontGlyph
    {
        public Texture2D Texture { get; private set; }
        public uint Charcode { get; private set; }
        public int Left { get; private set; }
        public int Top { get; private set; }
        public int Advance { get; private set; }
        public int Width { get { return this.Texture.Width; } }
        public int Height { get { return this.Texture.Height; } }

        public FontGlyph(uint charcode, int left, int top, int advance, int width, int height, byte[] buffer)
        {
            this.Charcode = charcode;
            this.Left = left;
            this.Top = top;
            this.Advance = advance;
            this.Texture = Graphics.Current.CreateTexture((uint) width, (uint) height, TextureFormat.LuminanceAlpha, buffer);
        }
        ~FontGlyph()
        {
            this.Texture.Dispose();
        }
    }
}
