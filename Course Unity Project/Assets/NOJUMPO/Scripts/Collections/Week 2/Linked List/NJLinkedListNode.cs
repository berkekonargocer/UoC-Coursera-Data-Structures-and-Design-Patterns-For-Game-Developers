namespace Nojumpo.Collections
{
    public class NJLinkedListNode<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        public T Value { get { return _value; } }
        public NJLinkedListNode<T> Previous { get { return _previous; } set { value = _previous; } }
        public NJLinkedListNode<T> Next { get { return _next; } set { _next = value; } }

        T _value;
        NJLinkedListNode<T> _previous;
        NJLinkedListNode<T> _next;


        // ----------------------------- CONSTRUCTORS ------------------------------
        public NJLinkedListNode(T value, NJLinkedListNode<T> previous, NJLinkedListNode<T> next) {
            _value = value;
            _previous = previous;
            _next = next;
        }
    }
}