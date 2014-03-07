using Lamby2D.Core;
using Lamby2D.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Levels
{
    public class GridTile : IDrawable
    {
        // Properties
        public DrawableKind DrawableKind { get; set; }
        public Texture2D Texture { get; set; }
        public Sprite Sprite { get; set; }
        /// <summary>
        /// Not used; always <see cref="Vector2.Zero"/>. Actual position dictated by <see cref="Lamby2D.Maps.TileGrid"/>.
        /// </summary>
        public Vector2 Position { get { return Vector2.Zero; } }
        public Vector2 Center { get; set; }
        public Vector2 Scale { get; set; }
        public Color Color { get; set; }
        public float Rotation { get; set; }
        public int ZIndex { get; set; }
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

        // Constructors
        public GridTile()
        {
            this.Center = Vector2.Half;
            this.Scale = Vector2.One;
            this.Color = Colors.White;
        }
    }
}
