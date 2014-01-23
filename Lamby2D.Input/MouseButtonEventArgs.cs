using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Input
{
    public delegate void MouseButtonEventHandler(object sender, MouseButtonEventArgs e);

    public class MouseButtonEventArgs : EventArgs
    {
        // Properties
        public MouseButton Button { get; private set; }
        public bool Handled { get; set; }

        // Constructors
        public MouseButtonEventArgs(MouseButton button)
        {
            this.Button = button;
        }
    }
}
