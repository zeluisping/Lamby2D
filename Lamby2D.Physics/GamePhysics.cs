using Lamby2D.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Physics
{
    public class GamePhysics
    {
        // Public static
        public static bool Intersects(IStaticPhysicsObject a, IStaticPhysicsObject b)
        {
            if (a == null || a.Collider == null || b == null || b.Collider == null) {
                return false;
            }

            if (a.Collider is CollisionCircle && b.Collider is CollisionCircle) {
                CollisionCircle first = (CollisionCircle) a.Collider;
                CollisionCircle second = (CollisionCircle) b.Collider;

                return (a.Position.Distance(b.Position) < first.Radius + second.Radius);
            }

            throw new NotImplementedException("Missing intersects for pair (" + a.GetType().FullName + ", " + b.GetType().FullName + ").");
        }

        // Variables
        List<IStaticPhysicsObject> _physicsobjects;

        // Properties
        internal List<IStaticPhysicsObject> PhysicsObjects
        {
            get { return _physicsobjects; }
        }

        // Public
        public void Update(float DeltaTime)
        {
        }

        // Constructors
        internal GamePhysics()
        {
            _physicsobjects = new List<IStaticPhysicsObject>();
        }
    }
}
