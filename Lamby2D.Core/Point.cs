using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Core
{
    public struct Point
    {
        // Constants
        public static readonly Point Zero = new Point(0, 0);
        public static readonly Point One = new Point(1, 1);

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
        int _x;
        int _y;

        // Properties
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public float Length
        {
            get { return (float) Math.Sqrt(this.X * this.X + this.Y * this.Y); }
        }
        public Point Inverted
        {
            get { return new Point(-_x, -_y); }
        }

        // Public
        public override bool Equals(object obj)
        {
            return (obj is Point && (Point) obj == this);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return "(" + _x + ", " + _y + ")";
        }
        public void Invert()
        {
            _x = -_x;
            _y = -_y;
        }
        public float Distance(Point vector)
        {
            float xx = _x - vector._x;
            float yy = _y - vector._y;
            return (float) Math.Sqrt(xx * xx + yy * yy);
        }
        public float Distance(int x, int y)
        {
            int xx = _x - x;
            int yy = _y - y;
            return (float) Math.Sqrt(xx * xx + yy * yy);
        }

        // Constructors
        public Point(int xy)
        {
            _x = xy;
            _y = xy;
        }
        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public Point(Point p)
        {
            _x = p._x;
            _y = p._y;
        }
    }
}
