namespace Nojumpo.Collections
{
    public class LinkedListNode<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        public T Value { get { return _value; } }
        public LinkedListNode<T> Next { get { return _next; } set { _next = value; } }

        T _value;
        LinkedListNode<T> _next;


        // ----------------------------- CONSTRUCTORS ------------------------------
        public LinkedListNode(T value, LinkedListNode<T> next) {
            _value = value;
            _next = next;
        }
    }
}