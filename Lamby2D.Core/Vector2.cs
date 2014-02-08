using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Core
{
    /// <summary>
    /// Two dimensional vector.
    /// </summary>
    public struct Vector2
    {
        // Constants
        /// <summary>
        /// Constant of (0,0).
        /// </summary>
        public static readonly Vector2 Zero = new Vector2(0);
        /// <summary>
        /// Constant of (1,1).
        /// </summary>
        public static readonly Vector2 One = new Vector2(1);
        /// <summary>
        /// Constant of (NaN,NaN).
        /// </summary>
        public static readonly Vector2 NaN = new Vector2(float.NaN);
        /// <summary>
        /// Constant of (0.5,0.5).
        /// </summary>
        public static readonly Vector2 Half = new Vector2(0.5f);

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
        private float _x;
        private float _y;

        // Properties
        /// <summary>
        /// Get/set the X component of the vector.
        /// </summary>
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }
        /// <summary>
        /// Get/set the Y component of the vector.
        /// </summary>
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
        /// <summary>
        /// Get the calculated vector length.
        /// </summary>
        public float Length
        {
            get { return (float) Math.Sqrt(this.X * this.X + this.Y * this.Y); }
        }
        /// <summary>
        /// Get a normalized version of this vector.
        /// </summary>
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
        /// <summary>
        /// Get an inverted version of this vector.
        /// </summary>
        public Vector2 Inverted
        {
            get { return new Vector2(-_x, -_y); }
        }
        /// <summary>
        /// Get a floored version of this vector.
        /// </summary>
        public Vector2 Floored
        {
            get { return new Vector2((float) Math.Floor(_x), (float) Math.Floor(_y)); }
        }
        /// <summary>
        /// Gets a celiled version of this vector.
        /// </summary>
        public Vector2 Ceiled
        {
            get { return new Vector2((float) Math.Ceiling(_x), (float) Math.Ceiling(_y)); }
        }

        // Public
        /// <summary>
        /// Determines whether the specified object is equal to the vector.
        /// </summary>
        /// <param name="obj">The object to check equality with.</param>
        /// <returns>True if the two objects are equal, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            return (obj is Vector2 && (Vector2) obj == this);
        }
        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>The hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// Returns a string that represents the current vector.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "(" + _x + ", " + _y + ")";
        }
        /// <summary>
        /// Normalizes the vector.
        /// </summary>
        public void Normalize()
        {
            float len = this.Length;
            if (len != 0) {
                _x /= len;
                _y /= len;
            }
        }
        /// <summary>
        /// Invert the components of the vector.
        /// </summary>
        public void Invert()
        {
            _x = -_x;
            _y = -_y;
        }
        /// <summary>
        /// Calculates and returns the distance to another vector.
        /// </summary>
        /// <param name="vector">The vector with which to calculate the distance.</param>
        /// <returns>The distance to the supplied vector.</returns>
        public float Distance(Vector2 vector)
        {
            float xx = _x - vector._x;
            float yy = _y - vector._y;
            return (float) Math.Sqrt(xx * xx + yy * yy);
        }
        /// <summary>
        /// Calculates and returns the distance to another vector.
        /// </summary>
        /// <param name="x">The X component of the point to which the distance is to be calculated.</param>
        /// <param name="y">The Y component of the point to which the distance is to be calculated.</param>
        /// <returns>The distance to the vector defined by the supplied components.</returns>
        public float Distance(float x, float y)
        {
            float xx = _x - x;
            float yy = _y - y;
            return (float) Math.Sqrt(xx * xx + yy * yy);
        }
        /// <summary>
        /// Check if any of the vector components is NaN.
        /// </summary>
        /// <returns>True if any of the vector components are NaN, otherwise false.</returns>
        public bool IsNaN()
        {
            return (float.IsNaN(this.X) == true || float.IsNaN(this.Y) == true);
        }
        /// <summary>
        /// Floors the vector components.
        /// </summary>
        public void Floor()
        {
            _x = (float) Math.Floor(_x);
            _y = (float) Math.Floor(_y);
        }
        /// <summary>
        /// Ceils the vector components.
        /// </summary>
        public void Ceiling()
        {
            _x = (float) Math.Ceiling(_x);
            _y = (float) Math.Ceiling(_y);
        }

        // Constructors
        /// <summary>
        /// Create a uniform two dimensional vector.
        /// </summary>
        /// <param name="xy">The value for the X and Y components.</param>
        public Vector2(float xy)
        {
            _x = xy;
            _y = xy;
        }
        /// <summary>
        /// Create a two dimensional vector.
        /// </summary>
        /// <param name="x">The value for the X component.</param>
        /// <param name="y">The value for the Y component.</param>
        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }
    }
}
