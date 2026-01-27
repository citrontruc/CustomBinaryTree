/*
A script to do our tests on our implementation of binary balanced trees.
*/

public class BalancedBinaryTreeTest
{
    #region Constructors
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
        Action createBalancedTree = () => new BalancedBinaryTree<int>(root);

        // Arrange
        Assert.Throws<ArgumentException>(createBalancedTree);
    }

    [Fact]
    public void BinarySearchTree_WithCorrectNodes_ThrowsNoException()
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
        BalancedBinaryTree<int> balancedBinaryTree = new(root);

        // Arrange
        Assert.True(balancedBinaryTree.IsBalanced());
    }
    #endregion

    #region Depth evaluation when nodes are added
    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(5)]
    public void GetMaxDepth_InABalancedBinaryTree_ReturnsTheCorrectValue(int maxDepth)
    {
        // Arrange
        BalancedBinaryTree<string> binaryTree = new("test");

        // Act
        for (int i = 1; i < Math.Pow(2, maxDepth) + 1; i++)
        {
            binaryTree.AddNode("test");
        }
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

        // Act
        for (int i = 1; i < Math.Pow(2, minDepth) - 1; i++)
        {
            binaryTree.AddNode("test");
        }
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

        // Act
        for (int i = 1; i < numberNodes; i++)
        {
            binaryTree.AddNode("test");
        }
        bool isBalanced = binaryTree.IsBalanced();

        // Assert
        Assert.True(isBalanced);
    }
    #endregion

    #region Depth evaluation when nodes are removed
    [Fact]
    public void RemoveNode_OnNodeWithTwoChildren_RemainsBinaryBalancedTree()
    {
        // Arrange
        Node<int> root = new(5);
        BalancedBinaryTree<int> balancedBinaryTree = new(root);
        balancedBinaryTree.AddNode(3);
        balancedBinaryTree.AddNode(4);
        balancedBinaryTree.AddNode(2);
        balancedBinaryTree.AddNode(6);
        balancedBinaryTree.AddNode(8);
        balancedBinaryTree.AddNode(7);

        // Act
        int value = 3;
        balancedBinaryTree.RemoveFirstNodeWithValue(value);

        // Arrange
        Assert.False(balancedBinaryTree.Contains(value));
        Assert.True(balancedBinaryTree.IsBalanced());
    }

    [Fact]
    public void RemoveNode_OnNodeWithOnlyRightChild_RemainsBinaryBalancedTree()
    {
        // Arrange
        Node<int> root = new(5);
        BalancedBinaryTree<int> balancedBinaryTree = new(root);
        balancedBinaryTree.AddNode(3);
        balancedBinaryTree.AddNode(4);
        balancedBinaryTree.AddNode(2);
        balancedBinaryTree.AddNode(6);
        balancedBinaryTree.AddNode(8);
        balancedBinaryTree.AddNode(7);

        // Act
        int value = 6;
        balancedBinaryTree.RemoveFirstNodeWithValue(value);

        // Arrange
        Assert.False(balancedBinaryTree.Contains(value));
        Assert.True(balancedBinaryTree.IsBalanced());
    }

    [Fact]
    public void RemoveNode_OnNodeWithOnlyLeftChild_RemainsBinaryBalancedTree()
    {
        // Arrange
        Node<int> root = new(5);
        BalancedBinaryTree<int> balancedBinaryTree = new(root);
        balancedBinaryTree.AddNode(3);
        balancedBinaryTree.AddNode(4);
        balancedBinaryTree.AddNode(2);
        balancedBinaryTree.AddNode(6);
        balancedBinaryTree.AddNode(8);
        balancedBinaryTree.AddNode(7);

        // Act
        int value = 8;
        balancedBinaryTree.RemoveFirstNodeWithValue(value);

        // Arrange
        Assert.False(balancedBinaryTree.Contains(value));
        Assert.True(balancedBinaryTree.IsBalanced());
    }
    #endregion
}
