using Lab2.Task1_Extentions;

namespace Lab2_Tests.Task1_Extentions;

public class ArrayExtentionsTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 1, 2, 3, 8, 2, 2 }, 2, 4)]
    [InlineData(new int[] { 1, 1, 1, 1 }, 1, 4)]
    [InlineData(new int[] { }, 100000, 0)]
    public void CountElement_WhenInt_ShouldCountElementOccurrences(int[] array, int element, int expectedResult)
    {
        // Arrange

        // Act
        int actualResult = array.CountElement(element);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData(new string[] { "test", "another", "one more", "test", "also", "test" }, "test", 3)]
    [InlineData(new string[] { "Different Case", "different case", "DiFfErEnT cAsE" }, "different case", 1)]
    [InlineData(new string[] { }, "any", 0)]
    public void CountElement_WhenString_ShouldCountElementOccurrences(string[] array, string element, int expectedResult)
    {
        // Arrange

        // Act
        int actualResult = array.CountElement(element);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 1, 2, 3, 8, 2, 2 }, new int[] { 1, 2, 3, 8 })]
    [InlineData(new int[] { 1, 1, 1, 1 }, new int[] { 1 })]
    [InlineData(new int[] { }, new int[] { })]
    public void Distinct_WhenInt_ShouldReturnUniqueElementsOnly(int[] array, int[] expectedResult)
    {
        // Arrange

        // Act
        int[] actualResult = array.Distinct();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }
}
