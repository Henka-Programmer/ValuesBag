using SpandBox.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions; 

namespace SpandBox
{
    public interface IValuesBagConfiguration<T> : IConfiguration
    {
        IValuesBagConfiguration<T> ForMember<TProperty>(Expression<Func<T, TProperty>> exp, Action<IPrimitiveMemberOptions<T>> configure) where TProperty : struct;
        IValuesBagConfiguration<T> ForMember<TProperty>(Expression<Func<T, TProperty?>> exp, Action<IPrimitiveMemberOptions<T>> configure) where TProperty : struct;
        IValuesBagConfiguration<T> ForMember(Expression<Func<T, bool?>> exp, Action<IPrimitiveMemberOptions<T>> configure);
        IValuesBagConfiguration<T> ForMember(Expression<Func<T, bool>> exp, Action<IPrimitiveMemberOptions<T>> configure);
        IValuesBagConfiguration<T> ForMember(Expression<Func<T, DateTime?>> exp, Action<IPrimitiveMemberOptions<T>> configure);
        IValuesBagConfiguration<T> ForMember(Expression<Func<T, DateTime>> exp, Action<IPrimitiveMemberOptions<T>> configure);
        IValuesBagConfiguration<T> ForMember(Expression<Func<T, decimal?>> exp, Action<IPrimitiveMemberOptions<T>> configure);
        IValuesBagConfiguration<T> ForMember(Expression<Func<T, double?>> exp, Action<IPrimitiveMemberOptions<T>> configure);
        IValuesBagConfiguration<T> ForMember(Expression<Func<T, double>> exp, Action<IPrimitiveMemberOptions<T>> configure);
        IValuesBagConfiguration<T> ForMember(Expression<Func<T, float>> exp, Action<IPrimitiveMemberOptions<T>> configure);
        IValuesBagConfiguration<T> ForMember(Expression<Func<T, int?>> exp, Action<IPrimitiveMemberOptions<T>> configure);
        IValuesBagConfiguration<T> ForMember(Expression<Func<T, int>> exp, Action<IPrimitiveMemberOptions<T>> configure);
        IValuesBagConfiguration<T> ForMember(Expression<Func<T, long>> exp, Action<IPrimitiveMemberOptions<T>> configure);
        IValuesBagConfiguration<T> ForMember(Expression<Func<T, string>> exp, Action<IPrimitiveMemberOptions<T>> configure);
        IValuesBagConfiguration<T> ForMember(Expression<Func<T, byte[]>> exp, Action<IPrimitiveMemberOptions<T>> configure);
        IValuesBagConfiguration<T> ForMember<TNavigation>(Expression<Func<T, ICollection<TNavigation>>> exp, Action<ICollectionMemberOptions<T, TNavigation>> configure) where TNavigation : class, IEntityBase;

        IValuesBagConfiguration<T> ForAllMembers(Action<IMemberInfo> configure);
    }
}