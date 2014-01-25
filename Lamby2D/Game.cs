using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lamby2D.Core;
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
        //SortedList<int, IStaticDrawable> _staticdrawables;
        List<IStaticDrawable> _staticdrawables;

        // Properties
        public Graphics Graphics { get; private set; }
        public GameInput Input { get; private set; }

        // Handlers
        /*private void staticdrawable_ZIndexChanged(object sender, ZIndexChangedEventArgs e)
        {
            _staticdrawables.Remove(e.OldValue);
            _staticdrawables.Add(e.NewValue, (IStaticDrawable) sender);
        }*/

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
                _staticdrawables.Sort((a, b) => a.ZIndex - b.ZIndex);
                foreach (IStaticDrawable drawable in _staticdrawables) {
                    if (drawable.IsVisible == true) {
                        this.Graphics.Draw(drawable);
                    }
                }
                PostDraw();
                this.Graphics.Flush();
            }
        }
        public virtual void Update(float DeltaTime)
        {
        }
        public virtual void PostDraw()
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
                IStaticDrawable staticdrawable = (IStaticDrawable) obj;
                _staticdrawables.Add(staticdrawable);
                //_staticdrawables.Sort((a, b) => a.ZIndex - b.ZIndex);
                //_staticdrawables.Add(staticdrawable.ZIndex, staticdrawable);
                //staticdrawable.ZIndexChanged += staticdrawable_ZIndexChanged;
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
                IStaticDrawable staticdrawable = (IStaticDrawable) obj;
                _staticdrawables.Remove(staticdrawable);
                //_staticdrawables.Remove(staticdrawable.ZIndex);
                //staticdrawable.ZIndexChanged -= staticdrawable_ZIndexChanged;
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
