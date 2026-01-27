/*
A class to implement a binary search tree.
*/

public class BalancedBinaryTree<T> : BinaryTree<T>
    where T : notnull, IComparable<T>
{
    #region Constructors
    public BalancedBinaryTree(T value)
        : base(value) { }

    public BalancedBinaryTree(Node<T> node)
        : base(node)
    {
        if (!IsBalanced())
        {
            throw new ArgumentException(
                "The provided node do not follow a balanced binary tree structure."
            );
        }
    }
    #endregion

    #region AddNode and RemoveNode
    protected override bool AddNode(Node<T> currentNode, T value)
    {
        if (currentNode is null)
        {
            throw new ArgumentException("Can't add a node to an already empty node");
        }

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

        bool result =
            currentNode.leftNode.GetMinDepth() <= currentNode.rightNode.GetMinDepth()
                ? AddNode(currentNode.leftNode, value)
                : AddNode(currentNode.rightNode, value);
        return result;
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
        bool comparisonValue =
            (_node.leftNode?.GetMinDepth() ?? 0) >= (_node.rightNode?.GetMinDepth() ?? 0);
        (Node<T> replacementNode, Node<T> replacementParentNode, bool isLeftNode) = comparisonValue
            ? FindReplacementNodeForRemoval(_node.leftNode, _node, true)
            : FindReplacementNodeForRemoval(_node.rightNode, _node, false);
        replacementParentNode.leftNode = isLeftNode ? null : replacementParentNode.leftNode;
        replacementParentNode.rightNode = isLeftNode ? replacementParentNode.rightNode : null;

        if (replacementNode.Value.Equals(value))
        {
            return true;
        }

        if (RemoveFirstNodeWithValue(_node.rightNode, _node, replacementNode, value, false))
        {
            return true;
        }
        return RemoveFirstNodeWithValue(_node.leftNode, _node, replacementNode, value, true);
    }

    protected virtual bool RemoveFirstNodeWithValue(
        Node<T>? currentNode,
        Node<T> parentNode,
        Node<T> replacementNode,
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
            replacementNode.leftNode = currentNode.leftNode;
            replacementNode.rightNode = currentNode.rightNode;
            if (isLeftNode)
            {
                parentNode.leftNode = replacementNode;
            }
            else
            {
                parentNode.rightNode = replacementNode;
            }
            return true;
        }
        if (
            RemoveFirstNodeWithValue(
                currentNode.leftNode,
                currentNode,
                replacementNode,
                value,
                true
            )
        )
        {
            return true;
        }
        return RemoveFirstNodeWithValue(
            currentNode.rightNode,
            currentNode,
            replacementNode,
            value,
            false
        );
    }

    protected virtual (Node<T>, Node<T>, bool) FindReplacementNodeForRemoval(
        Node<T>? currentNode,
        Node<T> parent,
        bool isLeftNode
    )
    {
        if (currentNode is null)
        {
            throw new ArgumentException("Cannot find replacement with an empty tree");
        }

        if (currentNode.HasNoChildNode)
        {
            return (currentNode, parent, isLeftNode);
        }

        return
            (currentNode.leftNode?.GetMinDepth() ?? 0)
            >= (currentNode.rightNode?.GetMinDepth() ?? 0)
            ? FindReplacementNodeForRemoval(currentNode.leftNode, currentNode, true)
            : FindReplacementNodeForRemoval(currentNode.rightNode, currentNode, false);
    }
    #endregion
}
