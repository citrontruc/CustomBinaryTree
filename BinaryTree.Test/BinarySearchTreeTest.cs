/*
A script to do our tests on our implementation of binary search trees.
*/

public class BinarySearchTreeTest
{
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
}
