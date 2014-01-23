using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lamby2D.Input;

namespace Lamby2D
{
    public class GameInput
    {
        // Variables
        bool[] _keystates;
        bool[] _mousestates;

        // Events
        public event KeyEventHandler KeyDown;
        public event KeyEventHandler KeyUp;
        public event MouseButtonEventHandler MouseDown;
        public event MouseButtonEventHandler MouseUp;

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
            if (this.MouseDown != null) {
                this.MouseDown(this, e);
            }
        }
        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _mousestates[(int) e.Button] = false;
            if (this.MouseUp != null) {
                this.MouseUp(this, e);
            }
        }

        // Constructors
        public GameInput()
        {
            _keystates = new bool[255];
            _mousestates = new bool[5];

            Game.Current.Graphics.GraphicsContext.Window.KeyDown += Window_KeyDown;
            Game.Current.Graphics.GraphicsContext.Window.KeyUp += Window_KeyUp;
            Game.Current.Graphics.GraphicsContext.Window.MouseDown += Window_MouseDown;
            Game.Current.Graphics.GraphicsContext.Window.MouseUp += Window_MouseUp;
        }
    }
}
