using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Core
{
    public static class Colors
    {
        public static readonly Color Black = new Color(0, 0, 0);
        public static readonly Color White = new Color(1, 1, 1);

        public static readonly Color Red = new Color(1, 0, 0);
        public static readonly Color Green = new Color(0, 1, 0);
        public static readonly Color Blue = new Color(0, 0, 1);

        public static readonly Color Transparent = new Color(0, 0, 0, 0);

        public static readonly Color Magenta = new Color(1, 0, 1);
        public static readonly Color Purple = new Color(0.5f, 0, 0.5f);
        public static readonly Color Orange = new Color(1, 165 / (float) 255, 0);

        public static readonly Color CornFlowerBlue = new Color(0.4f, 0.6f, 0.9f);
    }
}
