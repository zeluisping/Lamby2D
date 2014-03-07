using Lamby2D.Core;
using Lamby2D.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Levels
{
    public class TileGridLevel
    {
        // Variables
        int _tilewidth;
        int _tileheight;
        TileGrid _grid;

        // Properties
        public TileGrid Grid
        {
            get { return _grid; }
            private set { _grid = value; }
        }
        public int Width
        {
            get { return this.Grid.Width; }
        }
        public int Height
        {
            get { return this.Grid.Height; }
        }
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public Vector2 Position { get; set; }

        // Public
        public void Draw(Graphics g)
        {
            g.PushMatrix();
            g.Translate(this.Position);
            for (int y = 0; y < this.Height; y++) {
                for (int x = 0; x < this.Width; x++) {
                    GridTile tile = this.Grid.Tiles[x + y + this.Width];
                    if (tile != null) {
                        g.Draw(tile);
                    }
                    g.Translate(this.TileWidth, 0);
                }
                g.Translate(0, this.TileHeight);
            }
            g.PopMatrix();
        }

        // Constructors
        public TileGridLevel(int width, int height)
        {
            this.Grid = new TileGrid(width, height);
        }
    }
}
