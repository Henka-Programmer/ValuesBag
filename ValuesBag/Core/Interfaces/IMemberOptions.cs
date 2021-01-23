using System;

namespace SpandBox.Core
{
    public interface IMemberOptions
    {
        void Ignore();
        void Include(Func<object,bool> condition);
        void Include();
    }
}
