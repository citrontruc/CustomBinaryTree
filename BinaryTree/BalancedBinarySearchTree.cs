/*
A class to implement Balanced binary search trees from Binary search trees.
*/

//TODO
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

    protected override bool AddNode(Node<T> currentNode, T value)
    {
        bool result = base.AddNode(currentNode, value);
        Rebalance();

        return result;
    }

    public override bool RemoveFirstNodeWithValue(T value)
    {
        bool result = base.RemoveFirstNodeWithValue(value);
        Rebalance();

        return result;
    }

    public void Rebalance()
    {
        if (IsBalanced())
        {
            return;
        }
    }
}
