using System.Collections.Generic;
using System.Text;

namespace NOJUMPO.Collections
{
    public class MinimaxTreeNode<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        public T Value { get { return _value; } }
        public MinimaxTreeNode<T> Parent { get { return _parent; } set { _parent = value; } }
        public IList<MinimaxTreeNode<T>> Children { get { return _children.AsReadOnly(); } }
        public int MinimaxScore { get { return _minimaxScore; } set { _minimaxScore = value; } }
        public int Count { get { return _children.Count; } }


        T _value;
        MinimaxTreeNode<T> _parent;
        List<MinimaxTreeNode<T>> _children;
        int _minimaxScore;


        // ----------------------------- CONSTRUCTORS ------------------------------
        public MinimaxTreeNode(T value, MinimaxTreeNode<T> parent) {
            _value = value;
            _parent = parent;
            _children = new List<MinimaxTreeNode<T>>();
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------

        // O(n)
        public bool AddChild(MinimaxTreeNode<T> child) {
            if (_children.Contains(child))
            {
                return false;
            }

            if (child == this)
            {
                return false;
            }

            child.Parent = this;
            _children.Add(child);
            return true;
        }

        // O(n)
        public virtual bool RemoveChild(MinimaxTreeNode<T> child) {
            if (!_children.Contains(child))
                return false;

            child.Parent = null;
            return _children.Remove(child);
        }

        // O(n)
        public bool RemoveAllChildren() {
            for (int i = _children.Count; i >= 0; i--)
            {
                _children[i].Parent = null;
                _children.RemoveAt(i);
            }

            return true;
        }

        // O(n)
        public override string ToString() {
            StringBuilder treeNodeString = new StringBuilder();

            treeNodeString.Append($"[Node Value: {Value} Parent Value: ");

            if (_parent != null)
            {
                treeNodeString.Append($"{_parent.Value} ");
            }
            else
            {
                treeNodeString.Append("null ");
            }

            treeNodeString.Append("Children Values: ");

            for (int i = 0; i < _children.Count; i++)
            {
                treeNodeString.Append($"{_children[i].Value}");

                if (i < _children.Count - 1)
                {
                    treeNodeString.Append(", ");
                }
            }

            treeNodeString.Append("]");

            return treeNodeString.ToString();
        }
    }
}