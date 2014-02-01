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
                CollisionCircle first = (CollisionCircle) a.Collider;
                CollisionCircle second = (CollisionCircle) b.Collider;

                return (a.Position.Distance(b.Position) < first.Radius + second.Radius);
            } else if (a.Collider is AABB && b.Collider is AABB) {
                AABB first = (AABB) a.Collider;
                AABB second = (AABB) b.Collider;

                Vector2 a_min = new Vector2(a.Position.X, a.Position.Y);
                Vector2 a_max = new Vector2(a.Position.X + first.Width, a.Position.Y + first.Height);
                Vector2 b_min = new Vector2(b.Position.X, b.Position.Y);
                Vector2 b_max = new Vector2(b.Position.X + second.Width, b.Position.Y + second.Height);

                //if (a_min.Y >= b_min.Y && a_min.Y <= bmax.Y))
                if (a_min.X >= b_min.X && a_min.X <= b_max.X && a_min.Y >= b_min.Y && a_min.Y <= b_max.Y) {
                    return true;
                }
            }

            throw new NotImplementedException("Missing intersects for pair (" + a.GetType().FullName + ", " + b.GetType().FullName + ").");
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
