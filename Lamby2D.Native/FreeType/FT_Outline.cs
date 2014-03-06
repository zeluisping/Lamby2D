using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Native.FreeType
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FT_Outline
    {
        short n_contours;      /* number of contours in glyph        */
        short n_points;        /* number of points in the glyph      */

        IntPtr points;          /* the outline's points               */
        IntPtr tags;            /* the points flags                   */
        IntPtr contours;        /* the contour end points             */

        int flags;           /* outline masks                      */
    }
}
