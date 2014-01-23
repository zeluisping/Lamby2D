using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lamby2D.Core;

namespace Lamby2D.Input
{
    public delegate void MouseMotionEventHandler(object sender, MouseMotionEventArgs e);

    public class MouseMotionEventArgs : EventArgs
    {
        // Properties
        public Point Position { get; private set; }

        // Constructors
        public MouseMotionEventArgs(Point position)
        {
            this.Position = position;
        }
    }
}
