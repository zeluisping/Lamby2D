using Lamby2D.Core;
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
        // Variables
        Point? _selectedtile;

        // Properties
        public TileGridMap Map { get; set; }
        public Point? SelectedTile
        {
            get { return _selectedtile; }
            set
            {
                if (this.Map == null || value.Value.X < 0 || value.Value.Y < 0 || value.Value.X >= this.Map.Width || value.Value.Y >= this.Map.Height) {
                    value = null;
                }

                if (_selectedtile != value) {
                    _selectedtile = value;
                    if (this.SelectedTileChanged != null) {
                        this.SelectedTileChanged(this, _selectedtile);
                    }
                }
            }
        }

        // Events
        event EventHandler<Point> AddTile;
        event EventHandler<Point> RemoveTile;
        event EventHandler<Point?> SelectedTileChanged;

        // Protected
        protected override void Draw(Graphics g)
        {
            base.Draw(g);

            Viewport viewport = g.Viewport;
            g.Viewport = new Viewport(this.Position.X, this.Position.Y, this.Width, this.Height);
            if (this.Map != null) {
                this.Map.Draw(g);
            }
            g.Viewport = viewport;
        }
        protected override void OnMouseDown(Input.MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
        }

        // Constructors
        public TileGridMapEditor()
        {
        }
    }
}
