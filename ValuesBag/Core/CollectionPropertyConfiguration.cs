using System;
using System.Reflection;

namespace SpandBox.Core
{
    public class CollectionPropertyConfiguration : ValuesBagConfiguration, IPropertyConfiguration, ICollectionMemberOptions, IMemberConfiguration
    {
        protected Type ItemType { get; private set; }
        public CollectionPropertyConfiguration(Type type, Type itemType, PropertyInfo propertyInfo) : base(type)
        {
            ItemType = itemType;
            PropertyInfo = propertyInfo;
        }
        public override string Id => $"{Type?.Name}-[{PropertyInfo?.Name}]";

        public bool MapLinks { get; set; }
        public bool MapCreateAndUpdate { get; set; }

        public PropertyInfo PropertyInfo { get; private set; }

        private bool isIgnored = false;
        public virtual void Ignore()
        {
            if (includeCondition != null)
            {
                throw new InvalidOperationException("Couldn't Combine both Include Condition and Ignore!");
            }
            isIgnored = true;
        }
        private Func<object, bool> includeCondition;
        public virtual void Include(Func<object, bool> condition)
        {
            includeCondition = condition;
        }

        public virtual void Include()
        {
            includeCondition = null;
            isIgnored = false;
        }

        bool IMemberConfiguration.IsIgnored(object obj)
        {
            return IsIgnored(obj);
        }

        protected virtual bool IsIgnored(object obj)
        {
            return includeCondition != null ? !includeCondition(obj) : isIgnored;
        }
    }
}
