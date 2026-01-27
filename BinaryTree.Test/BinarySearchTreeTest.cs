/*
A script to do our tests on our implementation of binary search trees.
*/

public class BinarySearchTreeTest
{
    #region Constructor
    [Fact]
    public void BinarySearchTree_WithFaultyNodes_ThrowsException()
    {
        // Arrange
        Node<int> root = new(9);
        root.AddLeft(5);
        root.AddRight(15);
        root.rightNode?.AddLeft(11);
        root.rightNode?.AddLeft(13);
        root.rightNode?.leftNode?.AddRight(16);
        root.leftNode?.AddLeft(5);
        root.leftNode?.AddRight(8);
        root.leftNode?.leftNode?.AddLeft(1);

        // Act
        Action createBinarySearchTree = () => new BinarySearchTree<int>(root);

        // Arrange
        Assert.Throws<ArgumentException>(createBinarySearchTree);
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
        root.rightNode?.leftNode?.AddRight(14);
        root.leftNode?.AddLeft(5);
        root.leftNode?.AddRight(8);
        root.leftNode?.leftNode?.AddLeft(1);

        // Act
        BinarySearchTree<int> binarySearchTree = new(root);

        // Arrange
        Assert.True(binarySearchTree.IsBinarySearchTree());
    }
    #endregion

    #region AddNode
    [Fact]
    public void AddNode_OnBinarySearchTree_StillReturnsBinarySearchTree()
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
        BinarySearchTree<int> binarySearchTree = new(root);
        binarySearchTree.AddNode(1124);
        binarySearchTree.AddNode(2);
        binarySearchTree.AddNode(-1);
        binarySearchTree.AddNode(3);

        // Arrange
        Assert.True(binarySearchTree.IsBinarySearchTree());
    }

    [Fact]
    public void AddNode_OnBinarySearchTree_PlacesNodeAsBinarySearchTree()
    {
        // Arrange
        Node<int> root = new(9);

        // Act
        BinarySearchTree<int> binarySearchTree = new(root);
        binarySearchTree.AddNode(1124);
        binarySearchTree.AddNode(2);
        binarySearchTree.AddNode(-1);
        binarySearchTree.AddNode(3);
        List<int> listResult = binarySearchTree.InOrderTraversal();
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
        BinarySearchTree<int> binarySearchTree = new(root);
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
    }

    [Fact]
    public void RemoveNode_OnNodeWithOnlyRightChild_RemainsBinarySearchTree()
    {
        // Arrange
        Node<int> root = new(5);
        BinarySearchTree<int> binarySearchTree = new(root);
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
    }

    [Fact]
    public void RemoveNode_OnNodeWithOnlyLeftChild_RemainsBinarySearchTree()
    {
        // Arrange
        Node<int> root = new(5);
        BinarySearchTree<int> binarySearchTree = new(root);
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
    }
    #endregion
}
