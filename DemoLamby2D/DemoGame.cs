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
        Image image;
        ImageGameObject imagegameobject;

        // Public
        public override void Update(float DeltaTime)
        {
            this.Graphics.GraphicsContext.Window.Title = DeltaTime.ToString();
            image.Rotation += DeltaTime * 10;
        }
        public override void Draw()
        {
            // image is not a GameObject, so it does not draw by itself
            this.Graphics.Draw(image);
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

            imagegameobject = new ImageGameObject() {
                Center = new Vector2(0.5f),
                Position = new Vector2(+0.5f),
                Texture = texture, // textures can be used by multiple drawables at the same time
            };
            imagegameobject.Clicked += delegate
            {
                imagegameobject.Position = new Vector2();
            };
        }
    }
}
