/*
A script to do our tests on our implementation of binary balanced trees.
*/
/*
public class BinaryBalancedTreeTest
{
    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(5)]
    public void GetMaxDepth_InABalancedBinaryTree_ReturnsTheCorrectValue(int maxDepth)
    {
        // Arrange
        BalancedBinaryTree<string> binaryTree = new("test");
        for (int i = 1; i < Math.Pow(2, maxDepth) + 1; i++)
        {
            binaryTree.AddNode("test");
        }

        // Act
        int maxDepthTree = binaryTree.GetMaxDepth();

        // Assert
        Assert.Equal(maxDepth + 1, maxDepthTree);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(5)]
    public void GetMinDepth_InABalancedBinaryTree_ReturnsTheCorrectValue(int minDepth)
    {
        // Arrange
        BalancedBinaryTree<string> binaryTree = new("test");
        for (int i = 1; i < Math.Pow(2, minDepth) - 1; i++)
        {
            binaryTree.AddNode("test");
        }

        // Act
        int minDepthTree = binaryTree.GetMaxDepth();

        // Assert
        Assert.Equal(minDepth, minDepthTree);
    }

    [Theory]
    [InlineData(6)]
    [InlineData(17)]
    [InlineData(125)]
    [InlineData(32)]
    public void IsBalanced_ForAnyNumberOfInsertions_ReturnsTrue(int numberNodes)
    {
        // Arrange
        BalancedBinaryTree<string> binaryTree = new("test");
        for (int i = 1; i < numberNodes; i++)
        {
            binaryTree.AddNode("test");
        }

        // Act
        bool isBalanced = binaryTree.IsBalanced();

        // Assert
        Assert.True(isBalanced);
    }
}*/
