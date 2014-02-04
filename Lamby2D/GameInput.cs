using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lamby2D.Core;
using Lamby2D.Input;

namespace Lamby2D
{
    public class GameInput
    {
        // Variables
        bool[] _keystates;
        bool[] _mousestates;
        Point _mousepos;
        Point _mousedelta;
        List<IMouseAware> _mouseawares;
        IMouseAware _mouseawarehover;

        // Properties
        public Point MousePosition
        {
            get { return _mousepos; }
        }
        public Point MouseDelta
        {
            get { return _mousedelta; }
        }
        internal List<IMouseAware> MouseAwares
        {
            get { return _mouseawares; }
        }

        // Events
        public event KeyEventHandler KeyDown;
        public event KeyEventHandler KeyUp;
        public event MouseButtonEventHandler MouseDown;
        public event MouseButtonEventHandler MouseUp;
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
                IMouseAware handler = null;
                foreach (IMouseAware aware in _mouseawares) {
                    if (aware.IsHitTestVisible == true && aware.MouseHitTest(e.Position) == true) {
                        handler = (handler == null
                                        ? aware
                                        : aware.ZIndex > handler.ZIndex
                                                ? aware
                                                : handler);
                    }
                }

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
                IMouseAware handler = null;
                foreach (IMouseAware aware in _mouseawares) {
                    if (aware.IsHitTestVisible == true && aware.MouseHitTest(e.Position) == true) {
                        handler = (handler == null
                                        ? aware
                                        : aware.ZIndex > handler.ZIndex
                                                ? aware
                                                : handler);
                    }
                }

                if (handler != null) {
                    handler.OnMouseUp(new MouseButtonEventArgs(e.Button, e.Position));
                }
            }
        }
        private void Window_MouseMotion(object sender, MouseMotionEventArgs e)
        {
            _mousedelta += _mousepos - e.Position;
            _mousepos = e.Position;
            if (this.MouseMotion != null) {
                this.MouseMotion(this, e);
            }

            IMouseAware handler = null;
            foreach (IMouseAware aware in _mouseawares) {
                if (aware.IsHitTestVisible == true && aware.MouseHitTest(e.Position) == true) {
                    handler = (handler == null
                                    ? aware
                                    : aware.ZIndex > handler.ZIndex
                                            ? aware
                                            : handler);
                }
            }

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
        public bool IsKeyDown(KeyCode key)
        {
            if ((int) key < 1 || (int) key > 254) {
                return false;
            }
            return _keystates[(int) key];
        }
        public bool IsButtonDown(MouseButton button)
        {
            return _mousestates[(int) button];
        }

        // Internal
        internal void Update()
        {
            _mousedelta = Point.Zero;
        }

        // Constructors
        public GameInput()
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
