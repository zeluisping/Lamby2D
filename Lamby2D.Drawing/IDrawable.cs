using Lamby2D.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Drawing
{
    public interface IDrawable
    {
        DrawableKind DrawableKind { get; }
        Texture2D Texture { get; }
        Sprite Sprite { get; }
        Vector2 Position { get; }
        Vector2 Center { get; }
        Vector2 Scale { get; }
        Color Color { get; }
        float Rotation { get; }
        int ZIndex { get; }
        float Width { get; }
        float Height { get; }
    }
}
