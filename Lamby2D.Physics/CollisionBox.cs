using Lamby2D.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Physics
{
    public class CollisionBox : CollisionPrimitive
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public float RotationRotation { get; set; }

        public CollisionBox()
        {
            this.Center = Vector2.Half;
        }
    }
}
