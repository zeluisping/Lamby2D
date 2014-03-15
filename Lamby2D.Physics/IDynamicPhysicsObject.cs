using Lamby2D.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Physics
{
    public interface IDynamicPhysicsObject : IPhysicsObject
    {
        /// <summary>
        /// Gets/sets the position of the object.
        /// </summary>
        Vector2 Position { get; set; }
    }
}
