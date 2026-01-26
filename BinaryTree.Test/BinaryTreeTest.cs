/*
A script to do tests on our implementation of binary trees.
*/

public class BinaryTreeTest
{
    [Fact]
    public void GetSize_WithMultipleNodes_ReturnsCorrectNumber()
    {
        // Arrange
        BinaryTree<string> binaryTree = new("test");
        binaryTree.AddNode("test");
        binaryTree.AddNode("test");
        binaryTree.AddNode("test");

        // Act
        int numberNodes = binaryTree.GetSize();

        // Assert
        Assert.Equal(4, numberNodes);
    }
}
