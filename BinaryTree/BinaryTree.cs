/*
A class to implement a binary tree with search methods.
*/

public class BinaryTree<T> : IBinaryTree<T>
    where T : notnull, IComparable<T>
{
    protected BinaryTree<T>? _parentBranch;
    protected BinaryTree<T>? _leftBranch;
    protected BinaryTree<T>? _rightBranch;
    protected Node<T> _node;

    public BinaryTree(T value)
    {
        _node = new(value);
    }

    protected virtual BinaryTree<T> CreateNode(T value)
    {
        return new BinaryTree<T>(value);
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

    public IReadOnlyBinaryTree<T>? GetLeftBranch()
    {
        return _leftBranch;
    }

    public IReadOnlyBinaryTree<T>? GetRightBranch()
    {
        return _rightBranch;
    }

    public IReadOnlyBinaryTree<T>? GetParent()
    {
        return _parentBranch;
    }

    protected virtual void SetLeftBranch(BinaryTree<T>? leftBranch)
    {
        _leftBranch = leftBranch;
    }

    protected virtual void SetRightBranch(BinaryTree<T>? rightBranch)
    {
        _rightBranch = rightBranch;
    }

    protected virtual void SetParentBranch(BinaryTree<T>? parentBranch)
    {
        _parentBranch = parentBranch;
    }

    private BinaryTree<T> GetDeepestBranch()
    {
        if (_leftBranch is null && _rightBranch is null)
        {
            return this;
        }

        bool leftBranchIsDeeper =
            (_leftBranch?.GetMaxDepth() ?? 0) > (_rightBranch?.GetMaxDepth() ?? 0);

        if (_leftBranch is not null && leftBranchIsDeeper)
        {
            return _leftBranch.GetDeepestBranch();
        }

        if (_rightBranch is not null && !leftBranchIsDeeper)
        {
            return _rightBranch.GetDeepestBranch();
        }

        throw new Exception(
            "Something went wrong when trying to Get the deepest branch of the tree."
        );
    }

    /// <summary>
    /// Size is the number of nodes in a tree
    /// </summary>
    /// <returns>An int indicating the size of the tree</returns>
    public int GetSize()
    {
        return 1 + (_leftBranch?.GetSize() ?? 0) + (_rightBranch?.GetSize() ?? 0);
    }

    /// <summary>
    /// Checks if a tree containst the given value.
    /// Uses a recursive technique.
    /// </summary>
    /// <param name="value">the value to check for</param>
    /// <returns> A boolean indicating if the is value in the tree</returns>
    public virtual bool Contains(T value)
    {
        if (_node.Value.Equals(value))
        {
            return true;
        }
        return (_leftBranch?.Contains(value) ?? false) || (_rightBranch?.Contains(value) ?? false);
    }

    /// <summary>
    /// An iterative version of the contains method. Checks each element one after another.
    /// Since we check all the elements in our tree one after another, our complexity is N.
    /// </summary>
    /// <param name="value"> The value we are looking for.</param>
    /// <returns>A boolean indicating if we have found the correct value.</returns>
    public bool IterativeContains(T value)
    {
        Queue<IReadOnlyBinaryTree<T>?> branchesToExplore = new();
        branchesToExplore.Enqueue(_leftBranch);
        branchesToExplore.Enqueue(_rightBranch);

        while (branchesToExplore.Count() > 0)
        {
            IReadOnlyBinaryTree<T>? branch = branchesToExplore.Dequeue();
            if (branch?.GetNode().Value.Equals(value) ?? false)
            {
                return true;
            }

            if (branch is not null)
            {
                branchesToExplore.Enqueue(branch?.GetLeftBranch());
                branchesToExplore.Enqueue(branch?.GetRightBranch());
            }
        }

        return false;
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
            _leftBranch = CreateNode(value);
            _leftBranch.SetParentBranch(this);
            return;
        }

        if (_rightBranch is null)
        {
            _rightBranch = CreateNode(value);
            _rightBranch.SetParentBranch(this);
            return;
        }

        _leftBranch.AddNode(value);
    }

    protected virtual void CutTiesWithChild(BinaryTree<T> child)
    {
        if (_leftBranch == child)
        {
            _leftBranch = default;
            return;
        }

        if (_rightBranch == child)
        {
            _rightBranch = default;
            return;
        }

        throw new Exception("Could not find the requested branch in children");
    }

    /// <summary>
    /// We take the rightmost, deepest node and use it to replace the node we are going to replace.
    /// </summary>
    /// <returns>A boolean indicating if the operation was successful</returns>
    public virtual bool RemoveNode()
    {
        BinaryTree<T> branch = GetDeepestBranch();
        // Change parent branch
        branch._parentBranch?.CutTiesWithChild(branch);
        branch.SetParentBranch(_parentBranch);
        // Change children
        _leftBranch?.SetParentBranch(branch);
        _rightBranch?.SetParentBranch(branch);
        branch.SetLeftBranch(_leftBranch);
        branch.SetRightBranch(_rightBranch);
        return true;
    }

    /// <summary>
    /// Remove first node with value will remove the leftmost value first.
    /// </summary>
    /// <param name="value">value to remove.</param>
    /// <returns>A boolean indicating if the value was successful.</returns>
    public virtual bool RemoveFirstNodeWithValue(T value)
    {
        if (_node.Value.Equals(value))
        {
            return RemoveNode();
        }

        if (_leftBranch?.RemoveFirstNodeWithValue(value) ?? false)
        {
            return true;
        }

        if (_rightBranch?.RemoveFirstNodeWithValue(value) ?? false)
        {
            return true;
        }

        return false;
    }

    public virtual bool RemoveAllNodesWithValue(T value)
    {
        if (_node.Value.Equals(value))
        {
            RemoveNode();
            return _parentBranch?.RemoveAllNodesWithValue(value) ?? true;
        }

        return (_leftBranch?.RemoveAllNodesWithValue(value) ?? true)
            && (_rightBranch?.RemoveAllNodesWithValue(value) ?? true);
    }

    public List<T> PreOrderTraversal()
    {
        List<T> result = new();
        result.Add(_node.Value);

        if (_leftBranch is not null)
        {
            result.AddRange(_leftBranch.PreOrderTraversal());
        }

        if (_rightBranch is not null)
        {
            result.AddRange(_rightBranch.PreOrderTraversal());
        }
        return result;
    }

    public List<T> InOrderTraversal()
    {
        List<T> result = new();

        if (_leftBranch is not null)
        {
            result.AddRange(_leftBranch.InOrderTraversal());
        }

        result.Add(_node.Value);

        if (_rightBranch is not null)
        {
            result.AddRange(_rightBranch.InOrderTraversal());
        }
        return result;
    }

    public List<T> PostOrderTraversal()
    {
        List<T> result = new();

        if (_leftBranch is not null)
        {
            result.AddRange(_leftBranch.PostOrderTraversal());
        }

        if (_rightBranch is not null)
        {
            result.AddRange(_rightBranch.PostOrderTraversal());
        }

        result.Add(_node.Value);

        return result;
    }

    // TODO
    public List<T> DepthFirstSearch()
    {
        return new();
    }

    public bool IsBalanced()
    {
        return GetMaxDepth() - GetMinDepth() <= 1;
    }

    public bool IsBinarySearchTree()
    {
        return IsBinarySearchTree(default, default);
    }

    public bool IsBinarySearchTree(T? minValue, T? maxValue)
    {
        if (_leftBranch is null && _rightBranch is null)
        {
            return true;
        }

        if (minValue is not null && _node.Value.CompareTo(minValue) < 0)
        {
            return false;
        }

        if (maxValue is not null && _node.Value.CompareTo(maxValue) > 0)
        {
            return false;
        }
        return (_leftBranch?.IsBinarySearchTree(minValue, _node.Value) ?? true)
            && (_rightBranch?.IsBinarySearchTree(_node.Value, maxValue) ?? true);
    }

    public int CompareTo(T? other)
    {
        return _node.Value.CompareTo(other);
    }
}
