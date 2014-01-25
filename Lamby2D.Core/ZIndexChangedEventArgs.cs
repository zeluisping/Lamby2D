using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Core
{
    public delegate void ZIndexChangedEventHandler(object sender, ZIndexChangedEventArgs e);

    public class ZIndexChangedEventArgs : EventArgs
    {
        // Public
        public int OldValue { get; private set; }
        public int NewValue { get; set; }

        // Constructors
        public ZIndexChangedEventArgs(int oldvalue, int newvalue)
        {
            this.OldValue = oldvalue;
            this.NewValue = newvalue;
        }
    }
}
