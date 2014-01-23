using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lamby2D.Drawing;
using Lamby2D.Input;

namespace Lamby2D
{
    public class Game : IDisposable
    {
        // Static properties
        public static Game Current { get; private set; }

        // Variables
        List<ITickable> _tickables;
        List<IStaticDrawable> _staticdrawables;

        // Properties
        public Graphics Graphics { get; private set; }
        public GameInput Input { get; private set; }

        // Public
        public void MainLoop()
        {
            DateTime lasttick = DateTime.UtcNow;

            while (Graphics.GraphicsContext.Window != null) {
                this.Input.Update(); // resets deltas
                this.Graphics.GraphicsContext.Window.PollMessages();

                if (this.Graphics.GraphicsContext.Window == null) {
                    break;
                }

                float dt = (float) (DateTime.UtcNow - lasttick).TotalSeconds;
                lasttick = DateTime.UtcNow;

                this.Update(dt);
                foreach (ITickable tickable in _tickables) {
                    tickable.Update(dt);
                }

                this.Graphics.Clear();
                foreach (IStaticDrawable staticdrawable in _staticdrawables) {
                    if (staticdrawable.IsVisible == true) {
                        this.Graphics.Draw(staticdrawable);
                    }
                }
                Draw();
                this.Graphics.Flush();
            }
        }
        public virtual void Update(float DeltaTime)
        {
        }
        public virtual void Draw()
        {
        }
        public void Dispose()
        {
            this.Graphics.Dispose();
            this.Graphics = null;
            this.Cleanup();
        }

        // Internal
        internal void RegisterGameObject(GameObject obj)
        {
            // Functionality
            if (obj is ITickable) {
                _tickables.Add(obj as ITickable);
            }

            // Drawing
            if (obj is IStaticDrawable) {
                _staticdrawables.Add(obj as IStaticDrawable);
            }

            // Input
            if (obj is IClickable) {
                this.Input.Clickables.Add(obj as IClickable);
            }
        }
        internal void UnRegisterGameObject(GameObject obj)
        {
            // Functionality
            if (obj is ITickable) {
                _tickables.Remove(obj as ITickable);
            }

            // Drawing
            if (obj is IStaticDrawable) {
                _staticdrawables.Remove(obj as IStaticDrawable);
            }

            // Input
            if (obj is IClickable) {
                this.Input.Clickables.Remove(obj as IClickable);
            }
        }

        // Protected
        protected virtual void Cleanup()
        {
        }

        // Constructors
        public Game()
        {
            if (Game.Current != null) {
                throw new Exception("Trying to create a Game instance when one already exists.");
            }
            Game.Current = this;

            _tickables = new List<ITickable>();
            _staticdrawables = new List<IStaticDrawable>();

            this.Graphics = new Graphics();
            this.Input = new GameInput();
        }
    }
}
