using Lamby2D.Core;
using Lamby2D.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.UI
{
    public class Border : ContentControl
    {
        // Constructors
        public Border()
        {
            this.BorderThickness = 1;
            this.BorderColor = Colors.Black;
        }
    }
}
