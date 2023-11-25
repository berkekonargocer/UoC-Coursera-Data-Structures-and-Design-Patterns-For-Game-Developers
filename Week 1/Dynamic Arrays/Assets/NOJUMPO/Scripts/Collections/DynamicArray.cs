using System;
using System.Text;

namespace Nojumpo.Collections
{
    public abstract class DynamicArray<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        const int ExpandMultiplyFactor = 2;
        protected T[] _items;
        public int Count { get { return _count; } }
        protected int _count;


        // ----------------------------- CONSTRUCTORS ------------------------------
        protected DynamicArray() {
            _items = new T[4];
            _count = 0;
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public abstract void Add(T item);
        public abstract bool Remove(T item);
        public abstract int IndexOf(T item);

        // O(1)
        public void Clear() {
            _count = 0;
        }

        // O(n)
        public override String ToString() {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < _count; i++)
            {
                builder.Append(_items[i]);

                if (i < _count - 1)
                {
                    builder.Append(",");
                }
            }

            return builder.ToString();
        }


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------
        
        // O(n)
        protected void Expand() {
            T[] newItems = new T[_items.Length * ExpandMultiplyFactor];

            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;
        }
    }
}