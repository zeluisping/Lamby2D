using Lamby2D.Core;
using Lamby2D.Drawing;
using Lamby2D.Native.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.UI
{
    /// <summary>
    /// Handles all UI elements.
    /// </summary>
    internal sealed class UIManager
    {
        // Properties
        public ContentControl Root { get; set; }
        Border border = new Border() {
            Background = new Color(0.5f, 0, 0.5f, 0.25f),
            BorderColor = Colors.Red,
            BorderThickness = 1,
            Width = 320,
            Height= 180,
            Position = new Point(160, 90),
        };

        // Internal
        internal void Draw(Graphics graphics)
        {
            OpenGL.glLoadIdentity();

            draw(graphics, this.Root);
            border.Draw(graphics);
        }
        
        // Private
        void draw(Graphics graphics, Control control)
        {
            if (control == null) {
                return;
            }

            control.Draw(graphics);

            if (control is ContentControl) {
                graphics.Translate(control.Position);
                draw(graphics, ((ContentControl) control).Content);
                graphics.Translate(control.Position.Negated);
            }
        }

        // Constructors
        public UIManager()
        {
            this.Root = new ContentControl();
        }
    }
}
