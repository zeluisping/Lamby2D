using Lamby2D.Core;
using Lamby2D.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.UI
{
    public class Control : IMouseAware
    {
        // Properties
        public int ZIndex { get; set; }
        public bool IsHitTestVisible { get; set; }
        public Control Parent { get; internal set; }
        [Obsolete("not implemented", true)]
        public object DataContext { get; set; }

        // Events
        public event MouseButtonEventHandler MouseDown;
        public event MouseButtonEventHandler MouseUp;
        public event MouseMotionEventHandler MouseEnter;
        public event MouseMotionEventHandler MouseLeave;

        // Public
        public bool MouseHitTest(Point position)
        {
            return false;
        }
        public virtual void OnMouseDown(MouseButtonEventArgs e)
        {
            if (this.MouseDown != null) {
                this.MouseDown(this, e);
            }
        }
        public virtual void OnMouseUp(MouseButtonEventArgs e)
        {
            if (this.MouseUp != null) {
                this.MouseUp(this, e);
            }
        }
        public virtual void OnMouseEnter(MouseMotionEventArgs e)
        {
            if (this.MouseEnter != null) {
                this.MouseEnter(this, e);
            }
        }
        public virtual void OnMouseLeave(MouseMotionEventArgs e)
        {
            if (this.MouseLeave != null) {
                this.MouseLeave(this, e);
            }
        }

        // Constructors
        public Control()
        {
        }
    }
}
