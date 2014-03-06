using Lamby2D.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.UI
{
    public class Button : ContentControl
    {
        // Public
        public override void OnMouseEnter(Input.MouseMotionEventArgs e)
        {
            this.Background = Colors.DarkGray;
            base.OnMouseEnter(e);
        }
        public override void OnMouseLeave(Input.MouseMotionEventArgs e)
        {
            base.OnMouseLeave(e);
        }
        public override void OnMouseDown(Input.MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
        }
    }
}
