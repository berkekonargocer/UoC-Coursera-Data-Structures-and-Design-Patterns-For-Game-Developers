using System.Text;

namespace NOJUMPO.Collections
{
    public abstract class NJLinkedList<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        public NJLinkedListNode<T> Head { get { return _head; } }
        public int Count { get { return _count; } }

        protected NJLinkedListNode<T> _head;
        protected int _count;

        // ----------------------------- CONSTRUCTORS ------------------------------
        protected NJLinkedList() {
            _head = null;
            _count = 0;
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public abstract void Add(T item);

        public void Clear() {
            if (_head == null)
                return;

            NJLinkedListNode<T> previousNode = _head;
            NJLinkedListNode<T> currentNode = _head.Next;
            previousNode.Next = null;

            while (currentNode != null)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
                previousNode.Next = null;
                previousNode.Previous = null;
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
                if (_head.Next != null)
                {
                    _head.Next.Previous = null;
                }
                _head = _head.Next;
                _count--;

                return true;
            }
            
            NJLinkedListNode<T> currentNode = _head.Next;

            while (currentNode != null && !currentNode.Value.Equals(item))
            {
                currentNode = currentNode.Next;
            }

            if (currentNode == null)
            {
                return false;
            }

            if (currentNode.Previous.Next != null)
            {
                currentNode.Previous.Next.Previous = currentNode.Previous;
            }
            _count--;

            return true;
        }

        public NJLinkedListNode<T> Find(T item) {
            NJLinkedListNode<T> currentNode = _head;

            while (currentNode != null && !currentNode.Value.Equals(item))
            {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }

        public override string ToString() {
            StringBuilder builder = new StringBuilder();
            NJLinkedListNode<T> currentNode = _head;

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
    }
}