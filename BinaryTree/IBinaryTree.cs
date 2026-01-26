/*
An Interface to define a tree and tree methods.
*/

public enum Branch
{
    Left,
    Right,
}

/// <summary>
/// We don't want the user to make a binary tree unbalanced.
/// As a result we separate our get logic from our set logic.
/// </summary>
/// <typeparam name="T">The value type of the nodes.</typeparam>
public interface IReadOnlyBinaryTree<T> : IComparable<T>
    where T : notnull, IComparable<T>
{
    public Node<T> GetNode();
    public int GetSize();
    public int GetMaxDepth();
    public int GetMinDepth();
    public IReadOnlyBinaryTree<T>? GetLeftBranch();
    public IReadOnlyBinaryTree<T>? GetRightBranch();
    public IReadOnlyBinaryTree<T>? GetParent();
    public bool Contains(T value);
    public List<T> PreOrderTraversal();
    public List<T> InOrderTraversal();
    public List<T> PostOrderTraversal();
    public List<T> DepthFirstSearch();
    public bool IsBalanced();
    public bool IsBinarySearchTree();
    public bool IsBinarySearchTree(T? minValue, T? maxValue);
}

public interface IBinaryTree<T> : IReadOnlyBinaryTree<T>, IComparable<T>
    where T : notnull, IComparable<T>
{
    public void AddNode(T value);
    public bool RemoveNode();
    public bool RemoveFirstNodeWithValue(T value);
    public bool RemoveAllNodesWithValue(T value);
}
