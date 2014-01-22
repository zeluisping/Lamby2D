using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Core
{
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
        public float R
        {
            get { return _r; }
            set { _r = value; }
        }
        public float G
        {
            get { return _g; }
            set { _g = value; }
        }
        public float B
        {
            get { return _b; }
            set { _b = value; }
        }
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
        public Color(float rgb)
        {
            _r = rgb;
            _g = rgb;
            _b = rgb;
            _a = 1.0f;
        }
        public Color(float r, float g, float b)
        {
            _r = r;
            _g = g;
            _b = b;
            _a = 1.0f;
        }
        public Color(float rgb, float a)
        {
            _r = rgb;
            _g = rgb;
            _b = rgb;
            _a = a;
        }
        public Color(float r, float g, float b, float a)
        {
            _r = r;
            _g = g;
            _b = b;
            _a = a;
        }
    }
}
