/*
A script to do tests on our implementation of binary trees.
*/

public class BinaryTreeTest
{
    [Fact]
    public void GetNode_WithOneNode_LetsYouGetTheNode()
    {
        // Arrange
        BinaryTree<string> binaryTree = new("test");

        // Act
        Node<string> node = binaryTree.GetNode();

        // Assert
        Assert.Equal("test", node.Value);
    }

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

    [Fact]
    public void GetMinDepth_WithAFewNodes_ReturnsTheCorrectValue()
    {
        // Arrange
        BinaryTree<string> binaryTree = new("test");
        binaryTree.AddNode("test");

        // Act
        int minDepth = binaryTree.GetMinDepth();

        // Assert
        Assert.Equal(1, minDepth);
    }

    [Fact]
    public void GetMaxDepth_WithAFewNodes_ReturnsTheCorrectValue()
    {
        // Arrange
        BinaryTree<string> binaryTree = new("test");
        binaryTree.AddNode("test");

        // Act
        int maxDepth = binaryTree.GetMaxDepth();

        // Assert
        Assert.Equal(2, maxDepth);
    }

    [Fact]
    public void IsBalanced_WithAnUnbalancedTree_ReturnsFalse()
    {
        // Arrange
        Node<string> root = new("test");
        root.AddLeft("test");
        root.AddRight("test");
        root.leftNode?.AddLeft("test");
        root.leftNode?.AddRight("test");
        root.leftNode?.leftNode?.AddLeft("test");
        BinaryTree<string> binaryTree = new(root);

        // Act
        bool isBalanced = binaryTree.IsBalanced();

        // Assert
        Assert.False(isBalanced);
    }

    [Fact]
    public void IsBalanced_WithBalancedTree_ReturnsTrue()
    {
        // Arrange
        Node<string> root = new("test");
        root.AddLeft("test");
        root.AddRight("test");
        root.rightNode?.AddLeft("test");
        root.rightNode?.AddRight("test");
        root.rightNode?.rightNode?.AddRight("test");
        root.leftNode?.AddLeft("test");
        root.leftNode?.AddRight("test");
        root.leftNode?.leftNode?.AddLeft("test");
        BinaryTree<string> binaryTree = new(root);

        // Act
        bool isBalanced = binaryTree.IsBalanced();

        // Assert
        Assert.True(isBalanced);
    }

    [Fact]
    public void IsBinarySearchTree_WithOnlyRootBinarySearchTree_ReturnsTrue()
    {
        // Arrange
        Node<int> root = new(9);
        BinaryTree<int> binaryTree = new(root);

        // Act
        bool isBinarySearchTree = binaryTree.IsBinarySearchTree();

        // Assert
        Assert.True(isBinarySearchTree);
    }

    [Fact]
    public void IsBinarySearchTree_WithSimpleBinarySearchTree_ReturnsTrue()
    {
        // Arrange
        Node<int> root = new(9);
        root.AddLeft(5);
        root.AddRight(11);
        BinaryTree<int> binaryTree = new(root);

        // Act
        bool isBinarySearchTree = binaryTree.IsBinarySearchTree();

        // Assert
        Assert.True(isBinarySearchTree);
    }

    [Fact]
    public void IsBinarySearchTree_WithBinarySearchTree_ReturnsTrue()
    {
        // Arrange
        Node<int> root = new(9);
        root.AddLeft(5);
        root.AddRight(11);
        root.rightNode?.AddLeft(10);
        root.rightNode?.AddRight(15);
        root.rightNode?.rightNode?.AddRight(112);
        root.leftNode?.AddLeft(5);
        root.leftNode?.AddRight(6);
        root.leftNode?.leftNode?.AddLeft(1);
        BinaryTree<int> binaryTree = new(root);

        // Act
        bool isBinarySearchTree = binaryTree.IsBinarySearchTree();

        // Assert
        Assert.True(isBinarySearchTree);
    }

    [Fact]
    public void IsBinarySearchTree_WithRegularBinaryTree_ReturnsFalse()
    {
        // Arrange
        Node<int> root = new(9);
        root.AddLeft(5);
        root.AddRight(11);
        root.rightNode?.AddLeft(10);
        root.rightNode?.AddRight(15);
        root.rightNode?.rightNode?.AddRight(112);
        root.leftNode?.AddLeft(5);
        root.leftNode?.AddRight(10);
        root.leftNode?.leftNode?.AddLeft(1);
        BinaryTree<int> binaryTree = new(root);

        // Act
        bool isBinarySearchTree = binaryTree.IsBinarySearchTree();

        // Assert
        Assert.False(isBinarySearchTree);
    }
}
