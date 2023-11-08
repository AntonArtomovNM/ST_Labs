using Lab2.Task3_Linq.EqualityComparers;
using Lab2.Task3_Linq.Models;

namespace Lab2.Task3_Linq;

public static class IEnumerableLinqExtentions
{
    private const char SpaceSymbol = ' ';
    private const string ColorGreen = "Green";
    private const string MarkBMW = "BMW";

    public static IEnumerable<string> GetElementsWithSpace(this IEnumerable<string> strings)
    {
        return strings
            .Where(s => s.Contains(SpaceSymbol));
    }

    public static IEnumerable<int> GetNegatives(this IEnumerable<int> ints)
    {
        return ints
            .Where(i => i < 0);
    }

    public static IEnumerable<string> GetGreenHues(this IEnumerable<string> colors)
    {
        return colors
            .Where(c => c.Contains(ColorGreen));
    }

    public static IEnumerable<Car> GetBMWCars(this IEnumerable<Car> cars)
    {
        return cars
            .Where(c => c.Maker.Equals(MarkBMW, StringComparison.InvariantCultureIgnoreCase));
    }

    public static IEnumerable<Product> GetRunOutProducts(this IEnumerable<Product> products)
    {
        return products
            .Where(p => p.Quantity == 0);
    }

    public static IEnumerable<string> GetCommonElements(this IEnumerable<string> strings1, IEnumerable<string> strings2)
    {
        return strings1
            .Intersect(strings2, new StringEqualityComparer());
    }
}
