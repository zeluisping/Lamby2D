using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lamby2D;
using Lamby2D.Core;
using Lamby2D.Drawing;

namespace DemoLamby2D
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DemoGame game = new DemoGame()) {
                game.MainLoop();
            }
        }
    }
}
