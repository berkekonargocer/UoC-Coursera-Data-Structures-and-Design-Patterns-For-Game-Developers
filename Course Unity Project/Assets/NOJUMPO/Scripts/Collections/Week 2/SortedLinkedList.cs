using System;

namespace Nojumpo.Collections
{
    public class SortedLinkedList<T> : LinkedList<T> where T : IComparable
    {
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Add(T item) {
            if (_head == null)
            {
                _head = new LinkedListNode<T>(item, null);
            }
            else if (_head.Value.CompareTo(item) > 0)
            {
                _head = new LinkedListNode<T>(item, _head);
            }
            else
            {
                LinkedListNode<T> previousNode = null;
                LinkedListNode<T> currentNode = _head;

                while (currentNode != null && currentNode.Value.CompareTo(item) < 0)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.Next;
                }

                previousNode.Next = new LinkedListNode<T>(item, currentNode);
            }

            _count++;
        }
    }
}