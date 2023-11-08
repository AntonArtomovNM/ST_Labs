using System.Collections;

namespace Lab2.Task2_Collections;

public class ExtendedDictionary<T, U, V> : IExtendedDictionary<T, U, V>
{
    private const int BucketCount = 4;
    private readonly List<List<ExtendedDictionaryElement<T, U, V>>> _buckets = new List<List<ExtendedDictionaryElement<T, U, V>>>(BucketCount);

    public ExtendedDictionaryElement<T, U, V> this[T key]
    {
        get
        {
            if (key is null)
            {
                throw new ArgumentNullException("key");
            }

            var element = GetByKey(key);

            if (element is null)
            {
                throw new KeyNotFoundException();
            }

            return element;
        }
    }

    public int Count { get; private set; }

    public ExtendedDictionary()
    {
        for (var i = 0; i < BucketCount; i++)
        {
            _buckets.Add(new List<ExtendedDictionaryElement<T, U, V>>());
        }
    }

    public ExtendedDictionary(IEnumerable<ExtendedDictionaryElement<T, U, V>> elements)
        : this()
    {
        if (elements is null)
        {
            throw new ArgumentNullException(nameof(elements));
        }

        foreach (var element in elements)
        {
            Add(element);
        }
    }

    public void Add(T key, U value1, V value2)
    {
        var element = new ExtendedDictionaryElement<T, U, V>(key, value1, value2);

        Add(element);
    }

    public void Add(ExtendedDictionaryElement<T, U, V> element)
    {
        if (element is null)
        {
            throw new ArgumentNullException(nameof(element));
        }

        var key = element.Key;

        if (key is null)
        {
            throw new ArgumentException("Key is null", nameof(key));
        }

        if (HasKey(key))
        {
            throw new ArgumentException("Key already exists", nameof(key));
        }

        var bucket = GetBucket(key);
        bucket.Add(element);

        Count++;
    }

    public bool HasKey(T key)
    {
        if (key is null)
        {
            throw new ArgumentNullException(nameof(key));
        }

        var bucket = GetBucket(key);

        return bucket
            .Any(x => EqualityComparer<T>.Default.Equals(x.Key, key));
    }

    public bool HasValue(U value1, V value2)
    {
        return _buckets
            .Any(b => 
                b.Any(x => EqualityComparer<U>.Default.Equals(x.Value1, value1) && EqualityComparer<V>.Default.Equals(x.Value2, value2)));
    }

    public bool Remove(T key)
    {
        if (key is null)
        {
            throw new ArgumentException("Key is null", nameof(key));
        }

        var bucket = GetBucket(key);
        var element = bucket.SingleOrDefault(x => EqualityComparer<T>.Default.Equals(x.Key, key));

        if (element is null)
        {
            return false;
        }

        return bucket.Remove(element);
    }

    public IEnumerator<ExtendedDictionaryElement<T, U, V>> GetEnumerator()
    {
        return _buckets
            .SelectMany(x => x)
            .GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private List<ExtendedDictionaryElement<T, U, V>> GetBucket(T key)
    {
        var hash = Math.Abs(key.GetHashCode());
        return _buckets[hash % BucketCount];
    }

    private ExtendedDictionaryElement<T, U, V>? GetByKey(T key)
    {
        var bucket = GetBucket(key);

        return bucket
            .SingleOrDefault(x => EqualityComparer<T>.Default.Equals(x.Key, key));
    }
}
