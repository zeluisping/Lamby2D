using Lamby2D.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Physics
{
    public class AABB : CollisionPrimitive
    {
        // Variables
        float _width;
        float _height;

        // Properties
        public float Width
        {
            get { return _width; }
            set
            {
                if (value < 0) {
                    throw new ArgumentOutOfRangeException("Width");
                }
                _width = value;
            }
        }
        public float Height
        {
            get { return _height; }
            set
            {
                if (value < 0) {
                    throw new ArgumentOutOfRangeException("Height");
                }
                _height = value;
            }
        }

        // Constructors
        public AABB()
        {
            this.Width = 1.0f;
            this.Height = 1.0f;
        }
        public AABB(float uniform)
        {
            this.Width = uniform;
            this.Height = uniform;
        }
        public AABB(float width, float height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
