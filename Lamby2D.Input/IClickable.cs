using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lamby2D.Core;
using Lamby2D.Input;

namespace Lamby2D.Input
{
    /// <summary>
    /// Interface for game objects that can be clicked.
    /// </summary>
    public interface IClickable
    {
        // Properties
        int ZIndex { get; }
        bool IsHitTestVisible { get; }

        // Events
        event MouseButtonEventHandler Clicked;

        // Public
        void OnClick(MouseButton button);
        bool ClickHitTest(Point position, MouseButton button);
    }
}
