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
    class Cursor : GameObject, IDrawable, IStaticPhysicsObject, ITickable
    {
        // Static variables
        static readonly Texture2D CursorTexture = Game.Current.Graphics.CreateTexture("cursor.png");

        // Properties
        public Texture2D Texture { get; private set; }
        public Vector2 Position { get; set; }
        public Vector2 Center { get; set; }
        public Vector2 Scale { get; set; }
        public float Rotation { get; set; }
        public int ZIndex { get; set; }
        public CollisionPrimitive Collider { get; set; }
        public bool IsSolid { get; set; }
        public Color Color { get; set; }
        public DrawableKind DrawableKind { get; set; }
        public Sprite Sprite { get; set; }
        public float Width
        {
            get
            {
                return (this.DrawableKind == DrawableKind.Texture
                                ? this.Texture.Width
                                : this.DrawableKind == DrawableKind.Sprite
                                        ? this.Sprite.Texture.Width
                                        : 0);
            }
        }
        public float Height
        {
            get
            {
                return (this.DrawableKind == DrawableKind.Texture
                                ? this.Texture.Height
                                : this.DrawableKind == DrawableKind.Sprite
                                        ? this.Sprite.Texture.Height
                                        : 0);
            }
        }

        // Handlers
        private void Input_MouseMotion(object sender, MouseMotionEventArgs e)
        {
            this.Position = Game.Current.Graphics.ScreenToWorld(e.Position);
        }

        // Public
        public void Update(float DeltaTime)
        {
            this.Position = Game.Current.Graphics.ScreenToWorld(Game.Current.Input.MousePosition);
        }

        // Constructors
        public Cursor()
        {
            this.DrawableKind = DrawableKind.Texture;
            this.Texture = Cursor.CursorTexture;
            this.Scale = Vector2.One;
            this.ZIndex = 1;
            this.Collider = new CollisionCircle(16);
            this.Color = Colors.White;

            Game.Current.Input.MouseMotion += Input_MouseMotion;
        }
    }
}
