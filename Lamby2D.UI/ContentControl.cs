using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.UI
{
    public class ContentControl : Control
    {
        // Binding properties
        public static readonly BindingProperty ContentProperty =
            BindingProperty.Create(typeof(Control), typeof(ContentControl), null);

        // Properties
        public Control Content
        {
            get { return (Control) GetValue(ContentControl.ContentProperty); }
            set { SetValue(ContentControl.ContentProperty, value); }
        }
    }
}
