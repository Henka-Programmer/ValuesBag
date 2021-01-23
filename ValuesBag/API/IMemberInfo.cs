using System.Reflection;
using SpandBox.Core;

namespace SpandBox
{
    public interface IMemberInfo : IMemberOptions
    {
        PropertyInfo PropertyInfo
        {
            get;
        }
        bool IsPrimitive
        {
            get;
        }
    }

}
