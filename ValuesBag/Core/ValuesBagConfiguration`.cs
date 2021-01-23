using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions; 
using System.Reflection;

namespace SpandBox.Core
{

    public class ValuesBagConfiguration<T> : ValuesBagConfiguration, IValuesBagConfiguration<T> where T : IEntityBase
    {
        public ValuesBagConfiguration() : base(typeof(T))
        {
            ForMember(x => x.Id, opt => opt.Include(x => x.Id > 0));
            ForMember(x => x.CreatedAt, opt => opt.Ignore());
            ForMember(x => x.UpdatedAt, opt => opt.Ignore());
        }

        public IValuesBagConfiguration<T> ForMember(Expression<Func<T, int?>> exp, Action<IPrimitiveMemberOptions<T>> configure)
        {
            return ForMember(exp.GetPropertyInfo(), configure);
        }

        public IValuesBagConfiguration<T> ForMember(Expression<Func<T, bool?>> exp, Action<IPrimitiveMemberOptions<T>> configure)
        {
            return ForMember(exp.GetPropertyInfo(), configure);
        }

        public IValuesBagConfiguration<T> ForMember(Expression<Func<T, bool>> exp, Action<IPrimitiveMemberOptions<T>> configure)
        {
            return ForMember(exp.GetPropertyInfo(), configure);
        }

        private IValuesBagConfiguration<T> ForMember(PropertyInfo propertyInfo, Action<IPrimitiveMemberOptions<T>> configure)
        {
            Configure(propertyInfo, (x) => configure((IPrimitiveMemberOptions<T>)x));
            return this;
        }

        protected void Configure(PropertyInfo propertyInfo, Action<IPrimitiveMemberOptions<T>> configure)
        {
            Configure<T>(typeof(T), propertyInfo, configure);
        }
        protected void Configure<Titem>(PropertyInfo propertyInfo, Action<ICollectionMemberOptions<T, Titem>> configure) where Titem : class, IEntityBase
        {
            Configure(typeof(T), typeof(Titem), propertyInfo, configure);
        }

        private ValuesBagConfiguration<T> ForMember<Titem>(PropertyInfo propertyInfo, Action<ICollectionMemberOptions<T, Titem>> configure) where Titem : class, IEntityBase
        {
            Configure(propertyInfo, configure);
            return this;
        }

        public IValuesBagConfiguration<T> ForMember(Expression<Func<T, int>> exp, Action<IPrimitiveMemberOptions<T>> configure)
        {
            return ForMember(exp.GetPropertyInfo(), configure);
        }

        public IValuesBagConfiguration<T> ForMember(Expression<Func<T, Int64>> exp, Action<IPrimitiveMemberOptions<T>> configure)
        {
            return ForMember(exp.GetPropertyInfo(), configure);
        }

        public IValuesBagConfiguration<T> ForMember(Expression<Func<T, DateTime>> exp, Action<IPrimitiveMemberOptions<T>> configure)
        {
            return ForMember(exp.GetPropertyInfo(), configure);
        }

        public IValuesBagConfiguration<T> ForMember(Expression<Func<T, DateTime?>> exp, Action<IPrimitiveMemberOptions<T>> configure)
        {
            return ForMember(exp.GetPropertyInfo(), configure);
        }
        public IValuesBagConfiguration<T> ForMember(Expression<Func<T, double>> exp, Action<IPrimitiveMemberOptions<T>> configure)
        {
            return ForMember(exp.GetPropertyInfo(), configure);
        }

        public IValuesBagConfiguration<T> ForMember(Expression<Func<T, double?>> exp, Action<IPrimitiveMemberOptions<T>> configure)
        {
            return ForMember(exp.GetPropertyInfo(), configure);
        }
        public IValuesBagConfiguration<T> ForMember(Expression<Func<T, decimal?>> exp, Action<IPrimitiveMemberOptions<T>> configure)
        {
            return ForMember(exp.GetPropertyInfo(), configure);
        }

        public IValuesBagConfiguration<T> ForMember(Expression<Func<T, string>> exp, Action<IPrimitiveMemberOptions<T>> configure)
        {
            return ForMember(exp.GetPropertyInfo(), configure);
        }
        public IValuesBagConfiguration<T> ForMember(Expression<Func<T, float>> exp, Action<IPrimitiveMemberOptions<T>> configure)
        {
            return ForMember(exp.GetPropertyInfo(), configure);
        }

        public IValuesBagConfiguration<T> ForMember<TNavigation>(Expression<Func<T, ICollection<TNavigation>>> exp, Action<ICollectionMemberOptions<T, TNavigation>> configure) where TNavigation : class, IEntityBase
        {
            return ForMember(exp.GetPropertyInfo(), configure);
        }

        public IValuesBagConfiguration<T> ForMember<TProperty>(Expression<Func<T, TProperty>> exp, Action<IPrimitiveMemberOptions<T>> configure) where TProperty : struct
        {
            return ForMember(exp.GetPropertyInfo(), configure);
        }

        public IValuesBagConfiguration<T> ForMember<TProperty>(Expression<Func<T, TProperty?>> exp, Action<IPrimitiveMemberOptions<T>> configure) where TProperty : struct
        {
            return ForMember(exp.GetPropertyInfo(), configure);
        }

        public IValuesBagConfiguration<T> ForMember(Expression<Func<T, byte[]>> exp, Action<IPrimitiveMemberOptions<T>> configure)
        {
            return ForMember(exp.GetPropertyInfo(), configure);
        }

        public IValuesBagConfiguration<T> ForAllMembers(Action<IMemberInfo> configure)
        {
            if (configure == null) throw new ArgumentNullException(nameof(configure));

            var propertiesInfos = typeof(T).GetProperties().Where(x => x.GetSetMethod() != null && x.GetIndexParameters()?.Count() == 0).ToArray();
            foreach (var p in propertiesInfos)
            {
                var memberInfo = new MemberInfo(typeof(T), p);
                configure(memberInfo);
                AddConfiguration(memberInfo);
            }
            return this;

        }

    }

}
