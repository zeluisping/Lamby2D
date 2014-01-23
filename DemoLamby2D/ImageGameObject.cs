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
    class ImageGameObject : GameObject, IStaticDrawable
    {
        // Properties
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Center { get; set; }
        public float Rotation { get; set; }
        public bool IsVisible { get; set; }

        // Constructors
        public ImageGameObject()
        {
            this.IsVisible = true; // change default value to true
        }
    }
}
