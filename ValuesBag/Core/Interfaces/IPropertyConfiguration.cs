using System;
using System.Reflection;

namespace SpandBox.Core
{
    public interface IPropertyConfiguration : IConfiguration
    {
        PropertyInfo PropertyInfo { get; }
    }
}
