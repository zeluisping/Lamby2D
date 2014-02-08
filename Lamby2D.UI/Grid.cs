using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.UI
{
    public class Grid : Control
    {
        // Properties
        public List<Control> Children { get; private set; }

        // Constructors
        public Grid()
        {
            this.Children = new List<Control>();
        }
    }
}
