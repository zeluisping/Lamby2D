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
        public static bool Intersects(IPhysicsObject a, IPhysicsObject b)
        {
            if (a == null || a.Collider == null || b == null || b.Collider == null) {
                return false;
            }

            if (a.Collider is CollisionCircle && b.Collider is CollisionCircle) {
                return GamePhysics.IntersectsCircleCircle(a.Position, a.Collider as CollisionCircle, b.Position, b.Collider as CollisionCircle, a.IsSolid | b.IsSolid);
            }

            throw new NotImplementedException("Missing intersects for pair (" + a.GetType().FullName + ", " + b.GetType().FullName + ").");
        }

        // Static
        static bool IntersectsCircleCircle(Vector2 a_pos, CollisionCircle a, Vector2 b_pos, CollisionCircle b, bool anysolid)
        {
            if (anysolid == true) {
                return (a_pos.Distance(b_pos) < a.Radius + b.Radius);
            } else if (a.Radius > b.Radius) {
                float distance = a_pos.Distance(b_pos);
                return (distance < a.Radius + b.Radius && distance + b.Radius < a.Radius);
            } else {
                float distance = a_pos.Distance(b_pos);
                return (distance < a.Radius + b.Radius && distance + a.Radius < b.Radius);
            }
        }

        // Variables
        List<IPhysicsObject> _physicsobjects;

        // Properties
        internal List<IPhysicsObject> PhysicsObjects
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
            _physicsobjects = new List<IPhysicsObject>();
        }
    }
}
