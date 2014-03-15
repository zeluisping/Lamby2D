using Lamby2D.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Physics
{
    public class CollisionPrimitive
    {
        // Properties
        public Vector2 PositionOffset { get; set; }
        public Vector2 Center { get; set; }

        // Constructors
        public CollisionPrimitive()
        {
            this.Center = Vector2.Half;
        }
    }
}
