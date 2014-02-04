using Lamby2D.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Input
{
    public interface IMouseAware
    {
        int ZIndex { get; }
        bool IsHitTestVisible { get; }

        event MouseButtonEventHandler MouseDown;
        event MouseButtonEventHandler MouseUp;
        event MouseMotionEventHandler MouseEnter;
        event MouseMotionEventHandler MouseLeave;

        bool MouseHitTest(Point position);
        void OnMouseDown(MouseButtonEventArgs e);
        void OnMouseUp(MouseButtonEventArgs e);
        void OnMouseEnter(MouseMotionEventArgs e);
        void OnMouseLeave(MouseMotionEventArgs e);
    }
}
