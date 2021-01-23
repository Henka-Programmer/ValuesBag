using System;
using System.Reflection;

namespace SpandBox.Core
{
    public class ValuesBagConfiguration : ConfigurationBase
    {
        protected ValuesBagConfiguration(Type type) : base(type)
        { 
        }

        protected virtual void Configure<T>(Type type, PropertyInfo propertyInfo, Action<IPrimitiveMemberOptions<T>> configure)
        {
            var cfg = new PrimitivePropertyConfiguration<T>(type, propertyInfo);
            configure(cfg);
            AddConfiguration(cfg);
        }
        protected virtual void Configure<T, Titem>(Type type, Type itemType, PropertyInfo propertyInfo, Action<ICollectionMemberOptions<T, Titem>> configure) where Titem : class, IEntityBase
        {
            var cfg = new CollectionPropertyConfiguration<T, Titem>(propertyInfo); 
            configure(cfg);
            AddConfiguration(cfg);
        }

    }
}
