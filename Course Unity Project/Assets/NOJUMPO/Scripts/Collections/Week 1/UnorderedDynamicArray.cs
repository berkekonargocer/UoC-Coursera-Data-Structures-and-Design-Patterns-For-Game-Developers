namespace Nojumpo.Collections
{
    public class UnorderedDynamicArray<T> : DynamicArray<T>
    {
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        
        // Worst Case: O(n) Best Case: O(1)
        public override void Add(T item) {
            if (_count == _items.Length)
            {
                Expand();
            }

            _items[_count] = item;
            _count++;
        }

        // O(n)
        public override bool Remove(T item) {
            int itemLocation = IndexOf(item);

            if (itemLocation == -1)
            {
                return false;
            }

            _items[itemLocation] = _items[_count - 1];
            _count--;
            return true;
        }

        // O(n)
        public override int IndexOf(T item) {
            for (int i = 0; i < _count; i++)
            {
                if (_items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}