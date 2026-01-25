/*
A class to implement nodes of a tree;
*/

public struct Node<T>
    where T : notnull, IComparable<T>
{
    public T Value;

    public Node(T value)
    {
        Value = value;
    }
}
