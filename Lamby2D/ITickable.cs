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
        void Update(float DeltaTime);
    }
}
