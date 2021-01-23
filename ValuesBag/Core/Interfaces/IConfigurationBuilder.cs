namespace SpandBox.Core
{
    public interface IConfigurationBuilder
    {
        IValuesBagConfiguration<T> Entity<T>() where T : IEntityBase;
    }
}