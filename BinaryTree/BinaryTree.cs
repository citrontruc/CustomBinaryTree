/*
A class to implement a binary tree with search methods.
*/

public class BinaryTree<T>
    where T : notnull, IComparable<T>
{
    protected Node<T>? _node;

    public BinaryTree(T value)
    {
        _node = new(value);
    }

    public BinaryTree(Node<T> node)
    {
        _node = node;
    }

    public Node<T>? GetNode()
    {
        return _node;
    }

    public int GetMaxDepth()
    {
        return _node?.GetMaxDepth() ?? 0;
    }

    public int GetMinDepth()
    {
        if (_node is null)
        {
            return 0;
        }
        return _node.GetMinDepth();
    }

    /// <summary>
    /// Size is the number of nodes in a tree
    /// </summary>
    /// <returns>An int indicating the size of the tree</returns>
    public int GetSize()
    {
        if (_node is null)
        {
            return 0;
        }
        return _node.GetSize();
    }

    /// <summary>
    /// Checks if a tree contains the given value.
    /// Uses a recursive technique.
    /// </summary>
    /// <param name="value">the value to check for</param>
    /// <returns> A boolean indicating if the is value in the tree</returns>
    public virtual bool Contains(T value)
    {
        if (_node is null)
        {
            return false;
        }
        return _node.Contains(value);
    }

    /// <summary>
    /// An iterative version of the contains method. Checks each element one after another.
    /// Since we check all the elements in our tree one after another, our complexity is N.
    /// </summary>
    /// <param name="value"> The value we are looking for.</param>
    /// <returns>A boolean indicating if we have found the correct value.</returns>
    public bool IterativeContains(T value)
    {
        Queue<Node<T>?> nodesToExplore = new();
        nodesToExplore.Enqueue(_node?.leftNode);
        nodesToExplore.Enqueue(_node?.rightNode);

        while (nodesToExplore.Count() > 0)
        {
            Node<T>? node = nodesToExplore.Dequeue();
            if (node?.Value.Equals(value) ?? false)
            {
                return true;
            }

            if (node is not null)
            {
                nodesToExplore.Enqueue(node.leftNode);
                nodesToExplore.Enqueue(node.rightNode);
            }
        }

        return false;
    }

    /// <summary>
    /// By default, if we have a free branch, we add our node.
    /// If we don't, we pass on the value to the left branch.
    /// </summary>
    /// <param name="value">The value to insert inside our BinaryTree</param>
    public virtual bool AddNode(T value)
    {
        if (_node is null)
        {
            _node = new(value);
            return true;
        }
        return AddNode(_node, value);
    }

    protected virtual bool AddNode(Node<T> currentNode, T value)
    {
        if (currentNode.leftNode is null)
        {
            currentNode.leftNode = new(value);
            return true;
        }

        if (currentNode.rightNode is null)
        {
            currentNode.rightNode = new(value);
            return true;
        }

        return AddNode(currentNode.leftNode, value);
    }

    public virtual bool RemoveFirstNodeWithValue(T value)
    {
        if (_node is null)
        {
            return false;
        }

        return RemoveFirstNodeWithValue(_node, value);
    }

    protected virtual bool RemoveFirstNodeWithValue(Node<T>? currentNode, T value)
    {
        if (currentNode is null)
        {
            return false;
        }

        if (currentNode.Value.Equals(value))
        {
            if (currentNode.HasNoChildNode)
            {
                currentNode = null;
                return true;
            }
            if (currentNode.HasTwoChildrenNode)
            {
                Node<T> replacementNode = FindReplacementNodeForRemoval(currentNode.rightNode);
                replacementNode.rightNode = currentNode.rightNode;
                replacementNode.leftNode = currentNode.leftNode;
                currentNode = replacementNode;
                return true;
            }
            if (currentNode.leftNode is not null)
            {
                currentNode = currentNode.leftNode;
                return true;
            }
            if (currentNode.rightNode is not null)
            {
                currentNode = currentNode.rightNode;
                return true;
            }
        }
        if (RemoveFirstNodeWithValue(currentNode.leftNode, value))
        {
            return true;
        }
        return RemoveFirstNodeWithValue(currentNode.rightNode, value);
    }

    protected virtual Node<T> FindReplacementNodeForRemoval(Node<T>? currentNode)
    {
        if (currentNode is null)
        {
            throw new ArgumentException("Cannot find replacement with an empty tree");
        }
        if (currentNode.leftNode is not null)
        {
            return FindReplacementNodeForRemoval(currentNode.leftNode);
        }
        return currentNode;
    }

    public Node<T> GetSuccessor(Node<T> currentNode)
    {
        return currentNode;
    }

    /// <summary>
    /// We take the rightmost, deepest node and use it to replace the node we are going to replace.
    /// </summary>
    /// <returns>A boolean indicating if the operation was successful</returns>
    protected virtual bool TryRemoveValueFromChildNodes(
        Node<T>? currentNode,
        Node<T> parent,
        T value,
        bool isLeftBranch
    )
    {
        if (currentNode is null)
        {
            return false;
        }

        if (currentNode.Value.CompareTo(value) == 0)
        {
            return true;
        }

        if (currentNode.leftNode is null) { }

        if (currentNode.rightNode is null) { }

        return RemoveFirstNodeWithValue(currentNode, value);
    }

    public List<T> PreOrderTraversal()
    {
        if (_node is null)
        {
            return new();
        }
        return _node.PreOrderTraversal();
    }

    public List<T> InOrderTraversal()
    {
        if (_node is null)
        {
            return new();
        }
        return _node.InOrderTraversal();
    }

    public List<T> PostOrderTraversal()
    {
        if (_node is null)
        {
            return new();
        }
        return _node.PostOrderTraversal();
    }

    public List<T> BreadthFirstSearch()
    {
        if (_node is null)
        {
            return new();
        }
        return _node.BreadthFirstSearch();
    }

    public bool IsBalanced()
    {
        if (_node is null)
        {
            return true;
        }
        return _node.IsBalanced();
    }

    public bool IsBinarySearchTree()
    {
        return IsBinarySearchTree(_node, default, default, false, false);
    }

    private bool IsBinarySearchTree(
        Node<T>? currentNode,
        T? minValue,
        T? maxValue,
        bool hasMin,
        bool hasMax
    )
    {
        if (currentNode is null)
        {
            return true;
        }

        if (hasMin && (minValue?.CompareTo(currentNode.Value) > 0))
        {
            return false;
        }

        if (hasMax && (maxValue?.CompareTo(currentNode.Value) < 0))
        {
            return false;
        }
        return IsBinarySearchTree(currentNode.leftNode, minValue, currentNode.Value, hasMin, true)
            && IsBinarySearchTree(currentNode.rightNode, currentNode.Value, maxValue, true, hasMax);
    }

    public int? CompareTo(T? other)
    {
        return _node?.Value.CompareTo(other);
    }
}
