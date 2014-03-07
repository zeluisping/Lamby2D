using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D
{
    /// <summary>
    /// Interface for game objects that require to be updated each frame.
    /// </summary>
    public interface ITickable
    {
        /// <summary>
        /// The function called each frame to update the object.
        /// </summary>
        /// <param name="DeltaTime">The time elapsed since the last frame.</param>
        void Update(float DeltaTime);
    }
}
