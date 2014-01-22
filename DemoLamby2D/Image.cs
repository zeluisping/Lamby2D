using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lamby2D.Core;
using Lamby2D.Drawing;

namespace DemoLamby2D
{
    class Image : IStaticDrawable
    {
        // Properties
        public Texture2D Texture { get; private set; }
        public float Rotation { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Center { get; set; }

        // Constructors
        public Image(Texture2D texture)
        {
            this.Texture = texture;
        }
    }
}
