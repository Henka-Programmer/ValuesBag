using System;
using System.Reflection;

namespace SpandBox.Core
{
    public class PrimitivePropertyConfiguration<T> : PrimitivePropertyConfiguration, IPrimitiveMemberOptions<T>
    {
        public PrimitivePropertyConfiguration(Type type, PropertyInfo propertyInfo) : base(type, propertyInfo)
        {
        } 
        public void Include(Func<T, bool> condition)
        {
            Func<object, bool> includeCondition = x => condition((T)x);
            Include(includeCondition);
        } 
    }

}
