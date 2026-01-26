/*
A class to implement a binary search tree.
*/

public class BinarySearchTree<T> : BinaryTree<T>
    where T : notnull, IComparable<T>
{
    public BinarySearchTree(T value)
        : base(value) { }

    protected override BinaryTree<T> CreateNode(T value)
    {
        return new BinarySearchTree<T>(value);
    }

    protected override void SetLeftBranch(BinaryTree<T>? leftBranch)
    {
        if (leftBranch is null || leftBranch is not BinarySearchTree<T>)
        {
            ThrowInsertionError();
        }
        _leftBranch = leftBranch;
    }

    protected override void SetRightBranch(BinaryTree<T>? rightBranch)
    {
        if (rightBranch is null || rightBranch is not BinarySearchTree<T>)
        {
            ThrowInsertionError();
        }
        _rightBranch = rightBranch;
    }

    protected override void SetParentBranch(BinaryTree<T>? parentBranch)
    {
        if (parentBranch is null || parentBranch is not BinarySearchTree<T>)
        {
            ThrowInsertionError();
        }
        _parentBranch = parentBranch;
    }

    public override void AddNode(T value)
    {
        if ((value.CompareTo(_node.Value) <= 0) && (_leftBranch is null))
        {
            _leftBranch = CreateNode(value);
            ((BinarySearchTree<T>)_leftBranch).SetParentBranch(this);
            return;
        }

        if ((value.CompareTo(_node.Value) > 0) && (_rightBranch is null))
        {
            _rightBranch = CreateNode(value);
            ((BinarySearchTree<T>)_rightBranch).SetParentBranch(this);
            return;
        }

        if ((value.CompareTo(_node.Value) <= 0) && (_leftBranch is not null))
        {
            ((BinarySearchTree<T>)_leftBranch).AddNode(value);
            return;
        }

        if ((value.CompareTo(_node.Value) > 0) && (_rightBranch is not null))
        {
            ((BinarySearchTree<T>)_rightBranch).AddNode(value);
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

    // TODO
    public override bool RemoveNode()
    {
        return false;
    }

    public override bool RemoveFirstNodeWithValue(T value)
    {
        if (_node.Value.Equals(value))
        {
            return RemoveNode();
        }

        if (_leftBranch is not null && _leftBranch.CompareTo(value) >= 0)
        {
            return ((BinarySearchTree<T>)_leftBranch).RemoveFirstNodeWithValue(value);
        }

        if (_rightBranch is not null && _rightBranch.CompareTo(value) <= 0)
        {
            return ((BinarySearchTree<T>)_rightBranch).RemoveFirstNodeWithValue(value);
        }

        return false;
    }

    public override bool RemoveAllNodesWithValue(T value)
    {
        if (_node.Value.Equals(value))
        {
            RemoveNode();
            return ((BinarySearchTree<T>?)_parentBranch)?.RemoveAllNodesWithValue(value) ?? true;
        }

        if (_leftBranch is not null && _leftBranch.CompareTo(value) >= 0)
        {
            return ((BinarySearchTree<T>)_leftBranch).RemoveAllNodesWithValue(value);
        }

        if (_rightBranch is not null && _rightBranch.CompareTo(value) <= 0)
        {
            return ((BinarySearchTree<T>)_rightBranch).RemoveAllNodesWithValue(value);
        }

        return false;
    }

    private void ThrowInsertionError()
    {
        throw new Exception(
            "You tried to insert a regular binary tree branch on a binary search tree"
        );
    }
}
