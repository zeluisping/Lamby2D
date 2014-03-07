using Lamby2D.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Drawing
{
    public class Image : IDrawable
    {
        // Properties
        

        // Constructors
        public Image()
        {
            this.Center = Vector2.Half;
            this.Scale = Vector2.One;
            this.Color = Colors.White;
        }
        public Image(Texture2D texture)
        {
            this.Center = Vector2.Half;
            this.Scale = Vector2.One;
            this.Color = Colors.White;
            this.Texture = texture;
        }
    }
}
