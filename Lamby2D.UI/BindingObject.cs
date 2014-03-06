using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.UI
{
    public class BindingObject
    {
        // Variables
        Dictionary<BindingProperty, object> _bpvalues;

        // Events
        public event EventHandler<BindingProperty> PropertyChanged;

        // Public
        public object GetValue(BindingProperty property)
        {
            if (_bpvalues.ContainsKey(property) == false) {
                _bpvalues[property] = property.DefaultValue;
                return property.DefaultValue;
            }
            return _bpvalues[property];
        }
        public void SetValue(BindingProperty property, object value)
        {
            object oldvalue = GetValue(property);
            _bpvalues[property] = value;
            if (this.PropertyChanged != null && oldvalue != value) {
                this.PropertyChanged(this, property);
            }
        }

        // Constructors
        public BindingObject()
        {
            _bpvalues = new Dictionary<BindingProperty, object>();
        }
    }
}
