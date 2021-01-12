namespace Grabli.DataStructures
{
	public class DefaultTreeNode<T> : TreeNode<T>
	{
		private TreeFactory<T> factory;

		public T Item { get; private set; }

		public TreeNodeChildren<T> Children { get; private set; }

		public TreeNode<T> Parent { get; private set; }

		public DefaultTreeNode(TreeFactory<T> factory, TreeNode<T> parent, T item):this(factory, item)
		{
			Parent = parent;
		}

		public DefaultTreeNode(TreeFactory<T> factory, T item)
		{
			factory.TryThrowArgumentNullException(nameof(factory));
			this.factory = factory;
			Item = item;
			Children = factory.CreateNodeChildren(this);
		}
	}
}
