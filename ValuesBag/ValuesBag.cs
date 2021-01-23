using SpandBox.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace SpandBox
{
    [DataContract]
    [KnownType(typeof(ValuesBag))]
    [KnownType(typeof(ValuesBag[]))]
    [KnownType(typeof(string[]))]
    public class ValuesBag
    {
        public ValuesBag()
        {

        }
        private static ValuesBag Create(object entity, ConfigurationBase configuration)
        {
            var entityType = entity.GetType();
            var type = entityType;
            if (Nullable.GetUnderlyingType(entityType) != null)
            {
                type = Nullable.GetUnderlyingType(entityType);
            }
            else if (entityType.IsGenericType)
            {
                type = entityType.GetGenericArguments().FirstOrDefault();
            }

            var result = new ValuesBag(type);
            var propertiesInfos = type.GetProperties().Where(x => x.GetSetMethod() != null && x.GetIndexParameters()?.Count() == 0).ToArray();

            foreach (var pInfo in propertiesInfos)
            {
                var c = configuration.Configurations.FirstOrDefault(x => x.Id == $"{type.Name}-{pInfo.Name}" || x.Id == $"{type.Name}-[{pInfo.Name}]");
                if (c == null)
                {
                    if ((pInfo.PropertyType.IsClass && pInfo.PropertyType != typeof(string) && !pInfo.PropertyType.IsEnum) || (pInfo.PropertyType.IsGenericType && pInfo.PropertyType.GetGenericArguments()[0].IsClass && pInfo.PropertyType.GetGenericArguments()[0] != typeof(string) && !pInfo.PropertyType.GetGenericArguments()[0].IsEnum))
                    {
                        // by default ignore all complex navigation properties
                        continue;
                    }

                    result[pInfo.Name] = pInfo.GetValue(entity);
                }
                else if (c is ICollectionMemberOptions copt && !((IMemberConfiguration)c).IsIgnored(entity))
                {
                    var value = pInfo.GetValue(entity);
                    if (value == null || (!copt.MapLinks && !copt.MapCreateAndUpdate))
                    {
                        result[pInfo.Name] = null;
                        continue;
                    }

                    if (!copt.MapCreateAndUpdate && copt.MapLinks)
                    {
                        // grab only ids
                        var ids = new List<ValuesBag>();
                        var idProperty = typeof(IEntityBase).GetProperty(nameof(IEntityBase.Id));
                        var coll = value as ICollection;
                        foreach (var item in coll)
                        {
                            ids.Add(new ValuesBag(item.GetType())
                            {
                                [nameof(IEntityBase.Id)] = (int)idProperty.GetValue(item)
                            });
                        }
                        result[pInfo.Name] = ids.ToArray();
                    }
                    else if (copt is ValuesBagConfiguration cfg)
                    {
                        var bags = new List<ValuesBag>();
                        var coll = value as ICollection;
                        foreach (var o in coll)
                        {
                            bags.Add(Create(o, cfg));
                        }
                        result[pInfo.Name] = bags.ToArray();
                    };
                }
                else if (c is ConfigurationBase cfg && c is IPropertyConfiguration pcfg && !((IMemberConfiguration)c).IsIgnored(entity))
                {
                    var value = pInfo.GetValue(entity);
                    if (value != null)
                    {
                        result[pInfo.Name] = Create(value, cfg);
                    }
                    else
                    {
                        result[pInfo.Name] = null;
                    }
                    continue;
                }
                else if (c is IMemberOptions pc && !((IMemberConfiguration)c).IsIgnored(entity))
                {
                    result[pInfo.Name] = pInfo.GetValue(entity);
                }
            }

            return result;
        }
        public static ValuesBag Create<T>(T entity, Action<ValuesBagConfiguration<T>> cfg) where T : IEntityBase
        {

            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            var configuration = new ValuesBagConfiguration<T>();
            cfg?.Invoke(configuration);
            return Create(entity, configuration);
        }

        public static ValuesBag Create<T>(T entity, ConfigurationBuilder builder) where T : IEntityBase
        {
            return Create(entity, ((IConfigurationStore)builder).Configuration<T>());
        }
        public static ValuesBag Create<T>(T entity, ValuesBagConfiguration<T> configuration) where T : IEntityBase
        {
            return Create((object)entity, configuration);
        }

        [DataMember]
        public string Model { get; private set; }

        [DataMember]
        public Dictionary<string, object> Entries { get; private set; } = null;

        public object this[string key]
        {
            get => Entries[key];
            set => Entries[key] = value;
        }

        public ValuesBag(Type type)
        {
            Entries = new Dictionary<string, object>();
            Model = type.FullName;
        }


        public ValuesBag(Dictionary<string, object> valuesDict)
        {
            Entries = valuesDict;
        }

        public ValuesBag(Type type, Dictionary<string, object> valuesDict) : this(valuesDict)
        {
            Model = type.FullName;
        }
    }
}
