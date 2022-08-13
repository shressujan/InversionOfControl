namespace Service.ValueProvider
{
    public interface IValueProvider<TValue> where TValue : class
    {
        TValue? GetValue();
    }
}
