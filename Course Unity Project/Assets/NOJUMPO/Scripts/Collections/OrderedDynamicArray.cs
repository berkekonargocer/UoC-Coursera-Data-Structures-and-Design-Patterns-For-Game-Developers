using System;

namespace Nojumpo.Collections
{
    public class OrderedDynamicArray<T> : DynamicArray<T> where T : IComparable
    {
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        
        // O(n)
        public override void Add(T item) {
            if (_count == _items.Length)
            {
                Expand();
            }

            int addLocation = 0;

            while (addLocation < _count && _items[addLocation].CompareTo(item) < 0)
            {
                addLocation++;
            }

            ShiftUp(addLocation);
            _items[addLocation] = item;
            _count++;
        }

        // O(n)
        public override bool Remove(T item) {
            int itemLocation = IndexOf(item);

            if (itemLocation == -1)
            {
                return false;
            }

            ShiftDown(itemLocation + 1);
            _count--;
            return true;
        }

        // O(log n)
        public override int IndexOf(T item) {
            int lowerBound = 0;
            int upperBound = _count - 1;
            int itemLocation = -1;

            while (itemLocation == -1)
            {
                int middleLocation = lowerBound + (upperBound - lowerBound) / 2;
                T middleValue = _items[middleLocation];

                if (middleValue.CompareTo(item) == 0)
                {
                    itemLocation = middleLocation;
                }
                else
                {
                    if (middleValue.CompareTo(item) > 0)
                    {
                        upperBound = middleLocation - 1;
                    }
                    else
                    {
                        lowerBound = middleLocation + 1;
                    }

                    if (lowerBound > upperBound)
                    {
                        break;
                    }
                }
            }

            return itemLocation;
        }
        

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        
        // O(n)
        void ShiftUp(int index) {
            for (int i = _count; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }
        }
        
        // O(n)
        void ShiftDown(int index) {
            for (int i = index; i < _count; i++)
            {
                _items[i - 1] = _items[i];
            }
        }
    }
}