using Lamby2D.Drawing;
using Lamby2D.Levels;
using Lamby2D.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Editor.Controls
{
    public class TileGridMapEditor : Control
    {
        public TileGridMap Map { get; set; }

        protected override void Draw(Graphics g)
        {
            base.Draw(g);

            if (this.Map != null) {
                this.Map.Draw(g);
            }
        }
    }
}
