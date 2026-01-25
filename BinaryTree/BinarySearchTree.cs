/*
A class to implement a binary search tree.
*/

public class BinarySearchTree<T> : BinaryTree<T>
    where T : notnull, IComparable<T>
{
    public BinarySearchTree(T value)
        : base(value) { }

    public override void AddNode(T value)
    {
        if ((value.CompareTo(_node.Value) <= 0) && (_leftBranch is null))
        {
            _leftBranch = new BinarySearchTree<T>(value);
            return;
        }

        if ((value.CompareTo(_node.Value) > 0) && (_rightBranch is null))
        {
            _rightBranch = new BinarySearchTree<T>(value);
            return;
        }

        if ((value.CompareTo(_node.Value) <= 0) && (_leftBranch is not null))
        {
            _leftBranch.AddNode(value);
            return;
        }

        if ((value.CompareTo(_node.Value) > 0) && (_rightBranch is not null))
        {
            _rightBranch.AddNode(value);
            return;
        }

        throw new Exception($"Couldn't manage to insert value {value}.");
    }
}
