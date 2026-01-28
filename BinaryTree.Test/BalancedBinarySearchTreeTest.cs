/*
A script to do our tests on our implementation of binary balanced trees.
*/

public class BalancedBinarySearchTreeTest
{
    #region Constructor
    [Fact]
    public void BalancedBinaryTree_WithFaultyNodes_ThrowsException()
    {
        // Arrange
        Node<int> root = new(9);
        root.AddLeft(5);
        root.AddRight(15);
        root.rightNode?.AddLeft(11);
        root.rightNode?.AddLeft(13);
        root.rightNode?.leftNode?.AddRight(14);
        root.leftNode?.AddLeft(5);
        root.leftNode?.AddRight(8);
        root.leftNode?.leftNode?.AddLeft(1);

        // Act
        Action createBalancedSearchTree = () => new BalancedBinarySearchTree<int>(root);

        // Arrange
        Assert.Throws<ArgumentException>(createBalancedSearchTree);
    }

    [Fact]
    public void BalancedBinarySearchTree_WithCorrectNodes_ThrowsNoException()
    {
        // Arrange
        Node<int> root = new(9);
        root.AddLeft(5);
        root.AddRight(15);
        root.rightNode?.AddLeft(11);
        root.rightNode?.AddLeft(13);
        root.rightNode?.AddRight(16);
        root.leftNode?.AddLeft(5);
        root.leftNode?.AddRight(8);
        root.leftNode?.leftNode?.AddLeft(1);

        // Act
        BalancedBinarySearchTree<int> balancedBinaryTree = new(root);

        // Arrange
        Assert.True(balancedBinaryTree.IsBalanced());
    }
    #endregion

