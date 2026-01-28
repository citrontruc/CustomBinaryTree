/*
A class to test the different methods to find common values between two lists.
*/

using static ListComparer;

public class ListComparerTest
{
    [Fact]
    public void CompareWithDict_WithoutCommonValuesWithoutDuplicates_ReturnsCorrectValues()
    {
        // Arrange
        List<int> firstList = new() { 1, 10, 5, 97, 30 };
        List<int> secondList = new() { 12, 3, 45, 68, 98, 32, 9, 12 };

        // Act
        List<int> result = CompareWithDict(firstList, secondList);

        // Arrange
        Assert.Empty(result);
    }

    [Fact]
    public void CompareWithDict_WithCommonValuesWithoutDuplicates_ReturnsCorrectValues()
    {
        // Arrange
        List<int> firstList = new() { 1, 2, 3, 4, 5, 6, 7, 9 };
        List<int> secondList = new() { 12, 3, 45, 68, 98, 32, 9, 12 };

        // Act
        List<int> result = CompareWithDict(firstList, secondList);

        // Arrange
        Assert.Contains(3, result);
        Assert.Contains(9, result);
    }

    [Fact]
    public void CompareWithDict_WithCommonValuesWithDuplicates_ReturnsCorrectValues()
    {
        // Arrange
        List<int> firstList = new() { 1, 2, 3, 4, 5, 6, 7, 9, 9, 3, 9 };
        List<int> secondList = new() { 12, 3, 45, 68, 98, 32, 9, 12, 3, 3, 3 };

        // Act
        List<int> result = CompareWithDict(firstList, secondList);

        // Arrange
        Assert.Contains(3, result);
        Assert.Contains(9, result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void CompareWithSort_WithoutCommonValuesWithoutDuplicates_ReturnsCorrectValues()
    {
        // Arrange
        List<int> firstList = new() { 1, 10, 5, 97, 30 };
        List<int> secondList = new() { 12, 3, 45, 68, 98, 32, 9, 12 };

        // Act
        List<int> result = CompareWithSort(firstList, secondList);

        // Arrange
        Assert.Empty(result);
    }

    [Fact]
    public void CompareWithSort_WithCommonValuesWithoutDuplicates_ReturnsCorrectValues()
    {
        // Arrange
        List<int> firstList = new() { 1, 2, 3, 4, 5, 6, 7, 9 };
        List<int> secondList = new() { 12, 3, 45, 68, 98, 32, 9, 12 };

        // Act
        List<int> result = CompareWithSort(firstList, secondList);

        // Arrange
        Assert.Contains(3, result);
        Assert.Contains(9, result);
    }

    [Fact]
    public void CompareWithSort_WithCommonValuesWithDuplicates_ReturnsCorrectValues()
    {
        // Arrange
        List<int> firstList = new() { 1, 2, 3, 4, 5, 6, 7, 9, 9, 3, 9 };
        List<int> secondList = new() { 12, 3, 45, 68, 98, 32, 9, 12, 3, 3, 3 };

        // Act
        List<int> result = CompareWithSort(firstList, secondList);

        // Arrange
        Assert.Contains(3, result);
        Assert.Contains(9, result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void CompareWithBST_WithoutCommonValuesWithoutDuplicates_ReturnsCorrectValues()
    {
        // Arrange
        List<int> firstList = new() { 1, 10, 5, 97, 30 };
        List<int> secondList = new() { 12, 3, 45, 68, 98, 32, 9, 12 };

        // Act
        List<int> result = CompareWithBST(firstList, secondList);

        // Arrange
        Assert.Empty(result);
    }

    [Fact]
    public void CompareWithBST_WithCommonValuesWithoutDuplicates_ReturnsCorrectValues()
    {
        // Arrange
        List<int> firstList = new() { 1, 2, 3, 4, 5, 6, 7, 9 };
        List<int> secondList = new() { 12, 3, 45, 68, 98, 32, 9, 12 };

        // Act
        List<int> result = CompareWithBST(firstList, secondList);

        // Arrange
        Assert.Contains(3, result);
        Assert.Contains(9, result);
    }

    [Fact]
    public void CompareWithBST_WithCommonValuesWithDuplicates_ReturnsCorrectValues()
    {
        // Arrange
        List<int> firstList = new() { 1, 2, 3, 4, 5, 6, 7, 9, 9, 3, 9 };
        List<int> secondList = new() { 12, 3, 45, 68, 98, 32, 9, 12, 3, 3, 3 };

        // Act
        List<int> result = CompareWithBST(firstList, secondList);

        // Arrange
        Assert.Contains(3, result);
        Assert.Contains(9, result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void CompareWithLinq_WithoutCommonValuesWithoutDuplicates_ReturnsCorrectValues()
    {
        // Arrange
        List<int> firstList = new() { 1, 10, 5, 97, 30 };
        List<int> secondList = new() { 12, 3, 45, 68, 98, 32, 9, 12 };

        // Act
        List<int> result = CompareWithLinq(firstList, secondList);

        // Arrange
        Assert.Empty(result);
    }

    [Fact]
    public void CompareWithLinq_WithCommonValuesWithoutDuplicates_ReturnsCorrectValues()
    {
        // Arrange
        List<int> firstList = new() { 1, 2, 3, 4, 5, 6, 7, 9 };
        List<int> secondList = new() { 12, 3, 45, 68, 98, 32, 9, 12 };

        // Act
        List<int> result = CompareWithLinq(firstList, secondList);

        // Arrange
        Assert.Contains(3, result);
        Assert.Contains(9, result);
    }

    [Fact]
    public void CompareWithLinq_WithCommonValuesWithDuplicates_ReturnsCorrectValues()
    {
        // Arrange
        List<int> firstList = new() { 1, 2, 3, 4, 5, 6, 7, 9, 9, 3, 9 };
        List<int> secondList = new() { 12, 3, 45, 68, 98, 32, 9, 12, 3, 3, 3 };

        // Act
        List<int> result = CompareWithLinq(firstList, secondList);

        // Arrange
        Assert.Contains(3, result);
        Assert.Contains(9, result);
        Assert.Equal(2, result.Count());
    }
}
