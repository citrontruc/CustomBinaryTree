/*
An Interface to define a tree and tree methods.
*/

public enum Branch
{
    Left,
    Right,
}

public interface IBinaryTree<T>
    where T : notnull
{
    public int GetMaxDepth();
    public int GetMinDepth();
    public IBinaryTree<T>? GetLeftTree();
    public IBinaryTree<T>? GetRightTree();
    public int GetSize();
    public bool CheckIfValueInTree(T value);
    public void AddNode(T value);
    public bool RemoveFirstNodeWithValue(T value);
    public bool RemoveAllNodesWithValue(T value);
    public List<T> PreOrderTraversal();
    public List<T> InOrderTraversal();
    public List<T> PostOrderTraversal();
    public bool IsBinarySearchTree();
}
