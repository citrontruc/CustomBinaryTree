/*
An Interface to define a tree and tree methods.
*/

public enum Branch
{
    Left,
    Right,
}

public interface IBinaryTree<T> : IComparable<T>
    where T : notnull, IComparable<T>
{
    public Node<T> GetNode();
    public int GetSize();
    public int GetMaxDepth();
    public int GetMinDepth();
    public IBinaryTree<T>? GetLeftTree();
    public IBinaryTree<T>? GetRightTree();
    public bool Contains(T value);
    public void AddNode(T value);
    public bool RemoveNode();
    public bool RemoveFirstNodeWithValue(T value);
    public bool RemoveAllNodesWithValue(T value);
    public List<T> PreOrderTraversal();
    public List<T> InOrderTraversal();
    public List<T> PostOrderTraversal();
    public bool IsBalanced();
    public bool IsBinarySearchTree();
    public bool IsBinarySearchTree(T? minValue, T? maxValue);
}
