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
        Node<string>? node = binaryTree.GetNode();

        // Assert
        Assert.Equal("test", node?.Value);
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

    #region Contains
    [Fact]
    public void Contains_WhenTheTreeContainsTheValue_ReturnsTrue()
    {
        // Arrange
        Node<int> root = new(9);
        root.AddLeft(5);
        root.AddRight(11);
        root.rightNode?.AddLeft(-10);
        root.rightNode?.AddRight(15);
        root.rightNode?.rightNode?.AddRight(112);
        root.leftNode?.AddLeft(5);
        root.leftNode?.AddRight(10);
        root.leftNode?.leftNode?.AddLeft(1);
        BinaryTree<int> binaryTree = new(root);

        // Act
        bool containsValue = binaryTree.Contains(-10);

        // Assert
        Assert.True(containsValue);
    }

    [Fact]
    public void Contains_WhenTheTreeDoesNotContainTheValue_ReturnsFalse()
    {
        // Arrange
        Node<int> root = new(9);
        root.AddLeft(5);
        root.AddRight(11);
        root.rightNode?.AddLeft(-10);
        root.rightNode?.AddRight(15);
        root.rightNode?.rightNode?.AddRight(112);
        root.leftNode?.AddLeft(5);
        root.leftNode?.AddRight(10);
        root.leftNode?.leftNode?.AddLeft(1);
        BinaryTree<int> binaryTree = new(root);

        // Act
        bool containsValue = binaryTree.Contains(1124);

        // Assert
        Assert.False(containsValue);
    }
    #endregion

    #region Adding and Removing Nodes
    [Fact]
    public void AddNode_AddsNodeToTheTree()
    {
        // Arrange
        Node<int> root = new(9);
        BinaryTree<int> binaryTree = new(root);
        int value = 1124;

        // Act
        binaryTree.AddNode(value);

        // Assert
        Assert.True(binaryTree.Contains(value));
    }

    [Fact]
    public void RemoveFirstNodeWithValue_WhenThereIAreNoNodesWithTheValue_ReturnsFalse()
    {
        // Arrange
        Node<int> root = new(9);
        BinaryTree<int> binaryTree = new(root);
        int value = 1124;

        // Act
        bool hasNodeWithValue = binaryTree.RemoveFirstNodeWithValue(value);

        // Assert
        Assert.False(hasNodeWithValue);
    }

    [Fact]
    public void RemoveFirstNodeWithValue_WhenThereIsOnlyOneNodeWithTheValue_RemovesThisNode()
    {
        // Arrange
        Node<int> root = new(9);
        BinaryTree<int> binaryTree = new(root);
        int value = 1124;

        // Act
        binaryTree.AddNode(value);
        binaryTree.RemoveFirstNodeWithValue(value);

        // Assert
        Assert.False(binaryTree.Contains(value));
    }

    [Fact]
    public void RemoveFirstNodeWithValue_WhenThereAreMultipleNodesWithTheSameValue_RemovesOnlyOneNode()
    {
        // Arrange
        Node<int> root = new(9);
        BinaryTree<int> binaryTree = new(root);
        int value = 1124;

        // Act
        binaryTree.AddNode(value);
        binaryTree.AddNode(value);
        binaryTree.RemoveFirstNodeWithValue(value);

        // Assert
        Assert.True(binaryTree.Contains(value));
    }

    [Fact]
    public void RemoveNode_OnNodeWithTwoChildren_Succeeds()
    {
        // Arrange
        Node<int> root = new(5);
        root.AddLeft(3);
        root.AddRight(6);
        root.rightNode?.AddRight(8);
        ;
        root.leftNode?.AddLeft(2);
        root.leftNode?.AddRight(4);
        BinaryTree<int> binaryTree = new(root);

        // Act
        int value = 3;
        binaryTree.RemoveFirstNodeWithValue(value);

        // Arrange
        Assert.False(binaryTree.Contains(value));
    }
    #endregion

    #region Traversal
    [Fact]
    public void PreOrderTraversal_ReturnsAllNodeFromTheTree_InCorrectOrder()
    {
        // Arrange
        Node<int> root = new(1);
        root.AddLeft(2);
        root.AddRight(5);
        root.rightNode?.AddRight(6);
        root.rightNode?.rightNode?.AddLeft(7);
        root.leftNode?.AddLeft(3);
        root.leftNode?.AddRight(4);
        BinaryTree<int> binaryTree = new(root);
        List<int> expectedResult = new() { 1, 2, 3, 4, 5, 6, 7 };

        // Act
        List<int> listNodeValues = binaryTree.PreOrderTraversal();

        // Assert
        Assert.Equal(expectedResult, listNodeValues);
    }

    [Fact]
    public void PostOrderTraversal_ReturnsAllNodeFromTheTree_InCorrectOrder()
    {
        // Arrange
        Node<int> root = new(7);
        root.AddLeft(4);
        root.AddRight(6);
        root.rightNode?.AddRight(5);
        root.leftNode?.AddLeft(1);
        root.leftNode?.AddRight(3);
        root.leftNode?.rightNode?.AddRight(2);
        BinaryTree<int> binaryTree = new(root);
        List<int> expectedResult = new() { 1, 2, 3, 4, 5, 6, 7 };

        // Act
        List<int> listNodeValues = binaryTree.PostOrderTraversal();

        // Assert
        Assert.Equal(expectedResult, listNodeValues);
    }

    [Fact]
    public void InOrderTraversal_ReturnsAllNodeFromTheTree_InCorrectOrder()
    {
        // Arrange
        Node<int> root = new(4);
        root.AddLeft(2);
        root.AddRight(5);
        root.rightNode?.AddRight(7);
        root.rightNode?.rightNode?.AddLeft(6);
        root.leftNode?.AddLeft(1);
        root.leftNode?.AddRight(3);
        BinaryTree<int> binaryTree = new(root);
        List<int> expectedResult = new() { 1, 2, 3, 4, 5, 6, 7 };

        // Act
        List<int> listNodeValues = binaryTree.InOrderTraversal();

        // Assert
        Assert.Equal(expectedResult, listNodeValues);
    }

    [Fact]
    public void BreadthFirstSearch_ReturnsAllNodeFromTheTree_InCorrectOrder()
    {
        // Arrange
        Node<int> root = new(1);
        root.AddLeft(2);
        root.AddRight(3);
        root.rightNode?.AddRight(6);
        root.rightNode?.rightNode?.AddLeft(7);
        root.leftNode?.AddLeft(4);
        root.leftNode?.AddRight(5);
        BinaryTree<int> binaryTree = new(root);
        List<int> expectedResult = new() { 1, 2, 3, 4, 5, 6, 7 };

        // Act
        List<int> listNodeValues = binaryTree.BreadthFirstSearch();

        // Assert
        Assert.Equal(expectedResult, listNodeValues);
    }
    #endregion
}
