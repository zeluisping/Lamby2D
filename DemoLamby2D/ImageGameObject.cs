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
    class ImageGameObject : GameObject, IDrawable, IMouseAware, ITickable, IPhysicsObject
    {
        // Properties
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Center { get; set; }
        public Vector2 Scale { get; set; }
        public float Rotation { get; set; }
        public int ZIndex { get; set; }
        public bool IsHitTestVisible { get; set; }
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
                                        ? this.Sprite.FrameHeight
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
                                        ? this.Sprite.FrameWidth
                                        : 0);
            }
        }
        public bool MoveWithInput { get; set; }

        // Events
        public event MouseButtonEventHandler MouseDown;
        public event MouseButtonEventHandler MouseUp;
        public event MouseMotionEventHandler MouseEnter;
        public event MouseMotionEventHandler MouseLeave;

        // Public
        public bool MouseHitTest(Point position)
        {
            Vector2 world = Game.Current.Graphics.ScreenToWorld(position);
            if (world.IsNaN() == true) {
                return false;
            }

            if (world.X >= this.Position.X - this.Center.X * this.Scale.X * this.Width &&
                    world.X <= this.Position.X - this.Center.X * this.Scale.X * this.Width + this.Width * this.Scale.X &&
                    world.Y >= this.Position.Y - this.Center.Y * this.Scale.Y * this.Height &&
                    world.Y <= this.Position.Y - this.Center.Y * this.Scale.Y * this.Height + this.Height * this.Scale.Y)
                return true;
            return false;
        }
        public void OnMouseDown(MouseButtonEventArgs e)
        {
            if (this.MouseDown != null) {
                this.MouseDown(this, e);
            }
        }
        public void OnMouseUp(MouseButtonEventArgs e)
        {
            if (this.MouseUp != null) {
                this.MouseUp(this, e);
            }
        }
        public void OnMouseEnter(MouseMotionEventArgs e)
        {
            this.Color = new Color(1.0f, 0.25f);
            if (this.MouseEnter != null) {
                this.MouseEnter(this, e);
            }
        }
        public void OnMouseLeave(MouseMotionEventArgs e)
        {
            this.Color = Colors.White;
            if (this.MouseLeave != null) {
                this.MouseLeave(this, e);
            }
        }
        public void Update(float DeltaTime)
        {
            if (this.MoveWithInput == false) {
                return;
            }

            float speed = 200.0f;

            if (Game.Current.Input.IsKeyDown(KeyCode.A) == true) {
                this.Position -= new Vector2(speed * DeltaTime * 0.5f, 0);
            }
            if (Game.Current.Input.IsKeyDown(KeyCode.D) == true) {
                this.Position += new Vector2(speed * DeltaTime * 0.5f, 0);
            }
            if (Game.Current.Input.IsKeyDown(KeyCode.W) == true) {
                this.Position -= new Vector2(0, speed * DeltaTime * 0.5f);
            }
            if (Game.Current.Input.IsKeyDown(KeyCode.S) == true) {
                this.Position += new Vector2(0, speed * DeltaTime * 0.5f);
            }
        }

        // Constructors
        public ImageGameObject()
        {
            this.IsHitTestVisible = true; // same as above
            this.Scale = Vector2.One;
            this.Collider = new CollisionCircle(256);
            this.Color = Colors.White;
            this.MoveWithInput = true;
        }
    }
}
