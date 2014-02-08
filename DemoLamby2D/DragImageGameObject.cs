using Lamby2D;
using Lamby2D.Core;
using Lamby2D.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLamby2D
{
    class DragImageGameObject : ImageGameObject
    {
        // Variables
        Vector2 mouseoffset;

        // Properties
        public bool IsDragging { get; private set; }

        // Handlers
        private void DragImageGameObject_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.IsDragging = true;
            mouseoffset = Game.Current.Graphics.ScreenToWorld(e.Position) - this.Position;
        }
        private void DragImageGameObject_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.IsDragging = false;
        }

        // Public
        public override void Update(float DeltaTime)
        {
            if (this.IsDragging == true) {
                this.Position = Game.Current.Graphics.ScreenToWorld(Game.Current.Input.MousePosition) - mouseoffset;
            }
        }

        // Constructors
        public DragImageGameObject()
        {
            this.MouseDown += DragImageGameObject_MouseDown;
            this.MouseUp += DragImageGameObject_MouseUp;
        }
    }
}
