/*
A class to implement a binary search tree.
*/

public class BinarySearchTree<T> : BinaryTree<T>
    where T : notnull, IComparable<T>
{
    #region Constructors
    public BinarySearchTree(T value)
        : base(value) { }

    public BinarySearchTree(Node<T> node)
        : base(node)
    {
        if (!IsBinarySearchTree())
        {
            throw new ArgumentException(
                "The provided node do not follow a binary search tree structure."
            );
        }
    }
    #endregion

    #region Contains
    public override bool Contains(T value)
    {
        if (_node is null)
        {
            return false;
        }
        return Contains(_node, value);
    }

    private bool Contains(Node<T> currentNode, T value)
    {
        int comparisonValue = currentNode.Value.CompareTo(value);
        if (comparisonValue == 0)
        {
            return true;
        }

        if (comparisonValue < 0 && currentNode.leftNode is not null)
        {
            return Contains(currentNode.leftNode, value);
        }

        if (comparisonValue > 0 && currentNode.rightNode is not null)
        {
            return Contains(currentNode.rightNode, value);
        }
        return false;
    }
    #endregion

    #region AddNode and RemoveNode
    protected override bool AddNode(Node<T> currentNode, T value)
    {
        int comparisonValue = value.CompareTo(currentNode.Value);
        if ((comparisonValue <= 0) && (currentNode.leftNode is null))
        {
            currentNode.leftNode = new(value);
            return true;
        }

        if ((comparisonValue > 0) && (currentNode.rightNode is null))
        {
            currentNode.rightNode = new(value);
            return true;
        }

        if ((comparisonValue <= 0) && (currentNode.leftNode is not null))
        {
            return AddNode(currentNode.leftNode, value);
        }

        if ((comparisonValue > 0) && (currentNode.rightNode is not null))
        {
            return AddNode(currentNode.rightNode, value);
        }

        return false;
    }

    /// <summary>
    /// If the node to remove has two children nodes we take the leftmost node of the right child node.
    /// </summary>
    /// <param name="value">Value to remove</param>
    /// <returns>A boolean indicating if the operation succeeded.</returns>
    public override bool RemoveFirstNodeWithValue(T value)
    {
        if (_node is null)
        {
            return false;
        }
        if (_node.Value.Equals(value))
        {
            if (_node.HasNoChildNode)
            {
                _node = null;
                return true;
            }
            if (_node.HasTwoChildrenNode)
            {
                (Node<T> replacementNode, Node<T> replacementParentNode) =
                    FindReplacementNodeForRemoval(_node.rightNode, _node);
                if (replacementParentNode != _node)
                {
                    replacementParentNode.leftNode = replacementNode.rightNode;
                    replacementNode.rightNode = _node.rightNode;
                }
                replacementNode.leftNode = _node.leftNode;
                _node = replacementNode;
                return true;
            }
            if (_node.leftNode is not null)
            {
                _node = _node.leftNode;
                return true;
            }
            if (_node.rightNode is not null)
            {
                _node = _node.rightNode;
                return true;
            }
        }

        if (_node.Value.CompareTo(value) >= 0)
        {
            return RemoveFirstNodeWithValue(_node.leftNode, _node, value, true);
        }
        return RemoveFirstNodeWithValue(_node.rightNode, _node, value, false);
    }

    protected override bool RemoveFirstNodeWithValue(
        Node<T>? currentNode,
        Node<T> parentNode,
        T value,
        bool isLeftNode
    )
    {
        if (currentNode is null)
        {
            return false;
        }

        if (currentNode.Value.Equals(value))
        {
            Node<T>? replacementNode = null;
            if (currentNode.HasNoChildNode) { }
            else if (currentNode.HasTwoChildrenNode)
            {
                (replacementNode, Node<T> replacementParentNode) = FindReplacementNodeForRemoval(
                    currentNode.rightNode,
                    currentNode
                );
                if (replacementParentNode != currentNode)
                {
                    replacementParentNode.leftNode = replacementNode.rightNode;
                    replacementNode.rightNode = currentNode.rightNode;
                }
                replacementNode.leftNode = currentNode.leftNode;
            }
            else if (currentNode.leftNode is not null)
            {
                replacementNode = currentNode.leftNode;
            }
            else if (currentNode.rightNode is not null)
            {
                replacementNode = currentNode.rightNode;
            }
            parentNode.leftNode = isLeftNode ? replacementNode : parentNode.leftNode;
            parentNode.rightNode = isLeftNode ? parentNode.rightNode : replacementNode;
            return true;
        }

        if (currentNode.Value.CompareTo(value) >= 0)
        {
            return RemoveFirstNodeWithValue(currentNode.leftNode, currentNode, value, true);
        }
        return RemoveFirstNodeWithValue(currentNode.rightNode, currentNode, value, false);
    }

    protected override (Node<T>, Node<T>) FindReplacementNodeForRemoval(
        Node<T>? currentNode,
        Node<T> parent
    )
    {
        if (currentNode is null)
        {
            throw new ArgumentException("Cannot find replacement with an empty tree");
        }
        if (currentNode.leftNode is not null)
        {
            return FindReplacementNodeForRemoval(currentNode.leftNode, currentNode);
        }
        return (currentNode, parent);
    }
    #endregion
}
