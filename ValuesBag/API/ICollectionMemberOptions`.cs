using SpandBox.Core;
using System;

namespace SpandBox
{
    public interface ICollectionMemberOptions<T, Titem> : ICollectionMemberOptions, IValuesBagConfiguration<Titem> where Titem : class, IEntityBase
    {
        void Include(Func<Titem, bool> condition);
    }
}
