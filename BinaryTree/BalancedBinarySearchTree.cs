/*
A class to implement Balanced binary search trees from Binary search trees.
*/

public class BalancedBinarySearchTree<T> : BinarySearchTree<T>
    where T : notnull, IComparable<T>
{
    public BalancedBinarySearchTree(T value)
        : base(value) { }

    public BalancedBinarySearchTree(Node<T> node)
        : base(node)
    {
        if (!IsBalanced())
        {
            throw new ArgumentException(
                "The provided node do not follow a balanced binary search tree structure."
            );
        }
    }

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

    public override bool RemoveFirstNodeWithValue(T value)
    {
        if (_node is null)
        {
            return false;
        }
        return RemoveFirstNodeWithValue(_node, value);
    }

    protected override bool RemoveFirstNodeWithValue(Node<T> currentNode, T value)
    {
        return false;
    }
}
