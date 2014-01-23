using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Input
{
    public delegate void KeyEventHandler(object sender, KeyEventArgs e);

    public class KeyEventArgs : EventArgs
    {
        // Properties
        public KeyCode Key { get; private set; }
        public bool Handled { get; set; }

        // Constructors
        public KeyEventArgs(KeyCode keycode)
        {
            this.Key = keycode;
        }
    }
}
