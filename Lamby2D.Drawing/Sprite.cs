using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Drawing
{
    public class Sprite
    {
        // Variables
        internal Dictionary<string, SpriteAnimation> _animations;

        // Properties
        public Texture2D Texture { get; private set; }
        public int FrameWidth { get; private set; }
        public int FrameHeight { get; private set; }
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public int FrameCount { get; private set; }
        public int Frame { get; internal set; }
        public string CurrentAnimation { get; private set; }
        internal float NextFrameIn { get; set; }

        // Public
        public void AddAnimation(string name, SpriteAnimation animation)
        {
            _animations[name] = animation;
        }
        public void RemoveAnimation(string name)
        {
            _animations.Remove(name);
        }
        public bool HasAnimation(string name)
        {
            return _animations.ContainsKey(name);
        }
        public bool PlayAnimation(string name)
        {
            if (name == null) {
                this.CurrentAnimation = null;
                this.Frame = 0;

                return true;
            }

            if (_animations.ContainsKey(name) == false) {
                return false;
            }

            this.CurrentAnimation = name;
            this.Frame = 0;
            this.NextFrameIn = _animations[name].FrameLifeTime;

            return true;
        }

        // Constructors
        public Sprite(Texture2D texture, int framewidth, int frameheight)
        {
            _animations = new Dictionary<string, SpriteAnimation>();

            this.Texture = texture;
            this.FrameWidth = framewidth;
            this.FrameHeight = frameheight;
            this.Rows = (texture.Height / frameheight);
            this.Columns = (texture.Width / framewidth);
            this.FrameCount = (this.Rows * this.Columns);
            this.Frame = -1;
        }
    }
}
