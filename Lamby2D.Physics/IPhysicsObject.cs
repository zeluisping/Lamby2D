using Lamby2D.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Physics
{
    public interface IPhysicsObject
    {
        /// <summary>
        /// Gets the collision primitive of the object.
        /// </summary>
        CollisionPrimitive Collider { get; }
        /// <summary>
        /// Gets the center of the object.
        /// </summary>
        Vector2 Center { get; }
        /// <summary>
        /// Gets the scale of the object.
        /// </summary>
        Vector2 Scale { get; }
        /// <summary>
        /// Gets the rotation of the object.
        /// </summary>
        float Rotation { get; }
    }
}
