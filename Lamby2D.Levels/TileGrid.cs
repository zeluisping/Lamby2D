using Lamby2D.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Levels
{
    public class TileGrid
    {
        // Properties
        public int Width { get; private set; }
        public int Height { get; private set; }
        public GridTile[] Tiles { get; private set; }

        // Public
        public GridTile GetTileAt(Point pos)
        {
            if (pos.X < 0 || pos.X >= this.Width) {
                throw new ArgumentOutOfRangeException("pos.X");
            }
            if (pos.Y < 0 || pos.Y >= this.Height) {
                throw new ArgumentOutOfRangeException("pos.Y");
            }

            return this.Tiles[pos.X + pos.Y * this.Width];
        }
        public GridTile GetTileAtIndex(int index)
        {
            if (index < 0 || index >= this.Tiles.Length) {
                throw new ArgumentOutOfRangeException("index");
            }
            return this.Tiles[index];
        }
        public int GetTileIndex(Point pos)
        {
            if (pos.X < 0 || pos.X >= this.Width) {
                throw new ArgumentOutOfRangeException("pos.X");
            }
            if (pos.Y < 0 || pos.Y >= this.Height) {
                throw new ArgumentOutOfRangeException("pos.Y");
            }

            return (pos.X + pos.Y * this.Width);
        }
        public GridTile MoveTile(GridTile tile, Point newpos)
        {
            if (tile == null) {
                throw new ArgumentNullException("tile");
            }
            if (newpos.X < 0 || newpos.X >= this.Width) {
                throw new ArgumentOutOfRangeException("newpos.X");
            }
            if (newpos.Y < 0 || newpos.Y >= this.Height) {
                throw new ArgumentOutOfRangeException("newpos.Y");
            }

            GridTile at = this.Tiles[newpos.X + newpos.Y * this.Width];
            this.Tiles[newpos.X + newpos.Y * this.Width] = tile;
            return at;
        }
        public void SwapTiles(Point first, Point second)
        {
            if (first.X < 0 || first.X >= this.Width) {
                throw new ArgumentOutOfRangeException("first.X");
            }
            if (first.Y < 0 || first.Y >= this.Height) {
                throw new ArgumentOutOfRangeException("first.Y");
            }
            if (second.X < 0 || second.X >= this.Width) {
                throw new ArgumentOutOfRangeException("second.X");
            }
            if (second.Y < 0 || second.Y >= this.Height) {
                throw new ArgumentOutOfRangeException("second.Y");
            }

            GridTile firsttile = this.Tiles[first.X + first.Y * this.Width];
            GridTile secondtile = this.Tiles[second.X + second.Y * this.Width];

            this.Tiles[first.X + first.Y * this.Width] = secondtile;
            this.Tiles[second.X + second.Y * this.Width] = firsttile;
        }

        // Constructors
        public TileGrid(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.Tiles = new GridTile[width * height];
        }
    }
}
