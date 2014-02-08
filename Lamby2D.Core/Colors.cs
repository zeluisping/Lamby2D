using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Core
{
    /// <summary>
    /// A collection of constant colors.
    /// </summary>
    public static class Colors
    {
        /// <summary>
        /// The color black (0, 0, 0, 1).
        /// </summary>
        public static readonly Color Black = new Color(0, 0, 0);
        /// <summary>
        /// The color white (1, 1, 1, 1).
        /// </summary>
        public static readonly Color White = new Color(1, 1, 1);

        /// <summary>
        /// The color red (1, 0, 0, 1).
        /// </summary>
        public static readonly Color Red = new Color(1, 0, 0);
        /// <summary>
        /// The color green (0, 1, 0, 1).
        /// </summary>
        public static readonly Color Green = new Color(0, 1, 0);
        /// <summary>
        /// The color blue (0, 0, 1, 1).
        /// </summary>
        public static readonly Color Blue = new Color(0, 0, 1);

        /// <summary>
        /// The transparent color (0, 0, 0, 0).
        /// </summary>
        public static readonly Color Transparent = new Color(0, 0, 0, 0);

        /// <summary>
        /// The color magenta (1, 0, 1, 1).
        /// </summary>
        public static readonly Color Magenta = new Color(1, 0, 1);
        /// <summary>
        /// The color purple (0.5, 0, 0.5, 1).
        /// </summary>
        public static readonly Color Purple = new Color(0.5f, 0, 0.5f);
        /// <summary>
        /// The orange color (1, 11/17, 0, 1).
        /// </summary>
        public static readonly Color Orange = new Color(1, 165 / (float) 255, 0);

        /// <summary>
        /// The corn flower blue color (0.4, 0.6, 0.9, 1).
        /// </summary>
        public static readonly Color CornFlowerBlue = new Color(0.4f, 0.6f, 0.9f);
    }
}
