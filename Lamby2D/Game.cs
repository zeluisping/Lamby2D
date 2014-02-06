using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lamby2D.Core;
using Lamby2D.Drawing;
using Lamby2D.Input;
using System.Diagnostics;
using Lamby2D.Physics;

namespace Lamby2D
{
    public class Game : IDisposable
    {
        // Static properties
        public static Game Current { get; private set; }

        // Variables
        List<ITickable> _tickables;
        List<IDrawable> _drawables;
        bool _quit;

        // Properties
        public Graphics Graphics { get; private set; }
        public GameInput Input { get; private set; }
        public GamePhysics Physics { get; private set; }
        public int FramesPerSecond { get; private set; }

        // Public
        public void MainLoop()
        {
            Stopwatch timer = new Stopwatch();
            float fpstime = 0;
            int fpscounter = 0;

            timer.Start();
            while (Graphics.GraphicsContext.Window != null) {
                if (_quit == true) {
                    return;
                }

                this.Input.Update(); // resets deltas
                this.Graphics.GraphicsContext.Window.PollMessages();

                if (this.Graphics.GraphicsContext.Window == null || _quit == true) {
                    break;
                }

                //float dt = (float) (DateTime.UtcNow - lasttick).TotalSeconds;
                //lasttick = DateTime.UtcNow;
                float dt = (float) timer.Elapsed.TotalSeconds;
                timer.Restart();

                this.Update(dt);
                if (_quit == true) {
                    return;
                }

                foreach (ITickable tickable in _tickables) {
                    tickable.Update(dt);
                    if (_quit == true) {
                        return;
                    }
                }

                this.PostUpdate(dt);
                if (_quit == true) {
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
        public virtual void Update(float DeltaTime)
        {
        }
        public virtual void PostUpdate(float DeltaTime)
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
        public void Quit()
        {
            _quit = true;
        }

        // Internal
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
                //_staticdrawables.Sort((a, b) => a.ZIndex - b.ZIndex);
                //_staticdrawables.Add(staticdrawable.ZIndex, staticdrawable);
                //staticdrawable.ZIndexChanged += staticdrawable_ZIndexChanged;
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
                //_staticdrawables.Remove(staticdrawable.ZIndex);
                //staticdrawable.ZIndexChanged -= staticdrawable_ZIndexChanged;
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
            _drawables = new List<IDrawable>();

            this.Graphics = new Graphics();
            this.Input = new GameInput();
            this.Physics = new GamePhysics();
        }
    }
}
