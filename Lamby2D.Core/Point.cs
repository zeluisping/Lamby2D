using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Core
{
    /// <summary>
    /// Integral two dimensional vector (point).
    /// </summary>
    public struct Point
    {
        // Constants
        /// <summary>
        /// Constant of (0,0).
        /// </summary>
        public static readonly Point Zero = new Point(0);
        /// <summary>
        /// Constant of (1,1).
        /// </summary>
        public static readonly Point One = new Point(1);

        // Static operators
        public static bool operator ==(Point a, Point b)
        {
            return (a._x == b._x && a._y == b._y);
        }
        public static bool operator !=(Point a, Point b)
        {
            return (a._x != b._x || a._y != b._y);
        }
        public static Point operator *(Point a, Point b)
        {
            return new Point(a._x * b._x, a._y * b._y);
        }
        public static Point operator /(Point a, Point b)
        {
            return new Point(a._x / b._x, a._y / b._y);
        }
        public static Point operator +(Point a, Point b)
        {
            return new Point(a._x + b._x, a._y + b._y);
        }
        public static Point operator -(Point a, Point b)
        {
            return new Point(a._x - b._x, a._y - b._y);
        }
        public static Point operator *(Point a, float b)
        {
            return new Point((int) (a._x * b), (int) (a._y * b));
        }
        public static Point operator /(Point a, float b)
        {
            return new Point((int) (a._x / b), (int) (a._y / b));
        }
        public static Point operator *(float a, Point b)
        {
            return new Point((int) (a * b._x), (int) (a * b._y));
        }
        public static Point operator /(float a, Point b)
        {
            return new Point((int) (a / b._x), (int) (a / b._y));
        }

        // Variables
        private int _x;
        private int _y;

        // Properties
        /// <summary>
        /// Get/set the X component of the point.
        /// </summary>
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        /// <summary>
        /// Get/set the Y component of the point.
        /// </summary>
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        /// <summary>
        /// Get the calculated length of the point.
        /// </summary>
        public float Length
        {
            get { return (float) Math.Sqrt(this.X * this.X + this.Y * this.Y); }
        }
        /// <summary>
        /// Get an inverted version of the point.
        /// </summary>
        public Point Inverted
        {
            get { return new Point(-_x, -_y); }
        }

        // Public
        /// <summary>
        /// Determines whether the specified object is equal to the point.
        /// </summary>
        /// <param name="obj">The object to check equality with.</param>
        /// <returns>True if the two objects are equal, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            return (obj is Point && (Point) obj == this);
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
        /// Inverts the components of the point.
        /// </summary>
        public void Invert()
        {
            _x = -_x;
            _y = -_y;
        }
        /// <summary>
        /// Calculates and returns the distance to another point.
        /// </summary>
        /// <param name="point">The point with which to calculate the distance.</param>
        /// <returns>The distance to the supplied point.</returns>
        public float Distance(Point point)
        {
            float xx = _x - point._x;
            float yy = _y - point._y;
            return (float) Math.Sqrt(xx * xx + yy * yy);
        }
        /// <summary>
        /// Calculates and returns the distance to another point.
        /// </summary>
        /// <param name="x">The X component of the point to which the distance is to be calculated.</param>
        /// <param name="y">The Y component of the point to which the distance is to be calculated.</param>
        /// <returns>The distance to the point defined by the supplied components.</returns>
        public float Distance(int x, int y)
        {
            int xx = _x - x;
            int yy = _y - y;
            return (float) Math.Sqrt(xx * xx + yy * yy);
        }

        // Constructors
        /// <summary>
        /// Create a uniform two dimensional point.
        /// </summary>
        /// <param name="xy">The value for the X and Y components.</param>
        public Point(int xy)
        {
            _x = xy;
            _y = xy;
        }
        /// <summary>
        /// Create a two dimensional point.
        /// </summary>
        /// <param name="x">The value for the X component.</param>
        /// <param name="y">The value for the Y component.</param>
        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}
