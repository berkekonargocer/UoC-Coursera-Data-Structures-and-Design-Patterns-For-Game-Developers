namespace Nojumpo.Collections
{
    public abstract class LinkedList<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        public LinkedListNode<T> Head { get { return _head; } }
        public int Count { get { return _count; } }

        protected LinkedListNode<T> _head;
        protected int _count;

        // ----------------------------- CONSTRUCTORS ------------------------------
        protected LinkedList() {
            _head = null;
            _count = 0;
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public abstract void Add(T item);

        public void Clear() {
            if (_head == null)
                return;

            LinkedListNode<T> previousNode = _head;
            LinkedListNode<T> currentNode = _head.Next;
            previousNode.Next = null;

            while (currentNode != null)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
                previousNode.Next = null;
            }

            _head = null;
            _count = 0;
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}