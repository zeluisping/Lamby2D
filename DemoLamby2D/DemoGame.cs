using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lamby2D;
using Lamby2D.Core;
using Lamby2D.Drawing;

namespace DemoLamby2D
{
    class DemoGame : Game
    {
        // Variables
        Texture2D texture;
        Image image;

        // Public
        public override void Update(float DeltaTime)
        {
            this.Graphics.GraphicsContext.Window.Title = DeltaTime.ToString();
            image.Rotation += DeltaTime * 10;
        }
        public override void Draw()
        {
            this.Graphics.Clear();
            this.Graphics.Draw(image);
            this.Graphics.Flush();
        }

        // Protected
        protected override void Cleanup()
        {
            texture.Dispose();
        }

        // Constructors
        public DemoGame()
        {
            this.Graphics.BackgroundColor = Colors.Orange;
            texture = this.Graphics.CreateTexture("D:\\charanim.png");
            image = new Image(texture) {
                Center = new Vector2(0.5f),
                Position = new Vector2(-0.5f),
            };
        }
    }
}
