using System;
using System.Collections.Generic;
using System.Reflection;

namespace SpandBox.Core
{

    public class PrimitivePropertyConfiguration : IPropertyConfiguration, IMemberOptions, IMemberConfiguration
    {
        public PropertyInfo PropertyInfo { get; private set; }

        public Type Type { get; private set; }

        public string Id { get => $"{Type.Name}-{PropertyInfo.Name}"; }

        public IReadOnlyList<IConfiguration> Configurations { get => null; }

        public PrimitivePropertyConfiguration(Type type, PropertyInfo propertyInfo)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (propertyInfo == null) throw new ArgumentNullException(nameof(propertyInfo));

            Type = type;
            PropertyInfo = propertyInfo;
        }
        private bool isIgnored = false;

        public virtual void Ignore()
        {
            if (_Condition != null)
            {
                throw new InvalidOperationException("Shouldn't combine Ignore and Include(Condition)");
            }
            isIgnored = true;
        }

        protected virtual bool IsIgnored(object obj)
        {
            return _Condition != null ? !_Condition(obj) : isIgnored;
        }

        bool IMemberConfiguration.IsIgnored(object obj)
        {
            return IsIgnored(obj);
        }

        private Func<object, bool> _Condition;
        public virtual void Include(Func<object, bool> condition)
        {
            _Condition = condition;
        }

        public virtual void Include()
        {
            _Condition = null;
            isIgnored = false;
        }

    }
}
