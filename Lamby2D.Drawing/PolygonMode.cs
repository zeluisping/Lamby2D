using Lamby2D.Native.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Drawing
{
    /// <summary>
    /// Polygon rasterization mode.
    /// </summary>
    public enum PolygonMode : uint
    {
        /// <summary>
        /// Fill the inside of polygons.
        /// </summary>
        Fill = OpenGL.GL_FILL,
        /// <summary>
        /// Draw the outline of polygons.
        /// </summary>
        Line = OpenGL.GL_LINE,
        /// <summary>
        /// Draw the vertices of polygons.
        /// </summary>
        Point = OpenGL.GL_POINT,
    }
}
