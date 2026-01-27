/*
A class to implement Balanced binary search trees from Binary search trees.
*/

//TODO
public class BalancedBinarySearchTree<T> : BinarySearchTree<T>
    where T : notnull, IComparable<T>
{
    #region Constructors
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
    #endregion

    #region AddNode and RemoveNode
    protected override bool AddNode(Node<T> currentNode, T value)
    {
        bool result = base.AddNode(currentNode, value);
        BalanceNodes();

        return result;
    }

    public override bool RemoveFirstNodeWithValue(T value)
    {
        bool result = base.RemoveFirstNodeWithValue(value);
        BalanceNodes();

        return result;
    }
    #endregion

    #region Balance Nodes
    /// <summary>
    /// A first approach to rebalance would be to recreate the tree from an in order traversal.
    /// This approach has high complexity but works quite well.
    /// </summary>
    public void BalanceNodes()
    {
        if (_node is null || IsBalanced())
        {
            return;
        }

        List<T> allNodeValues = InOrderTraversal();
        Node<T> vine = new(allNodeValues[0]); // Dummy node
        Node<T>? currentNode = vine;
        for (int i = 0; i < allNodeValues.Count(); i++)
        {
            currentNode?.AddRight(allNodeValues[i]);
            currentNode = currentNode?.rightNode;
        }
        int nodeCount = GetSize();
        int maxDepthForBalancedTree = (int)Math.Pow(2, Math.Floor(Math.Log2(nodeCount + 1))) - 1;
        int leavesToCreate = nodeCount - maxDepthForBalancedTree;

        RotateNodes(vine, leavesToCreate);

        int nodesToRotate = maxDepthForBalancedTree;
        while (nodesToRotate > 1)
        {
            nodesToRotate /= 2;
            RotateNodes(vine, nodesToRotate);
        }

        _node = vine.rightNode; // Skip dummy root
        vine.rightNode = null;
    }

    private void LeftRotate(Node<T> node, Node<T> parent)
    {
        parent.rightNode = node.leftNode;
        node.leftNode = parent;
    }

    private void RightRotate(Node<T> node, Node<T> parent)
    {
        parent.leftNode = node.rightNode;
        node.rightNode = parent;
    }

    private void RotateNodes(Node<T> dummyRoot, int numberOfRotations)
    {
        Node<T> currentNode = dummyRoot;

        for (int i = 0; i < numberOfRotations; i++)
        {
            if (currentNode.rightNode?.rightNode == null)
                return;

            Node<T> parent = currentNode.rightNode;
            Node<T> child = parent.rightNode;

            // Perform left rotation
            LeftRotate(child, parent);
            currentNode.rightNode = child;

            // Move down the vine
            currentNode = child;
        }
    }
    #endregion
}
