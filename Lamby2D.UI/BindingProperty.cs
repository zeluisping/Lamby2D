using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.UI
{
    public class BindingProperty
    {
        // Public static
        public static BindingProperty Create(Type type, Type owner)
        {
            return BindingProperty.Create(type, owner, (type.IsValueType == true ? Activator.CreateInstance<Type>() : null));
        }
        public static BindingProperty Create(Type type, Type owner, object defaultvalue)
        {
            return new BindingProperty() {
                PropertyType = type,
                OwnerType = owner,
                DefaultValue = defaultvalue
            };
        }

        // Properties
        public Type PropertyType { get; private set; }
        public Type OwnerType { get; private set; }
        public object DefaultValue { get; private set; }

        // Constructors
        private BindingProperty()
        {
        }
    }
}
