using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D
{
    public class Application
    {
        // Public
        public void Run<T>() where T : Game, new()
        {
            using (T game = new T()) {
                game.MainLoop();
            }
        }

        // Constructors
        public Application()
        {
        }
    }
}
