using System.Text;

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

        public bool Remove(T item) {
            if (_head == null)
            {
                return false;
            }

            if (_head.Value.Equals(item))
            {
                _head = _head.Next;
                _count--;

                return true;
            }

            LinkedListNode<T> previousNode = _head;
            LinkedListNode<T> currentNode = _head.Next;

            while (currentNode != null && !currentNode.Value.Equals(item))
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            if (currentNode == null)
            {
                return false;
            }

            previousNode.Next = currentNode.Next;
            _count--;

            return true;
        }

        public LinkedListNode<T> Find(T item) {
            LinkedListNode<T> currentNode = _head;

            while (currentNode != null && !currentNode.Value.Equals(item))
            {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }

        public override string ToString() {
            StringBuilder builder = new StringBuilder();
            LinkedListNode<T> currentNode = _head;

            int nodeCount = 0;

            while (currentNode != null)
            {
                nodeCount++;
                
                builder.Append(currentNode.Value);
                
                if (nodeCount < _count)
                {
                    builder.Append(",");
                }
                
                currentNode = currentNode.Next;
            }

            return builder.ToString();
        }

        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}