namespace Nojumpo.Collections
{
    public class BinaryTreeNode<T> : TreeNode<T>
    {
        // -------------------------------- FIELDS ---------------------------------
        TreeNode<T> leftChild;
        TreeNode<T> rightChild;

        public TreeNode<T> LeftChild { get { return leftChild; } }
        public TreeNode<T> RightChild { get { return rightChild; } }

        
        // ----------------------------- CONSTRUCTORS ------------------------------
        public BinaryTreeNode(T value, TreeNode<T> parent) : base(value, parent) {
            leftChild = null;
            rightChild = null;
        }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------


        // ------------------------ CUSTOM PROTECTED METHODS -----------------------


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
    }
}