    #region Balanced and search properties evaluated after nodes are added
    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(5)]
    public void GetMaxDepth_InABalancedBinaryTree_ReturnsTheCorrectValue(int maxDepth)
    {
        // Arrange
        BalancedBinarySearchTree<string> binaryTree = new("test");

        // Act
        for (int i = 1; i < Math.Pow(2, maxDepth) + 1; i++)
        {
            binaryTree.AddNode("test");
        }
        int maxDepthTree = binaryTree.GetMaxDepth();
        bool isBinarySearchTree = binaryTree.IsBinarySearchTree();

        // Assert
        Assert.Equal(maxDepth + 1, maxDepthTree);
        Assert.True(isBinarySearchTree);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(5)]
    public void GetMinDepth_InABalancedBinaryTree_ReturnsTheCorrectValue(int minDepth)
    {
        // Arrange
        BalancedBinarySearchTree<string> binaryTree = new("test");

        // Act
        for (int i = 1; i < Math.Pow(2, minDepth) - 1; i++)
        {
            binaryTree.AddNode("test");
        }
        int minDepthTree = binaryTree.GetMaxDepth();
        bool isBinarySearchTree = binaryTree.IsBinarySearchTree();

        // Assert
        Assert.Equal(minDepth, minDepthTree);
        Assert.True(isBinarySearchTree);
    }

    [Theory]
    [InlineData(6)]
    [InlineData(17)]
    [InlineData(125)]
    [InlineData(32)]
    public void IsBalanced_ForAnyNumberOfInsertions_ReturnsTrue(int numberNodes)
    {
        // Arrange
        BalancedBinarySearchTree<string> binaryTree = new("test");

        // Act
        for (int i = 1; i < numberNodes; i++)
        {
            binaryTree.AddNode("test");
        }
        bool isBalanced = binaryTree.IsBalanced();
        bool isBinarySearchTree = binaryTree.IsBinarySearchTree();

        // Assert
        Assert.True(isBalanced);
        Assert.True(isBinarySearchTree);
    }
    #endregion

    #region Addnode
    [Fact]
    public void AddNode_OnBalancedBinarySearchTree_PlacesNodeAsBinarySearchTree()
    {
        // Arrange
        Node<int> root = new(9);

        // Act
        BalancedBinarySearchTree<int> balancedBinarySearchTree = new(root);
        balancedBinarySearchTree.AddNode(1124);
        balancedBinarySearchTree.AddNode(2);
        balancedBinarySearchTree.AddNode(-1);
        balancedBinarySearchTree.AddNode(3);
        List<int> listResult = balancedBinarySearchTree.InOrderTraversal();
        List<int> ExpectedResult = new() { -1, 2, 3, 9, 1124 };

        // Arrange
        Assert.Equal(ExpectedResult, listResult);
    }
    #endregion

    #region RemoveNode
    [Fact]
    public void RemoveNode_OnNodeWithTwoChildren_RemainsBinarySearchTree()
    {
        // Arrange
        Node<int> root = new(5);
        BalancedBinarySearchTree<int> binarySearchTree = new(root);
        binarySearchTree.AddNode(3);
        binarySearchTree.AddNode(4);
        binarySearchTree.AddNode(2);
        binarySearchTree.AddNode(6);
        binarySearchTree.AddNode(8);
        binarySearchTree.AddNode(7);

        // Act
        int value = 3;
        binarySearchTree.RemoveFirstNodeWithValue(value);

        // Arrange
        Assert.False(binarySearchTree.Contains(value));
        Assert.True(binarySearchTree.IsBinarySearchTree());
        Assert.True(binarySearchTree.IsBalanced());
    }

    [Fact]
    public void RemoveNode_OnNodeWithOnlyRightChild_RemainsBinarySearchTree()
    {
        // Arrange
        Node<int> root = new(5);
        BalancedBinarySearchTree<int> binarySearchTree = new(root);
        binarySearchTree.AddNode(3);
        binarySearchTree.AddNode(4);
        binarySearchTree.AddNode(2);
        binarySearchTree.AddNode(6);
        binarySearchTree.AddNode(8);
        binarySearchTree.AddNode(7);

        // Act
        int value = 6;
        binarySearchTree.RemoveFirstNodeWithValue(value);

        // Arrange
        Assert.False(binarySearchTree.Contains(value));
        Assert.True(binarySearchTree.IsBinarySearchTree());
        Assert.True(binarySearchTree.IsBalanced());
    }

    [Fact]
    public void RemoveNode_OnNodeWithOnlyLeftChild_RemainsBinarySearchTree()
    {
        // Arrange
        Node<int> root = new(5);
        BalancedBinarySearchTree<int> binarySearchTree = new(root);
        binarySearchTree.AddNode(3);
        binarySearchTree.AddNode(4);
        binarySearchTree.AddNode(2);
        binarySearchTree.AddNode(6);
        binarySearchTree.AddNode(8);
        binarySearchTree.AddNode(7);

        // Act
        int value = 8;
        binarySearchTree.RemoveFirstNodeWithValue(value);

        // Arrange
        Assert.False(binarySearchTree.Contains(value));
        Assert.True(binarySearchTree.IsBinarySearchTree());
        Assert.True(binarySearchTree.IsBalanced());
    }

    [Fact]
    public void RemoveNode_OnRoot_RemainsBinarySearchTree()
    {
        // Arrange
        Node<int> root = new(5);
        BalancedBinarySearchTree<int> binarySearchTree = new(root);
        binarySearchTree.AddNode(3);
        binarySearchTree.AddNode(4);
        binarySearchTree.AddNode(2);
        binarySearchTree.AddNode(6);
        binarySearchTree.AddNode(8);
        binarySearchTree.AddNode(7);

        // Act
        int value = 5;
        binarySearchTree.RemoveFirstNodeWithValue(value);

        // Arrange
        Assert.False(binarySearchTree.Contains(value));
        Assert.True(binarySearchTree.IsBinarySearchTree());
        Assert.True(binarySearchTree.IsBalanced());
    }
    #endregion
}
