using SpandBox.Core;
using System;

namespace SpandBox
{
    public interface IPrimitiveMemberOptions<T> : IMemberOptions
    {
        void Include(Func<T, bool> condition);
    }
}
