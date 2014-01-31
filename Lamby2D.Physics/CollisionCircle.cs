using Lamby2D.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Physics
{
    public class CollisionCircle : CollisionPrimitive
    {
        // Variables
        float _radius;
        float _diameter;

        // Properties
        public float Radius
        {
            get { return _radius; }
            set
            {
                _radius = value;
                _diameter = value * 2;
            }
        }
        public float Diameter
        {
            get { return _diameter; }
            set
            {
                _diameter = value;
                _radius = _diameter / 2.0f;
            }
        }

        // Constructors
        public CollisionCircle()
        {
            this.Radius = 1.0f;
        }
        public CollisionCircle(float radius)
        {
            this.Radius = radius;
        }
    }
}
