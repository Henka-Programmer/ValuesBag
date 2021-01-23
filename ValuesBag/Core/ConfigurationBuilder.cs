using System.Collections.Generic;
using System.Linq;

namespace SpandBox.Core
{
    public class ConfigurationBuilder : IConfigurationBuilder, IConfigurationStore
    {
        private readonly IList<ValuesBagConfiguration> configurations = new List<ValuesBagConfiguration>();
        public IValuesBagConfiguration<T> Entity<T>() where T : IEntityBase
        {
            var cfg = new ValuesBagConfiguration<T>();
            var exists = configurations.FirstOrDefault(x => x.Id == cfg.Id);
            if (exists != null)
            {
                return (ValuesBagConfiguration<T>)exists;
            }
            configurations.Add(cfg);
            return cfg;
        }

        ValuesBagConfiguration<T> IConfigurationStore.Configuration<T>()
        {
            return (ValuesBagConfiguration<T>)configurations.FirstOrDefault(x => x.Type == typeof(T));
        }
    }
}
