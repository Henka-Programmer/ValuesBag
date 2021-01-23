using System;
using System.Collections.Generic;
using System.Linq;

namespace SpandBox.Core
{
    public abstract class ConfigurationBase : IConfiguration
    {
        public Type Type { get; private set; }
        protected virtual List<IConfiguration> _Configurations { get; set; }

        public virtual string Id { get; }

        public virtual IReadOnlyList<IConfiguration> Configurations => _Configurations;

        public ConfigurationBase(Type type)
        {
            _Configurations = new List<IConfiguration>();
            Type = type;
            Id = type.Name;
        }
        protected void AddConfiguration(IConfiguration configuration)
        {
            var cfg = _Configurations.FirstOrDefault(x => x.Id == configuration.Id);
            if (cfg != null)
            {
                _Configurations.Remove(cfg);
            }
            _Configurations.Add(configuration);
        }
    }
}
