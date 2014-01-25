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

namespace DemoLamby2D
{
    class DemoGame : Game
    {
        // Variables
        Texture2D texture;
        ImageGameObject imagegameobject;
        Cursor cursor;

        // Public
        public override void Update(float DeltaTime)
        {
        }
        public override void PostDraw()
        {
            // stuff drawn here is on top of everything else
            this.Graphics.Draw(cursor);
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

            cursor = new Cursor();

            texture = this.Graphics.CreateTexture("texture.png");
            imagegameobject = new ImageGameObject() {
                Center = new Vector2(0.5f),
                Position = new Vector2(+0.5f),
                Texture = texture,
                Rotation = 90,
            };
            imagegameobject.Clicked += delegate
            {
                imagegameobject.Position = new Vector2();
            };
        }
    }
}
