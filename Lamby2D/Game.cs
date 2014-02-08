using Lamby2D.Drawing;
using Lamby2D.Input;
using Lamby2D.Physics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D
{
    public class Game : IDisposable
    {
        // Static properties
        #region public static Game Current { get; private set; }
        static Game _current;
        public static Game Current
        {
            get { return _current; }
            private set
            {
                if (_current != value) {
                    if (_current != null) {
                        throw new InvalidOperationException("Trying to create a Game instance when one already exists.");
                    }

                    _current = value;
                }
            }
        }
        #endregion

        // Variables
        List<ITickable> _tickables;
        List<IDrawable> _drawables;

        // Properties
        public Graphics Graphics { get; private set; }
        public GameInput Input { get; private set; }
        public GamePhysics Physics { get; private set; }
        public int FramesPerSecond { get; private set; }
        protected IEnumerable Tickables { get { return _tickables.AsEnumerable(); } }
        protected IEnumerable Drawables { get { return _drawables.AsEnumerable(); } }
        protected bool bQuit { get; private set; }

        // Public
        public virtual void Update(float DeltaTime)
        {
        }
        public virtual void PostUpdate(float DeltaTime)
        {
        }
        public virtual void PostDraw()
        {
        }
        public virtual void Dispose()
        {
            this.Graphics.Dispose();
        }
        public void Quit()
        {
            this.bQuit = true;
        }

        // Internal
        protected internal virtual void MainLoop()
        {
            Stopwatch timer = new Stopwatch();
            float fpstime = 0;
            int fpscounter = 0;

            timer.Start();
            while (Graphics.GraphicsContext.Window != null) {
                if (this.bQuit == true) {
                    return;
                }

                this.Input.Update(); // resets deltas
                this.Graphics.GraphicsContext.Window.PollMessages();

                if (this.Graphics.GraphicsContext.Window == null || this.bQuit == true) {
                    break;
                }

                //float dt = (float) (DateTime.UtcNow - lasttick).TotalSeconds;
                //lasttick = DateTime.UtcNow;
                float dt = (float) timer.Elapsed.TotalSeconds;
                timer.Restart();

                this.Update(dt);
                if (this.bQuit == true) {
                    return;
                }

                foreach (ITickable tickable in _tickables) {
                    tickable.Update(dt);
                    if (this.bQuit == true) {
                        return;
                    }
                }

                this.PostUpdate(dt);
                if (this.bQuit == true) {
                    return;
                }

                this.Graphics.Clear();
                _drawables.Sort((a, b) => a.ZIndex - b.ZIndex);
                foreach (IDrawable drawable in _drawables) {
                    if (drawable.DrawableKind == DrawableKind.Sprite && drawable.Sprite != null && drawable.Sprite.CurrentAnimation != null) {
                        drawable.Sprite.NextFrameIn -= dt;
                        if (drawable.Sprite.NextFrameIn <= 0) {
                            drawable.Sprite.NextFrameIn = drawable.Sprite._animations[drawable.Sprite.CurrentAnimation].FrameLifeTime;
                            ++drawable.Sprite.Frame;
                            if (drawable.Sprite.Frame >= drawable.Sprite._animations[drawable.Sprite.CurrentAnimation].Frames.Length) {
                                drawable.Sprite.Frame = 0;
                            } // if
                        } // if
                    } // if
                    this.Graphics.Draw(drawable);
                }
                PostDraw();
                this.Graphics.Flush();

                ++fpscounter;
                fpstime += dt;
                if (fpstime >= 1) {
                    this.FramesPerSecond = (int) (fpscounter / fpstime);
                    fpscounter = 0;
                    fpstime = 0;
                }
            }
        }
        internal void RegisterGameObject(GameObject obj)
        {
            // Functionality
            if (obj is ITickable) {
                _tickables.Add(obj as ITickable);
            }

            // Drawing
            if (obj is IDrawable) {
                IDrawable staticdrawable = (IDrawable) obj;
                _drawables.Add(staticdrawable);
            }

            // Input
            if (obj is IMouseAware) {
                this.Input.MouseAwares.Add(obj as IMouseAware);
            }

            // Physics
            if (obj is IPhysicsObject) {
                this.Physics.PhysicsObjects.Add(obj as IPhysicsObject);
            }
        }
        internal void UnRegisterGameObject(GameObject obj)
        {
            // Functionality
            if (obj is ITickable) {
                _tickables.Remove(obj as ITickable);
            }

            // Drawing
            if (obj is IDrawable) {
                IDrawable staticdrawable = (IDrawable) obj;
                _drawables.Remove(staticdrawable);
            }
            
            // Input
            if (obj is IMouseAware) {
                this.Input.MouseAwares.Remove(obj as IMouseAware);
            }

            // Physics
            if (obj is IPhysicsObject) {
                this.Physics.PhysicsObjects.Remove(obj as IPhysicsObject);
            }
        }

        // Constructors
        public Game()
        {
            Game.Current = this;

            _tickables = new List<ITickable>();
            _drawables = new List<IDrawable>();

            this.Graphics = new Graphics();
            this.Input = new GameInput();
            this.Physics = new GamePhysics();
        }
    }
}
