/*
A class to implement a binary search tree.
*/

public class BinarySearchTree : BinaryTree<int>
{
    private BinarySearchTree? _leftBranch;
    private BinarySearchTree? _rightBranch;

    public BinarySearchTree(int value)
        : base(value) { }

    private bool CheckBranchValidity(BinarySearchTree? binarySearchTree, Branch branch)
    {
        if (binarySearchTree is null)
        {
            return true;
        }

        if (branch == Branch.Left)
        {
            return binarySearchTree.Value < Value;
        }

        if (branch == Branch.Right)
        {
            return binarySearchTree.Value > Value;
        }

        return false;
    }

    public override bool IsBinarySearchTree()
    {
        return true;
    }
}
