using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lamby2D;
using Lamby2D.Core;
using Lamby2D.Drawing;
using Lamby2D.Input;

namespace DemoLamby2D
{
    class ImageGameObject : GameObject, IStaticDrawable, IClickable, ITickable
    {
        // Properties
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Center { get; set; }
        public float Rotation { get; set; }
        public bool IsVisible { get; set; }
        public int ZIndex { get; set; }
        public bool IsHitTestVisible { get; set; }

        // Events
        public event MouseButtonEventHandler Clicked;

        // Public
        public virtual void OnClick(MouseButton button, Point position)
        {
            if (this.Clicked != null) {
                this.Clicked(this, new MouseButtonEventArgs(button, position));
            }
        }
        public bool ClickHitTest(Point position, MouseButton button)
        {            
            Vector2 world = Game.Current.Graphics.ScreenToWorld(position);
            if (world == Vector2.NaN) {
                return false;
            }

            // default object size is (Width = 1, Height = 1)
            return (world.X >= this.Position.X - this.Center.X &&
                    world.X <= this.Position.X + 1 - this.Center.X &&
                    world.Y >= this.Position.Y - this.Center.Y &&
                    world.Y <= this.Position.Y + 1 - this.Center.Y);
        }
        public void Update(float DeltaTime)
        {
            float speed = 1.0f;

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
            this.IsVisible = true; // change default value to true
            this.IsHitTestVisible = true; // same as above
        }
    }
}
