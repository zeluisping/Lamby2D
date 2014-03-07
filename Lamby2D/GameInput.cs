using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lamby2D.Core;
using Lamby2D.Input;

namespace Lamby2D
{
    /// <summary>
    /// Handles all input events and callbacks.
    /// </summary>
    public class GameInput
    {
        // Variables
        bool[] _keystates;
        bool[] _mousestates;
        Point _mousepos;
        //[Obsolete("not implemented", true)]
        //Point _mousedelta;
        List<IMouseAware> _mouseawares;
        IMouseAware _mouseawarehover;

        // Properties
        /// <summary>
        /// Get the current mouse position relative to the window.
        /// </summary>
        public Point MousePosition
        {
            get { return _mousepos; }
        }
        [Obsolete("not implemented", true)]
        public Point MouseDelta
        {
            get { return default(Point); }
            //get { return _mousedelta; }
        }
        internal List<IMouseAware> MouseAwares
        {
            get { return _mouseawares; }
        }

        // Events
        /// <summary>
        /// Called whenever the state of a key changes to pressed.
        /// </summary>
        public event KeyEventHandler KeyDown;
        /// <summary>
        /// Called whenever the state of a key changes to released.
        /// </summary>
        public event KeyEventHandler KeyUp;
        /// <summary>
        /// Called whenever the state of a mouse button changes to pressed.
        /// </summary>
        public event MouseButtonEventHandler MouseDown;
        /// <summary>
        /// Called whenever the state of a mouse button changes to released.
        /// </summary>
        public event MouseButtonEventHandler MouseUp;
        /// <summary>
        /// Called whenever the mouse moves within the window.
        /// </summary>
        public event MouseMotionEventHandler MouseMotion;

        // Handlers
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            _keystates[(int) (e.Key & KeyCode.KeyCode)] = true;
            if (this.KeyDown != null) {
                this.KeyDown(this, e);
            }
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            _keystates[(int) (e.Key & KeyCode.KeyCode)] = false;
            if (this.KeyUp != null) {
                this.KeyUp(this, e);
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _mousestates[(int) e.Button] = true;
            //_mousepos = e.Position;
            //_mousedelta += _mousedelta - e.Position;
            if (this.MouseDown != null) {
                this.MouseDown(this, e);
            }

            if (e.Handled == false) {
                IMouseAware handler = gethandler(e.Position);
                if (handler != null) {
                    handler.OnMouseDown(new MouseButtonEventArgs(e.Button, e.Position));
                }
            }
        }
        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _mousestates[(int) e.Button] = false;
            if (this.MouseUp != null) {
                this.MouseUp(this, e);
            }

            if (e.Handled == false) {
                IMouseAware handler = gethandler(e.Position);
                if (handler != null) {
                    handler.OnMouseUp(new MouseButtonEventArgs(e.Button, e.Position));
                }
            }
        }
        private void Window_MouseMotion(object sender, MouseMotionEventArgs e)
        {
            //_mousedelta += _mousepos - e.Position;
            _mousepos = e.Position;
            if (this.MouseMotion != null) {
                this.MouseMotion(this, e);
            }

            IMouseAware handler = gethandler(e.Position);
            if (handler != _mouseawarehover) {
                if (_mouseawarehover != null) {
                    _mouseawarehover.OnMouseLeave(e);
                }
                _mouseawarehover = handler;
                if (handler != null) {
                    handler.OnMouseEnter(e);
                }
            }
        }

        // Public
        /// <summary>
        /// Check if a key is being pressed.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>True if the key is being pressed, otherwise false.</returns>
        public bool IsKeyDown(KeyCode key)
        {
            if ((int) key < 1 || (int) key > 254) {
                return false;
            }
            return _keystates[(int) key];
        }
        /// <summary>
        /// Check if a mouse button is being pressed.
        /// </summary>
        /// <param name="button">The mouse button.</param>
        /// <returns>True if the mouse button is being pressed, otherwise false.</returns>
        public bool IsButtonDown(MouseButton button)
        {
            return _mousestates[(int) button];
        }

        // Internal
        internal void Update()
        {
            //_mousedelta = Point.Zero;
        }

        // Private
        IMouseAware gethandler(Point position)
        {
            IMouseAware handler = null;
            //foreach (IMouseAware aware in _mouseawares) {
            for (int i = _mouseawares.Count - 1; i >= 0; i--) {
                IMouseAware aware = _mouseawares[i];
                if (aware.IsHitTestVisible == true && aware.MouseHitTest(position) == true) {
                    handler = (handler == null
                                    ? aware
                                    : aware.ZIndex > handler.ZIndex
                                            ? aware
                                            : handler);
                }
            }
            return handler;
        }

        // Constructors
        internal GameInput()
        {
            _keystates = new bool[255];
            _mousestates = new bool[5];
            _mouseawares = new List<IMouseAware>();

            Game.Current.Graphics.GraphicsContext.Window.KeyDown += Window_KeyDown;
            Game.Current.Graphics.GraphicsContext.Window.KeyUp += Window_KeyUp;
            Game.Current.Graphics.GraphicsContext.Window.MouseDown += Window_MouseDown;
            Game.Current.Graphics.GraphicsContext.Window.MouseUp += Window_MouseUp;
            Game.Current.Graphics.GraphicsContext.Window.MouseMotion += Window_MouseMotion;
        }
    }
}
