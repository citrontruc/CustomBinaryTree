/*
A class to implement nodes of a tree;
*/

public class Node<T>
    where T : notnull, IComparable<T>
{
    public T Value;
    public Node<T>? leftNode;
    public Node<T>? rightNode;
    public bool HasNoChildNode => leftNode is null && rightNode is null;

    public Node(T value)
    {
        Value = value;
    }

    public bool AddLeft(T value)
    {
        if (leftNode is null)
        {
            leftNode = new(value);
            return true;
        }
        return false;
    }

    public bool AddRight(T value)
    {
        if (rightNode is null)
        {
            rightNode = new(value);
            return true;
        }
        return false;
    }

    public int GetMaxDepth()
    {
        int leftDepth = leftNode?.GetMaxDepth() ?? 0;
        int rightDepth = rightNode?.GetMaxDepth() ?? 0;
        return Math.Max(leftDepth, rightDepth) + 1;
    }

    public int GetMinDepth()
    {
        int leftDepth = leftNode?.GetMinDepth() ?? 0;
        int rightDepth = rightNode?.GetMinDepth() ?? 0;
        return Math.Min(leftDepth, rightDepth) + 1;
    }

    public Node<T> GetDeepestNode()
    {
        if (HasNoChildNode)
        {
            return this;
        }

        if ((leftNode?.GetMaxDepth() ?? 0) > (rightNode?.GetMaxDepth() ?? 0))
        {
            return leftNode?.GetDeepestNode() ?? this;
        }

        return rightNode?.GetDeepestNode() ?? this;
    }

    public int GetSize()
    {
        return 1 + (leftNode?.GetSize() ?? 0) + (rightNode?.GetSize() ?? 0);
    }

    public bool Contains(T value)
    {
        if (Value.Equals(value))
        {
            return true;
        }
        return (leftNode?.Contains(value) ?? false) || (leftNode?.Contains(value) ?? false);
    }

    public List<T> PreOrderTraversal()
    {
        List<T> result = new();
        result.Add(Value);

        if (leftNode is not null)
        {
            result.AddRange(leftNode.PreOrderTraversal());
        }

        if (rightNode is not null)
        {
            result.AddRange(rightNode.PreOrderTraversal());
        }
        return result;
    }

    public List<T> InOrderTraversal()
    {
        List<T> result = new();

        if (leftNode is not null)
        {
            result.AddRange(leftNode.InOrderTraversal());
        }

        result.Add(Value);

        if (rightNode is not null)
        {
            result.AddRange(rightNode.InOrderTraversal());
        }
        return result;
    }

    public List<T> PostOrderTraversal()
    {
        List<T> result = new();

        if (leftNode is not null)
        {
            result.AddRange(leftNode.PostOrderTraversal());
        }

        if (rightNode is not null)
        {
            result.AddRange(rightNode.PostOrderTraversal());
        }

        result.Add(Value);

        return result;
    }

    // TODO
    public List<T> DepthFirstSearch()
    {
        return new();
    }

    public bool IsBalanced()
    {
        return GetMaxDepth() - GetMinDepth() <= 1;
    }

    // TODO
    public void BalanceNodes() { }
}
