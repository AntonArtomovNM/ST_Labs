namespace Lab2.Task1_Extentions;

public static class ArrayExtentions
{
    public static int CountElement<T>(this T[] array, T element)
    {
        return array
            .Where(x => EqualityComparer<T>.Default.Equals(x, element))
            .Count();
    }

    public static T[] Distinct<T>(this T[] array)
    {
        var resut = new List<T>();

        foreach (var x in array)
        {
            if (!resut.Contains(x))
            {
                resut.Add(x);
            }
        }

        return resut.ToArray();
    }
}
