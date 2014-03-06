using Lamby2D.Core;
using Lamby2D.Drawing;
using Lamby2D.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.UI
{
    public class Control : BindingObject, IMouseAware
    {
        // Binding properties
        public static readonly BindingProperty ZIndexProperty =
            BindingProperty.Create(typeof(int), typeof(Control), 0);
        public static readonly BindingProperty IsHitTestVisibleProperty =
            BindingProperty.Create(typeof(bool), typeof(Control), true);
        public static readonly BindingProperty ParentProperty =
            BindingProperty.Create(typeof(Control), typeof(Control), null);
        public static readonly BindingProperty DataContextProperty =
            BindingProperty.Create(typeof(object), typeof(Control), null);
        public static readonly BindingProperty BackgroundProperty =
            BindingProperty.Create(typeof(Color), typeof(Control), Colors.White);
        public static readonly BindingProperty BorderColorProperty =
            BindingProperty.Create(typeof(Color), typeof(Control), Colors.Transparent);
        public static readonly BindingProperty BorderThicknessProperty =
            BindingProperty.Create(typeof(float), typeof(Control), 0.0f);
        public static readonly BindingProperty PositionProperty =
            BindingProperty.Create(typeof(Point), typeof(Control), Point.Zero);
        public static readonly BindingProperty WidthProperty =
            BindingProperty.Create(typeof(int), typeof(Control), 30);
        public static readonly BindingProperty HeightProperty =
            BindingProperty.Create(typeof(int), typeof(Control), 30);

        
        // Properties
        public int ZIndex
        {
            get { return (int) GetValue(Control.ZIndexProperty); }
            set { SetValue(Control.ZIndexProperty, value); }
        }
        public bool IsHitTestVisible
        {
            get { return (bool) GetValue(Control.IsHitTestVisibleProperty); }
            set { SetValue(Control.IsHitTestVisibleProperty, value); }
        }
        public Control Parent
        {
            get { return (Control) GetValue(Control.ParentProperty); }
            internal set { SetValue(Control.ParentProperty, value); }
        }
        [Obsolete("not implemented", true)]
        public object DataContext
        {
            get { return GetValue(Control.DataContextProperty); }
            set { SetValue(Control.DataContextProperty, value); }
        }
        public Color Background
        {
            get { return (Color) GetValue(Control.BackgroundProperty); }
            set { SetValue(Control.BackgroundProperty, value); }
        }
        public Color BorderColor
        {
            get { return (Color) GetValue(Control.BorderColorProperty); }
            set { SetValue(Control.BorderColorProperty, value); }
        }
        public float BorderThickness
        {
            get { return (float) GetValue(Control.BorderThicknessProperty); }
            set { SetValue(Control.BorderThicknessProperty, value); }
        }
        public Point Position
        {
            get { return (Point) GetValue(Control.PositionProperty); }
            set { SetValue(Control.PositionProperty, value); }
        }
        public int Width
        {
            get { return (int) GetValue(Control.WidthProperty); }
            set { SetValue(Control.WidthProperty, value); }
        }
        public int Height
        {
            get { return (int) GetValue(Control.HeightProperty); }
            set { SetValue(Control.HeightProperty, value); }
        }

        // Events
        public event MouseButtonEventHandler MouseDown;
        public event MouseButtonEventHandler MouseUp;
        public event MouseMotionEventHandler MouseEnter;
        public event MouseMotionEventHandler MouseLeave;

        // Public
        public virtual bool MouseHitTest(Point position)
        {
            return (position.X >= this.Position.X && position.X <= this.Position.X + this.Width &&
                    position.Y >= this.Position.Y && position.Y <= this.Position.Y + this.Height);
        }
        public virtual void OnMouseDown(MouseButtonEventArgs e)
        {
            if (this.MouseDown != null) {
                this.MouseDown(this, e);
            }
        }
        public virtual void OnMouseUp(MouseButtonEventArgs e)
        {
            if (this.MouseUp != null) {
                this.MouseUp(this, e);
            }
        }
        public virtual void OnMouseEnter(MouseMotionEventArgs e)
        {
            if (this.MouseEnter != null) {
                this.MouseEnter(this, e);
            }
        }
        public virtual void OnMouseLeave(MouseMotionEventArgs e)
        {
            if (this.MouseLeave != null) {
                this.MouseLeave(this, e);
            }
        }

        // Internal
        protected internal virtual void Draw(Graphics graphics)
        {
            graphics.DrawColor = this.Background;
            graphics.DrawRectangle(this.Position.Vector, 0, this.Width, this.Height);
            graphics.DrawColor = this.BorderColor;
            graphics.DrawRectangleBorder(this.Position.Vector, 0, this.Width, this.Height, this.BorderThickness);
        }

        // Constructors
        public Control()
        {
            this.IsHitTestVisible = true;
            this.Background = Colors.White;
            this.Width = 30;
            this.Height = 30;
        }
    }
}
