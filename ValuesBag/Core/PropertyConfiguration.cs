using System;
using System.Reflection;

namespace SpandBox.Core
{
    public abstract class PropertyConfiguration : ConfigurationBase, IPropertyConfiguration
    {
        public PropertyConfiguration(Type type, PropertyInfo propertyInfo) : base(type)
        {
            PropertyInfo = propertyInfo;
        }

        public PropertyInfo PropertyInfo { get; private set; }
    }
}
