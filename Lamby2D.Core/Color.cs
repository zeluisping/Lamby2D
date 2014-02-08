using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Core
{
    /// <summary>
    /// A linear color (floating point component values in the range zero to one).
    /// </summary>
    public struct Color
    {
        // Static operators
        public static bool operator ==(Color a, Color b)
        {
            return (a._r == b._r && a._g == b._g && a._b == b._b && a._a == b._a);
        }
        public static bool operator !=(Color a, Color b)
        {
            return (a._r != b._r || a._g != b._g || a._b != b._b || a._a != b._a);
        }

        // Variables
        private float _r;
        private float _g;
        private float _b;
        private float _a;

        // Properties
        /// <summary>
        /// Get/set the red component of the color.
        /// </summary>
        public float R
        {
            get { return _r; }
            set { _r = value; }
        }
        /// <summary>
        /// Get/set the green component of the color.
        /// </summary>
        public float G
        {
            get { return _g; }
            set { _g = value; }
        }
        /// <summary>
        /// Get/set the blue component of the color.
        /// </summary>
        public float B
        {
            get { return _b; }
            set { _b = value; }
        }
        /// <summary>
        /// Get/set the alpha component of the color.
        /// </summary>
        public float A
        {
            get { return _a; }
            set { _a = value; }
        }

        // Public
        public override bool Equals(object obj)
        {
            return (obj is Color && (Color) obj == this);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return "(" + _r + ", " + _g + ", " + _b + ", " + _a + ")";
        }

        // Constructors
        /// <summary>
        /// Create an uniform opaque color.
        /// </summary>
        /// <param name="rgb">The Red, Green and Blue components.</param>
        public Color(float rgb)
        {
            _r = rgb;
            _g = rgb;
            _b = rgb;
            _a = 1.0f;
        }
        /// <summary>
        /// Create an opaque color.
        /// </summary>
        /// <param name="r">The Red component of the color.</param>
        /// <param name="g">The Green component of the color.</param>
        /// <param name="b">The Blue component of the color.</param>
        public Color(float r, float g, float b)
        {
            _r = r;
            _g = g;
            _b = b;
            _a = 1.0f;
        }
        /// <summary>
        /// Create a uniform color.
        /// </summary>
        /// <param name="rgb">The Red, Green and Blue components.</param>
        /// <param name="a">The Alpha component.</param>
        public Color(float rgb, float a)
        {
            _r = rgb;
            _g = rgb;
            _b = rgb;
            _a = a;
        }
        /// <summary>
        /// Create a color with the specified components.
        /// </summary>
        /// <param name="r">The Red component.</param>
        /// <param name="g">The Green component.</param>
        /// <param name="b">The Blue component.</param>
        /// <param name="a">The Alpha component.</param>
        public Color(float r, float g, float b, float a)
        {
            _r = r;
            _g = g;
            _b = b;
            _a = a;
        }
    }
}
