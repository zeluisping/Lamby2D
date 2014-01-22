using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lamby2D.Core;

namespace Lamby2D.Drawing
{
    public interface IStaticDrawable
    {
        // Properties
        Texture2D Texture { get; }
        /// <summary>
        /// Relative center of the drawable.
        /// </summary>
        Vector2 Center { get; }
        float Rotation { get; }
        Vector2 Position { get; }
    }
}
