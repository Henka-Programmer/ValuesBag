namespace SpandBox.Core
{
    public interface ICollectionMemberOptions : IMemberOptions
    {
        bool MapLinks { get; set; }
        bool MapCreateAndUpdate { get; set; }
    }
}
