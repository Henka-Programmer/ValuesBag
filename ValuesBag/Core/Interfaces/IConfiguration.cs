using System;
using System.Collections.Generic;

namespace SpandBox.Core
{
    public interface IConfiguration
    {
        Type Type { get; }
        string Id { get; }
        IReadOnlyList<IConfiguration> Configurations { get; }
    }
}
