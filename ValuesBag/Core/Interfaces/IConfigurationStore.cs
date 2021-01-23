namespace SpandBox.Core
{
    public interface IConfigurationStore
    {
        ValuesBagConfiguration<T> Configuration<T>() where T : IEntityBase;
    }
}