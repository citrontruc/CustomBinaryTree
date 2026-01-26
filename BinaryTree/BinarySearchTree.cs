/*
A class to implement a binary search tree.
*/

public class BinarySearchTree<T> : BinaryTree<T>
    where T : notnull, IComparable<T>
{
    public BinarySearchTree(T value)
        : base(value) { }

    protected override BinarySearchTree<T> CreateNode(T value)
    {
        return new BinarySearchTree<T>(value);
    }

    public override void AddNode(T value)
    {
        if ((value.CompareTo(_node.Value) <= 0) && (_leftBranch is null))
        {
            _leftBranch = CreateNode(value);
            return;
        }

        if ((value.CompareTo(_node.Value) > 0) && (_rightBranch is null))
        {
            _rightBranch = CreateNode(value);
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

    public override bool Contains(T value)
    {
        int comparisonValue = _node.Value.CompareTo(value);
        if (comparisonValue == 0)
        {
            return true;
        }

        if (comparisonValue < 0 && _leftBranch is not null)
        {
            return _leftBranch.Contains(value);
        }

        if (comparisonValue > 0 && _rightBranch is not null)
        {
            return _rightBranch.Contains(value);
        }

        return false;
    }
}
