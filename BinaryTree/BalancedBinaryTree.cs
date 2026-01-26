/*
A class to implement Balanced binary search trees from Binary search trees.
*/

public class BalancedBinaryTree<T> : BinarySearchTree<T>
    where T : notnull, IComparable<T>
{
    public BalancedBinaryTree(T value)
        : base(value) { }

    /// <summary>
    /// By default, we will try to insert values on the smallest branch.
    /// </summary>
    /// <param name="value">value to insert in our binary tree</param>
    /// <returns>A boolean to indicate if the operation was successful.</returns>
    protected override bool AddNode(Node<T> currentNode, T value)
    {
        int comparisonValue = value.CompareTo(currentNode.Value);
        if ((comparisonValue <= 0) && (currentNode.leftNode is null))
        {
            _node.leftNode = new(value);
            return true;
        }

        if ((comparisonValue > 0) && (currentNode.rightNode is null))
        {
            _node.rightNode = new(value);
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

    public override bool Contains(T value)
    {
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

    public override bool RemoveFirstNodeWithValue(T value)
    {
        return RemoveFirstNodeWithValue(_node, value);
    }

    /// <summary>
    /// We take the rightmost, deepest node and use it to replace the node we are going to replace.
    /// </summary>
    /// <returns>A boolean indicating if the operation was successful</returns>
    protected override bool RemoveFirstNodeWithValue(Node<T> currentNode, T value)
    {
        return false;
    }

    public override bool RemoveAllNodesWithValue(T value)
    {
        return RemoveAllNodesWithValue(_node, value);
    }

    protected override bool RemoveAllNodesWithValue(Node<T> currentNode, T value)
    {
        return false;
    }
}
