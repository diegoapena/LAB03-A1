
public class SimpleLinkedList<T>
{
    public Node<T> head = null;

    
    public virtual void Add(T value)
    {
        Node<T> newNode = new Node<T>(value);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node<T> current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }

    
    public void Traverse(System.Action<T> action)
    {
        Node<T> current = head;
        while (current != null)
        {
            action(current.Value);
            current = current.Next;
        }
    }
}
