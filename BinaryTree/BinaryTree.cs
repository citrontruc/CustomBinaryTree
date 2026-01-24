/*
A class to implement a binary tree with search methods.
*/

public class BinaryTree<T> : IBinaryTree<T>
    where T : notnull
{
    private IBinaryTree<T>? _leftBranch;
    private IBinaryTree<T>? _rightBranch;
    public T Value;

    public BinaryTree(T value)
    {
        Value = value;
    }

    public BinaryTree(T value, IBinaryTree<T>? leftBranch, IBinaryTree<T>? rightBranch)
    {
        Value = value;
        _leftBranch = leftBranch;
        _rightBranch = rightBranch;
    }

    public int GetMaxDepth()
    {
        int leftDepth = _leftBranch?.GetMaxDepth() ?? 0;
        int rightDepth = _rightBranch?.GetMaxDepth() ?? 0;
        return Math.Max(leftDepth, rightDepth) + 1;
    }

    public int GetMinDepth()
    {
        int leftDepth = _leftBranch?.GetMinDepth() ?? 0;
        int rightDepth = _rightBranch?.GetMinDepth() ?? 0;
        return Math.Min(leftDepth, rightDepth) + 1;
    }

    private IBinaryTree<T>? GetBranchWithSmallestMinDepth()
    {
        if (_leftBranch?.GetMinDepth() < _rightBranch?.GetMinDepth())
        {
            return _leftBranch;
        }

        return _rightBranch;
    }

    public IBinaryTree<T>? GetLeftTree()
    {
        return _leftBranch;
    }

    public IBinaryTree<T>? GetRightTree()
    {
        return _rightBranch;
    }

    public int GetSize()
    {
        return 1 + (_leftBranch?.GetSize() ?? 0) + (_rightBranch?.GetSize() ?? 0);
    }

    public bool CheckIfValueInTree(T value)
    {
        if (Value.Equals(value))
        {
            return true;
        }
        return (_leftBranch?.CheckIfValueInTree(value) ?? false)
            || (_rightBranch?.CheckIfValueInTree(value) ?? false);
    }

    /// <summary>
    /// By default, we will try to insert values on the smallest branch.
    /// </summary>
    /// <param name="value">value to insert in our binary tree</param>
    /// <returns>A boolean to indicate if the operation was successful.</returns>
    public virtual void AddNode(T value)
    {
        if (_leftBranch is null)
        {
            _leftBranch = new BinaryTree<T>(value);
            return;
        }

        if (_rightBranch is null)
        {
            _rightBranch = new BinaryTree<T>(value);
            return;
        }

        GetBranchWithSmallestMinDepth()?.AddNode(value);
    }

    // ToDo
    public virtual bool RemoveFirstNodeWithValue(T value)
    {
        return false;
    }

    // ToDo
    public virtual bool RemoveAllNodesWithValue(T value)
    {
        return false;
    }

    // ToDo
    public List<T> PreOrderTraversal()
    {
        return new();
    }

    // ToDo
    public List<T> InOrderTraversal()
    {
        return new();
    }

    // ToDo
    public List<T> PostOrderTraversal()
    {
        return new();
    }

    public virtual bool IsBinarySearchTree()
    {
        return false;
    }
}
