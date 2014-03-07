using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D
{
    /// <summary>
    /// Provides a clean method for starting a game.
    /// </summary>
    public sealed class Application
    {
        /// <summary>
        /// Starts a game of the specified type.
        /// </summary>
        /// <typeparam name="T">The game type.</typeparam>
        public void Run<T>() where T : Game, new()
        {
            using (T game = new T()) {
                game.MainLoop();
            }
        }

        /// <summary>
        /// Creates an instance of a class that provides a clean method for starting a game.
        /// </summary>
        public Application()
        {
        }
    }
}
