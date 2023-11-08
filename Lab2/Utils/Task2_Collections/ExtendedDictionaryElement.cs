namespace Lab2.Task2_Collections;

public record ExtendedDictionaryElement<T, U, V>
{
    public T Key { get; }
    public U Value1 { get; }
    public V Value2 { get; }

    public ExtendedDictionaryElement(T key, U value1, V value2)
    {
        if (key is null)
        {
            throw new ArgumentNullException(nameof(key));
        }

        Key = key;
        Value1 = value1;
        Value2 = value2;
    }
};