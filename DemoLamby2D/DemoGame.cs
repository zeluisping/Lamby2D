using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lamby2D;
using Lamby2D.Core;
using Lamby2D.Drawing;
using Lamby2D.Input;
using Lamby2D.Physics;

namespace DemoLamby2D
{
    class DemoGame : Game
    {
        // Variables
        Texture2D texture;
        ImageGameObject imagegameobject;
        Cursor cursor;

        // Handlers
        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyCode.Escape) {
                Quit();
            }
        }

        // Public
        public override void Update(float DeltaTime)
        {
        }
        public override void PostUpdate(float DeltaTime)
        {
            this.Graphics.GraphicsContext.Title = (GamePhysics.Intersects(cursor, imagegameobject) ? "Intersects" : "Demo Game");
        }
        public override void PostDraw()
        {
            // stuff drawn here is on top of everything else
            this.Graphics.Draw(cursor);

            this.Graphics.PolygonMode = PolygonMode.Line;
            this.Graphics.DrawCircle(cursor.Position, ((CollisionCircle) cursor.Collider).Radius);
            this.Graphics.DrawCircle(imagegameobject.Position, ((CollisionCircle) imagegameobject.Collider).Radius);
            this.Graphics.PolygonMode = PolygonMode.Fill;
        }

        // Protected
        protected override void Cleanup()
        {
            texture.Dispose();
            cursor.Texture.Dispose();
        }

        // Constructors
        public DemoGame()
        {
            this.Graphics.BackgroundColor = Colors.Orange;
            this.Graphics.GraphicsContext.Resize(640, 360);
            this.Graphics.GraphicsContext.Title = "Demo Game";
            this.Graphics.GraphicsContext.ShowCursor = false;
            this.Input.KeyDown += Input_KeyDown;

            cursor = new Cursor();

            texture = this.Graphics.CreateTexture("texture.png");
            imagegameobject = new ImageGameObject() {
                Center = new Vector2(0.5f),
                Position = new Vector2(+0.5f),
                Texture = texture,
                Rotation = 90,
            };
            imagegameobject.MouseDown += delegate {
                imagegameobject.Position = new Vector2();
            };
            /*imagegameobject.Clicked += delegate {
                imagegameobject.Position = new Vector2();
            };*/
        }
    }
}
