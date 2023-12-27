using System;

namespace NOJUMPO.Collections
{
    public class SortedNJLinkedList<T> : NJLinkedList<T> where T : IComparable
    {
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Add(T item) {
            if (_head == null)
            {
                _head = new NJLinkedListNode<T>(item, null, null);
            }
            else if (_head.Value.CompareTo(item) > 0)
            {
                _head.Previous = new NJLinkedListNode<T>(item, null, _head);
                _head = _head.Previous;
            }
            else
            {
                NJLinkedListNode<T> previousNode = _head;
                NJLinkedListNode<T> currentNode = _head.Next;

                while (currentNode != null && currentNode.Value.CompareTo(item) < 0)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.Next;
                }

                if (currentNode == null)
                {
                    previousNode.Next = new NJLinkedListNode<T>(item, previousNode, null);
                }
                else
                {
                    previousNode.Next = new NJLinkedListNode<T>(item, previousNode, currentNode);
                    currentNode.Previous = previousNode.Next;
                }
            }

            _count++;
        }
    }
}