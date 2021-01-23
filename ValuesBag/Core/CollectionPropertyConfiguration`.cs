using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SpandBox.Core
{
    public class CollectionPropertyConfiguration<T, Titem> : CollectionPropertyConfiguration, ICollectionMemberOptions<T, Titem>, IMemberConfiguration where Titem : class, IEntityBase
    {
        public CollectionPropertyConfiguration(PropertyInfo propertyInfo) : base(typeof(T), typeof(Titem), propertyInfo)
        {
        }

        public void Include(Func<Titem, bool> condition)
        {
            Func<object, bool> includeCondition = x => condition((Titem)x);
            Include(includeCondition);
        }
        public IValuesBagConfiguration<Titem> ForMember(Expression<Func<Titem, bool?>> exp, Action<IPrimitiveMemberOptions<Titem>> configure)
        {
            Configure(exp.GetPropertyInfo(), configure);
            return this;
        }

        public IValuesBagConfiguration<Titem> ForMember(Expression<Func<Titem, bool>> exp, Action<IPrimitiveMemberOptions<Titem>> configure)
        {
            Configure(exp.GetPropertyInfo(), configure);
            return this;
        }

        public IValuesBagConfiguration<Titem> ForMember(Expression<Func<Titem, DateTime?>> exp, Action<IPrimitiveMemberOptions<Titem>> configure)
        {
            Configure(exp.GetPropertyInfo(), configure);
            return this;
        }

        public IValuesBagConfiguration<Titem> ForMember(Expression<Func<Titem, DateTime>> exp, Action<IPrimitiveMemberOptions<Titem>> configure)
        {
            Configure(exp.GetPropertyInfo(), configure);
            return this;
        }

        public IValuesBagConfiguration<Titem> ForMember(Expression<Func<Titem, decimal?>> exp, Action<IPrimitiveMemberOptions<Titem>> configure)
        {
            Configure(exp.GetPropertyInfo(), configure);
            return this;
        }

        public IValuesBagConfiguration<Titem> ForMember(Expression<Func<Titem, double?>> exp, Action<IPrimitiveMemberOptions<Titem>> configure)
        {
            Configure(exp.GetPropertyInfo(), configure);
            return this;
        }
        protected void Configure(PropertyInfo propertyInfo, Action<IPrimitiveMemberOptions<Titem>> configure)
        {
            Configure<Titem>(typeof(Titem), propertyInfo, configure);
        }
        protected IValuesBagConfiguration<Titem> Configure(PropertyInfo propertyInfo, Action<ICollectionMemberOptions<T, Titem>> configure)
        {
            Configure<T, Titem>(typeof(T), typeof(Titem), propertyInfo, configure);
            return this;
        }

        public IValuesBagConfiguration<Titem> ForMember(Expression<Func<Titem, double>> exp, Action<IPrimitiveMemberOptions<Titem>> configure)
        {
            Configure(exp.GetPropertyInfo(), configure);
            return this;
        }

        public IValuesBagConfiguration<Titem> ForMember(Expression<Func<Titem, float>> exp, Action<IPrimitiveMemberOptions<Titem>> configure)
        {
            Configure(exp.GetPropertyInfo(), configure);
            return this;
        }

        public IValuesBagConfiguration<Titem> ForMember(Expression<Func<Titem, int?>> exp, Action<IPrimitiveMemberOptions<Titem>> configure)
        {
            Configure(exp.GetPropertyInfo(), configure);
            return this;
        }

        public IValuesBagConfiguration<Titem> ForMember(Expression<Func<Titem, int>> exp, Action<IPrimitiveMemberOptions<Titem>> configure)
        {
            Configure(exp.GetPropertyInfo(), configure);
            return this;
        }

        public IValuesBagConfiguration<Titem> ForMember(Expression<Func<Titem, long>> exp, Action<IPrimitiveMemberOptions<Titem>> configure)
        {
            Configure(exp.GetPropertyInfo(), configure);
            return this;
        }

        public IValuesBagConfiguration<Titem> ForMember(Expression<Func<Titem, string>> exp, Action<IPrimitiveMemberOptions<Titem>> configure)
        {
            Configure(exp.GetPropertyInfo(), configure);
            return this;
        }

        public IValuesBagConfiguration<Titem> ForMember<TNavigation>(Expression<Func<Titem, ICollection<TNavigation>>> exp, Action<ICollectionMemberOptions<Titem, TNavigation>> configure) where TNavigation : class, IEntityBase
        {
            Configure(typeof(T), typeof(TNavigation), exp.GetPropertyInfo(), configure);
            return this;
        }

        bool IMemberConfiguration.IsIgnored(object obj)
        {
            return IsIgnored(obj);
        }



        public IValuesBagConfiguration<Titem> ForMember<TProperty>(Expression<Func<Titem, TProperty>> exp, Action<IPrimitiveMemberOptions<Titem>> configure) where TProperty : struct
        {
            Configure(exp.GetPropertyInfo(), configure);
            return this;
        }

        public IValuesBagConfiguration<Titem> ForMember<TProperty>(Expression<Func<Titem, TProperty?>> exp, Action<IPrimitiveMemberOptions<Titem>> configure) where TProperty : struct
        {
            Configure(exp.GetPropertyInfo(), configure);
            return this;
        }

        public IValuesBagConfiguration<Titem> ForMember(Expression<Func<Titem, byte[]>> exp, Action<IPrimitiveMemberOptions<Titem>> configure)
        {
            Configure(exp.GetPropertyInfo(), configure);
            return this;
        }


        public IValuesBagConfiguration<Titem> ForAllMembers(Action<IMemberInfo> configure)
        {
            if (configure == null) throw new ArgumentNullException(nameof(configure));

            var propertiesInfos = typeof(Titem).GetProperties().Where(x => x.GetSetMethod() != null && x.GetIndexParameters()?.Count() == 0).ToArray();
            foreach (var p in propertiesInfos)
            {
                var memberInfo = new MemberInfo(typeof(Titem), p);
                configure(memberInfo);
                AddConfiguration(memberInfo);
            }
            return this;

        }


        //public ValuesBagConfiguration<Titem> ForMember(Expression<Func<T, Titem>> exp, Action<IMemberOptions<Titem>> configure)
        //{
        //    var valuesbag = new ValuesBagConfiguration<Titem>();
        //    AddConfiguration(valuesbag);
        //    valuesbag.ForMember(exp,configure);
        //    return valuesbag;
        //}

    }
}
