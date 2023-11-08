using System.Diagnostics.CodeAnalysis;

namespace Lab2.Task3_Linq.EqualityComparers;

internal class StringEqualityComparer : IEqualityComparer<string>
{
    public bool Equals(string? x, string? y)
    {
        return x?.Equals(y, StringComparison.InvariantCultureIgnoreCase)
            ?? x is null && y is null;
    }

    public int GetHashCode([DisallowNull] string obj)
    {
        return obj.GetHashCode();
    }
}
