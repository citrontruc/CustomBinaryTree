/*
A class to implement Balanced binary trees from Binary trees.
*/

public class BalancedBinaryTree<T> : BinaryTree<T>
    where T : notnull, IComparable<T>
{
    public BalancedBinaryTree(T value)
        : base(value) { }

    protected override BinaryTree<T> CreateNode(T value)
    {
        return new BalancedBinaryTree<T>(value);
    }

    protected override void SetLeftBranch(BinaryTree<T>? leftBranch)
    {
        if (leftBranch is null || leftBranch is not BalancedBinaryTree<T>)
        {
            ThrowInsertionError();
        }
        _leftBranch = leftBranch;
    }

    protected override void SetRightBranch(BinaryTree<T>? rightBranch)
    {
        if (rightBranch is null || rightBranch is not BalancedBinaryTree<T>)
        {
            ThrowInsertionError();
        }
        _rightBranch = rightBranch;
    }

    protected override void SetParentBranch(BinaryTree<T>? parentBranch)
    {
        if (parentBranch is null || parentBranch is not BalancedBinaryTree<T>)
        {
            ThrowInsertionError();
        }
        _parentBranch = parentBranch;
    }

    /// <summary>
    /// By default, we will try to insert values on the smallest branch.
    /// </summary>
    /// <param name="value">value to insert in our binary tree</param>
    /// <returns>A boolean to indicate if the operation was successful.</returns>
    public override void AddNode(T value)
    {
        if (_leftBranch is null)
        {
            _leftBranch = CreateNode(value);
            return;
        }

        if (_rightBranch is null)
        {
            _rightBranch = CreateNode(value);
            return;
        }

        if (_leftBranch.GetMinDepth() < _rightBranch.GetMinDepth())
        {
            ((BalancedBinaryTree<T>)_leftBranch).AddNode(value);
            return;
        }
        ((BalancedBinaryTree<T>)_rightBranch).AddNode(value);
    }

    public override bool RemoveNode()
    {
        return false;
    }

    public override bool RemoveFirstNodeWithValue(T value)
    {
        return false;
    }

    public override bool RemoveAllNodesWithValue(T value)
    {
        return (_leftBranch?.RemoveAllNodesWithValue(value) ?? true)
            && (_rightBranch?.RemoveAllNodesWithValue(value) ?? true);
    }

    public bool Rebalance()
    {
        if (IsBalanced())
        {
            return true;
        }

        return false;
    }

    private void ThrowInsertionError()
    {
        throw new Exception(
            "You tried to insert a regular binary tree branch on a balanced binary tree"
        );
    }
}
