namespace Service.ValueProvider
{
    public interface IValueProviderForceUpdate<TValue> : IValueProvider<TValue> where TValue : class
    {
        Task UpdateValue();
    }
}
