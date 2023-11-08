using Lab2.Task1_Extentions;

namespace Lab2_Tests.Task1_Extentions;

public class StringExtentionsTests
{
    [Theory]
    [InlineData("AbC", "CbA")]
    [InlineData("༼ つ ◕_◕ ༽つ", "つ༽ ◕_◕ つ ༼")]
    [InlineData("", "")]
    public void Invert_ShouldInvertString(string initial, string expectedResult)
    {
        // Arrange

        // Act
        string actualResult = initial.Invert();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData("test", 't', 2)]
    [InlineData("another", 'a', 1)]
    [InlineData("last one", '_', 0)]
    public void CountSymbol_ShouldCountSymbolOccurrences(string str, char symbol, int expectedResult)
    {
        // Arrange

        // Act
        int actualResult = str.CountSymbol(symbol);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }
}