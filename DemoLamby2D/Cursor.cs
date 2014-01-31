using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lamby2D;
using Lamby2D.Core;
using Lamby2D.Drawing;
using Lamby2D.Input;
using Lamby2D.Physics;

namespace DemoLamby2D
{
    class Cursor : GameObject, IStaticDrawable, IPhysicsObject
    {
        // Static variables
        static readonly Texture2D CursorTexture = Game.Current.Graphics.CreateTexture("cursor.png");

        // Variables
        int _zindex;

        // Properties
        public Texture2D Texture { get; private set; }
        public Vector2 Position { get; set; }
        public Vector2 Center { get; set; }
        public Vector2 Scale { get; set; }
        public float Rotation { get; set; }
        public bool IsVisible { get; set; }
        public int ZIndex
        {
            get { return _zindex; }
            set
            {
                if (_zindex != value) {
                    int old = _zindex;
                    _zindex = value;
                    if (this.ZIndexChanged != null) {
                        this.ZIndexChanged(this, new ZIndexChangedEventArgs(old, value));
                    }
                }
            }
        }
        public CollisionPrimitive Collider { get; set; }
        public bool IsSolid { get; set; }

        // Events
        public event ZIndexChangedEventHandler ZIndexChanged;

        // Handlers
        private void Input_MouseMotion(object sender, MouseMotionEventArgs e)
        {
            this.Position = Game.Current.Graphics.ScreenToWorld(e.Position);
        }

        // Public
        public bool Intersects(IPhysicsObject other)
        {
            return GamePhysics.Intersects(this, other);
        }
        public bool Encompasses(IPhysicsObject other)
        {
            return false;
        }

        // Constructors
        public Cursor()
        {
            this.IsVisible = false; // intentional, only drawn in PostDraw
            this.Texture = Cursor.CursorTexture;
            this.Scale = Vector2.One;
            this.ZIndex = 1;

            Game.Current.Input.MouseMotion += Input_MouseMotion;
        }
    }
}
