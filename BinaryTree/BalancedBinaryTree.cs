/*
A class to implement a binary search tree.
*/

public class BalancedBinaryTree<T> : BinaryTree<T>
    where T : notnull, IComparable<T>
{
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
}
