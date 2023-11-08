namespace Lab2.Task1_Extentions;

public static class StringExtentions
{
    public static string Invert(this string value)
    {
        return new string(value.Reverse().ToArray());
    }

    public static int CountSymbol(this string value, char symbol)
    {
        return value
            .Where(c => c == symbol)
            .Count();
    }
}
