using System;
using System.Reflection;
using SpandBox.Core;

namespace SpandBox
{
    public class MemberInfo : PrimitivePropertyConfiguration, IMemberInfo
    {
        public bool IsPrimitive { get; private set; }
        public MemberInfo(Type ownerType, PropertyInfo propertyInfo) : base(ownerType, propertyInfo)
        { 
            Type pType = PropertyInfo.PropertyType;
            pType = Nullable.GetUnderlyingType(pType) ?? pType;

            if (!pType.IsClass || pType == typeof(string) || pType.IsEnum || !pType.IsGenericType)
            {
                IsPrimitive = true;
            }
            else
            {
                IsPrimitive = false;
            }
        }
    }

}
