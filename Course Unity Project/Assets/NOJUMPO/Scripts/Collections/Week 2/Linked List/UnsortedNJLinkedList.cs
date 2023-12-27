namespace NOJUMPO.Collections
{
    public class UnsortedNJLinkedList<T> : NJLinkedList<T>
    {
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Add(T item) {
            if (_head == null)
            {
                _head = new NJLinkedListNode<T>(item, null, null);
            }
            else
            {
                _head.Previous = new NJLinkedListNode<T>(item, null,_head);
                _head = _head.Previous;
            }

            _count++;
        }
    }
}