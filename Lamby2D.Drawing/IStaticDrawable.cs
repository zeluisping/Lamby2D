using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lamby2D.Core;

namespace Lamby2D.Drawing
{
    /// <summary>
    /// Interface for game objects that are a static texture.
    /// </summary>
    public interface IStaticDrawable
    {
        Texture2D Texture { get; }
        Vector2 Position { get; }
        Vector2 Center { get; }
        float Rotation { get; }
        bool IsVisible { get; }
    }
}
