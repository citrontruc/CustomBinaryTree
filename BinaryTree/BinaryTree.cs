/*
A class to implement a binary tree with search methods.
*/

public class BinaryTree<T> : IBinaryTree<T>
    where T : notnull, IComparable<T>
{
    protected IBinaryTree<T>? _leftBranch;
    protected IBinaryTree<T>? _rightBranch;
    protected Node<T> _node;

    public BinaryTree(T value)
    {
        _node = new(value);
    }

    public Node<T> GetNode()
    {
        return _node;
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

    public IBinaryTree<T>? GetLeftTree()
    {
        return _leftBranch;
    }

    public IBinaryTree<T>? GetRightTree()
    {
        return _rightBranch;
    }

    /// <summary>
    /// Size is the number of nodes in a tree
    /// </summary>
    /// <returns>An int indicating the size of the tree</returns>
    public int GetSize()
    {
        return 1 + (_leftBranch?.GetSize() ?? 0) + (_rightBranch?.GetSize() ?? 0);
    }

    public bool Contains(T value)
    {
        if (_node.Value.Equals(value))
        {
            return true;
        }
        return (_leftBranch?.Contains(value) ?? false) || (_rightBranch?.Contains(value) ?? false);
    }

    /// <summary>
    /// By default, if we have a free branch, we add our node.
    /// If we don't, we pass on the value to the left branch.
    /// </summary>
    /// <param name="value">The value to insert inside our BinaryTree</param>
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

        _leftBranch.AddNode(value);
    }

    public virtual bool RemoveNode()
    {
        return false;
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
        return (_leftBranch?.IsBinarySearchTree() ?? true)
            && (_rightBranch?.IsBinarySearchTree() ?? true);
    }

    private bool CheckIfValueInInterval(T? minValue, T? maxValue)
    {
        if (_node.Value.CompareTo(minValue) < 0 || _node.Value.CompareTo(maxValue) > 0)
        {
            return false;
        }
        return true;
    }

    public int CompareTo(T? other)
    {
        return _node.Value.CompareTo(other);
    }
}
