using Lab2.Task2_Collections;

namespace Lab2_Tests.Task2_Collections;

public class ExtendedDictionaryTests
{
    private static readonly IEnumerable<ExtendedDictionaryElement<int, string, string>> _testDataWithDuplicatedKeys;
    private static readonly IEnumerable<ExtendedDictionaryElement<int, string, string>> _testDataWithoutDuplicates;
    private static readonly IEnumerable<ExtendedDictionaryElement<string, string, string>> _testDataWithoutDuplicatesString;
    private static readonly IEnumerable<ExtendedDictionaryElement<int, string, string>> _testDataEmpty;

    public static IEnumerable<object[]> ValidConstructorTestData => new List<object[]>
    {
        new object[] { _testDataWithoutDuplicates },
        new object[] { _testDataEmpty }
    };

    public static IEnumerable<object[]> InvalidConstructorTestData => new List<object[]>
    {
        new object[] { _testDataWithDuplicatedKeys }
    };

    public static IEnumerable<object[]> HasKeyTestData => new List<object[]>
    {
        new object[] { _testDataWithoutDuplicates, 1, true },
        new object[] { _testDataWithoutDuplicates, 100, false }
    };

    static ExtendedDictionaryTests()
    {
        _testDataWithDuplicatedKeys = new List<ExtendedDictionaryElement<int, string, string>>
        {
            new ExtendedDictionaryElement<int, string, string>(1, "duplicate", "one"),
            new ExtendedDictionaryElement<int, string, string>(5, "unique", "value"),
            new ExtendedDictionaryElement<int, string, string>(0, "another", "value"),
            new ExtendedDictionaryElement<int, string, string>(2, "duplicate", "one"),
            new ExtendedDictionaryElement<int, string, string>(1, "duplicate", "two"),
            new ExtendedDictionaryElement<int, string, string>(2, "duplicate", "two"),
            new ExtendedDictionaryElement<int, string, string>(3, "not", "a duplicate"),
            new ExtendedDictionaryElement<int, string, string>(-7, "not", "a duplicate"),
            new ExtendedDictionaryElement<int, string, string>(10000, "not", "a duplicate"),
        };

        _testDataWithoutDuplicatesString = new List<ExtendedDictionaryElement<string, string, string>>
        {
            new ExtendedDictionaryElement<string, string, string>("2", "duplicate", "one"),
            new ExtendedDictionaryElement<string, string, string>("-1", "unique", "value"),
            new ExtendedDictionaryElement<string, string, string>("3", "another", "value"),
            new ExtendedDictionaryElement<string, string, string>("0113", "duplicate", "one"),
            new ExtendedDictionaryElement<string, string, string>("-", "duplicate", "two"),
            new ExtendedDictionaryElement<string, string, string>("+", "duplicate", "two"),
            new ExtendedDictionaryElement<string, string, string>("[]", "not", "a duplicate"),
            new ExtendedDictionaryElement<string, string, string>("121", "not", "a duplicate"),
            new ExtendedDictionaryElement<string, string, string>("/", "not", "a duplicate"),
        };

        _testDataWithoutDuplicates = new List<ExtendedDictionaryElement<int, string, string>>
        {
            new ExtendedDictionaryElement<int, string, string>(1, "duplicate", "one"),
            new ExtendedDictionaryElement<int, string, string>(5, "unique", "value"),
            new ExtendedDictionaryElement<int, string, string>(0, "another", "value"),
            new ExtendedDictionaryElement<int, string, string>(2, "duplicate", "one"),
            new ExtendedDictionaryElement<int, string, string>(3, "not", "a duplicate"),
            new ExtendedDictionaryElement<int, string, string>(-7, "not", "a duplicate"),
            new ExtendedDictionaryElement<int, string, string>(10000, "not", "a duplicate"),
        };

        _testDataEmpty = new List<ExtendedDictionaryElement<int, string, string>>();
    }

    [Fact]
    public void ParameterlessConstructor_ShouldCreateAnEmptyCollection()
    {
        // Arrange

        // Act
        var actualCollection = new ExtendedDictionary<Guid, int, string>();

        // Assert
        Assert.Empty(actualCollection);
    }


    [Theory]
    [MemberData(nameof(ValidConstructorTestData))]
    public void ParameterizedConstructor_ShouldCreateAnCollectionOfElements(IEnumerable<ExtendedDictionaryElement<int, string, string>> elements)
    {
        // Arrange
        var expectedCount = elements.Count();

        // Act
        var actualCollection = new ExtendedDictionary<int, string, string>(elements);
        var actualCount = actualCollection.Count();

        // Assert
        Assert.Equal(expectedCount, actualCount);

        foreach (var element in elements)
        {
            Assert.Contains(element, actualCollection);
        }
    }

    [Theory]
    [MemberData(nameof(InvalidConstructorTestData))]
    public void ParameterizedConstructor_WhenDuplicatedKeyEncountered_ShouldThrowError(IEnumerable<ExtendedDictionaryElement<int, string, string>> elements)
    {
        // Arrange

        // Act
        var result = () => new ExtendedDictionary<int, string, string>(elements);

        // Assert
        Assert.Throws<ArgumentException>(result);
    }

    [Theory]
    [MemberData(nameof(ValidConstructorTestData))]
    public void Count_ShouldReturnCorrectCount(IEnumerable<ExtendedDictionaryElement<int, string, string>> elements)
    {
        // Arrange
        var expectedCount = elements.Count();
        var collection = new ExtendedDictionary<int, string, string>(elements);

        // Act
        var actualCount = collection.Count;

        // Assert
        Assert.Equal(expectedCount, actualCount);
    }

    [Fact]
    public void Add_ShouldAddElementToCollection()
    {
        // Arrange
        var collection = new ExtendedDictionary<int, string, string>(_testDataWithoutDuplicates);
        var intialCount = collection.Count();
        var element = new ExtendedDictionaryElement<int, string, string>(100, "test", "data");

        // Act
        collection.Add(element);
        var newCount = collection.Count();

        // Assert
        Assert.Equal(intialCount + 1, newCount);
        Assert.Contains(element, collection);
    }

    [Fact]
    public void Add_WhenElementNull_ShouldThrowError()
    {
        // Arrange
        var collection = new ExtendedDictionary<int, string, string>(_testDataWithoutDuplicates);

        // Act
        var result = () => collection.Add(null);

        // Assert
        Assert.Throws<ArgumentNullException>(result);
    }

    [Fact]
    public void Add_WhenKeyExists_ShouldThrowError()
    {
        // Arrange
        var collection = new ExtendedDictionary<int, string, string>(_testDataWithoutDuplicates);
        var element = new ExtendedDictionaryElement<int, string, string>(1, "test", "data");

        // Act
        var result = () => collection.Add(element);

        // Assert
        Assert.Throws<ArgumentException>(result);
    }


    [Theory]
    [MemberData(nameof(HasKeyTestData))]
    public void HasKey_ShouldFindKey(IEnumerable<ExtendedDictionaryElement<int, string, string>> elements, int key, bool expectedResult)
    {
        // Arrange
        var collection = new ExtendedDictionary<int, string, string>(elements);

        // Act
        bool actualResult = collection.HasKey(key);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void HasKey_WhenKeyIsNull_ShouldThrowError()
    {
        // Arrange
        var collection = new ExtendedDictionary<string, string, string>(_testDataWithoutDuplicatesString);

        // Act
        var result = () =>
        {
            collection.HasKey(null);
        };

        // Assert
        Assert.Throws<ArgumentNullException>(result);
    }
}
