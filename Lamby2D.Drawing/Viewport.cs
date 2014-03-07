using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Drawing
{
    public struct Viewport
    {
        // Static operators
        public static bool operator ==(Viewport a, Viewport b)
        {
            return (a.X == b.X && a.Y == b.Y && a.Width == b.Width && a.Height == b.Height);
        }
        public static bool operator !=(Viewport a, Viewport b)
        {
            return (a.X != b.X || a.Y != b.Y || a.Width != b.Width || a.Height != b.Height);
        }

        // Properties
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        // Constructors
        public Viewport(int x, int y, int width, int height)
            : this()
        {
            if (width < 0) {
                throw new ArgumentOutOfRangeException("width");
            }
            if (height < 0) {
                throw new ArgumentOutOfRangeException("height");
            }

            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }
    }
}
