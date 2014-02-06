using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Drawing
{
    public class SpriteAnimation
    {
        // Variables
        int _framespersecond;

        // Properties
        public int[] Frames { get; private set; }
        public int FramesPerSecond
        {
            get { return _framespersecond; }
            set
            {
                if (value <= 0) {
                    throw new ArgumentOutOfRangeException("value", "FramesPerSecond must be greater than zero.");
                }

                if (_framespersecond != value) {
                    _framespersecond = value;
                    this.FrameLifeTime = 1.0f / value;
                }
            }
        }
        public float FrameLifeTime { get; private set; }

        // Constructors
        public SpriteAnimation(int[] frames, int framespersecond)
        {
            this.Frames = new int[frames.Length];
            Array.Copy(frames, this.Frames, frames.Length);
            this.FramesPerSecond = framespersecond;
        }
    }
}
