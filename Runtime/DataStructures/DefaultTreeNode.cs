using JetBrains.Annotations;

namespace Grabli.DataStructures
{
    public class DefaultTreeNode<T> : TreeNode<T>
    {
        public T Item { get; }

        public TreeNodeChildren<T> Children { get; }

        public TreeNode<T> Parent { get; }

        public DefaultTreeNode(TreeFactory<T> factory, TreeNode<T> parent, T item) : this(factory, item)
        {
            Parent = parent;
        }

        public DefaultTreeNode([NotNull] TreeFactory<T> factory, T item)
        {
            if (factory.IsNull()) throw new System.ArgumentNullException(nameof(factory));
            Item = item;
            Children = factory.CreateNodeChildren(this);
        }
    }
}