using System;

namespace Nojumpo.Collections
{
    public class SortedLinkedList<T> : LinkedList<T> where T : IComparable
    {
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Add(T item) {
            if (_head == null)
            {
                _head = new LinkedListNode<T>(item, null, null);
            }
            else if (_head.Value.CompareTo(item) > 0)
            {
                _head.Previous = new LinkedListNode<T>(item, null, _head);
                _head = _head.Previous;
            }
            else
            {
                LinkedListNode<T> previousNode = _head;
                LinkedListNode<T> currentNode = _head.Next;

                while (currentNode != null && currentNode.Value.CompareTo(item) < 0)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.Next;
                }

                if (currentNode == null)
                {
                    previousNode.Next = new LinkedListNode<T>(item, previousNode, null);
                }
                else
                {
                    previousNode.Next = new LinkedListNode<T>(item, previousNode, currentNode);
                    currentNode.Previous = previousNode.Next;
                }
            }

            _count++;
        }
    }
}