using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Core
{
    public struct Vector2
    {
        // Constants
        public static readonly Vector2 Zero = new Vector2(0);
        public static readonly Vector2 One = new Vector2(1);
        public static readonly Vector2 NaN = new Vector2(float.NaN);

        // Static operators
        public static bool operator ==(Vector2 a, Vector2 b)
        {
            return (a._x == b._x && a._y == b._y);
        }
        public static bool operator !=(Vector2 a, Vector2 b)
        {
            return (a._x != b._x || a._y != b._y);
        }
        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new Vector2(a._x * b._x, a._y * b._y);
        }
        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return new Vector2(a._x / b._x, a._y / b._y);
        }
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a._x + b._x, a._y + b._y);
        }
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a._x - b._x, a._y - b._y);
        }
        public static Vector2 operator *(Vector2 a, float b)
        {
            return new Vector2(a._x * b, a._y * b);
        }
        public static Vector2 operator /(Vector2 a, float b)
        {
            return new Vector2(a._x / b, a._y / b);
        }
        public static Vector2 operator *(float a, Vector2 b)
        {
            return new Vector2(a * b._x, a * b._y);
        }
        public static Vector2 operator /(float a, Vector2 b)
        {
            return new Vector2(a / b._x, a / b._y);
        }

        // Variables
        float _x;
        float _y;

        // Properties
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public float Length
        {
            get { return (float) Math.Sqrt(this.X * this.X + this.Y * this.Y); }
        }
        public Vector2 Normalized
        {
            get
            {
                float len = this.Length;
                if (len == 0) {
                    return default(Vector2);
                }
                return new Vector2(_x / len, _y / len);
            }
        }
        public Vector2 Inverted
        {
            get { return new Vector2(-_x, -_y); }
        }

        // Public
        public override bool Equals(object obj)
        {
            return (obj is Vector2 && (Vector2) obj == this);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return "(" + _x + ", " + _y + ")";
        }
        public void Normalize()
        {
            float len = this.Length;
            if (len != 0) {
                _x /= len;
                _y /= len;
            }
        }
        public void Invert()
        {
            _x = -_x;
            _y = -_y;
        }
        public float Distance(Vector2 vector)
        {
            float xx = _x - vector._x;
            float yy = _y - vector._y;
            return (float) Math.Sqrt(xx * xx + yy * yy);
        }
        public float Distance(float x, float y)
        {
            float xx = _x - x;
            float yy = _y - y;
            return (float) Math.Sqrt(xx * xx + yy * yy);
        }
        public bool IsNaN()
        {
            return (this.X != this.X || this.Y != this.Y);
        }

        // Constructors
        public Vector2(float xy)
        {
            _x = xy;
            _y = xy;
        }
        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }
    }
}
