/*
A class to implement Balanced binary trees from Binary trees.
*/

public class BalancedBinaryTree<T> : BinaryTree<T>
    where T : notnull, IComparable<T>
{
    public BalancedBinaryTree(T value)
        : base(value) { }

    protected override BalancedBinaryTree<T> CreateNode(T value)
    {
        return new BalancedBinaryTree<T>(value);
    }

    /// <summary>
    /// By default, we will try to insert values on the smallest branch.
    /// </summary>
    /// <param name="value">value to insert in our binary tree</param>
    /// <returns>A boolean to indicate if the operation was successful.</returns>
    public override void AddNode(T value)
    {
        if (_leftBranch is null)
        {
            _leftBranch = CreateNode(value);
            return;
        }

        if (_rightBranch is null)
        {
            _rightBranch = CreateNode(value);
            return;
        }

        if (_leftBranch.GetMinDepth() < _rightBranch.GetMinDepth())
        {
            _leftBranch.AddNode(value);
            return;
        }
        _rightBranch.AddNode(value);
    }
}
