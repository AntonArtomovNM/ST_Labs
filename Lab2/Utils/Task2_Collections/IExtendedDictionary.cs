namespace Lab2.Task2_Collections;

public interface IExtendedDictionary<T, U, V> : IEnumerable<ExtendedDictionaryElement<T, U, V>>
{
    ExtendedDictionaryElement<T, U, V> this[T key] { get; }

    int Count { get; }

    void Add(T key, U value1, V value2);

    void Add(ExtendedDictionaryElement<T, U, V> element);

    bool Remove(T key);

    bool HasKey(T key);

    bool HasValue(U value1, V value2);
}
