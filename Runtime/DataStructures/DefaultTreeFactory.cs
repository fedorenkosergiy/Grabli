namespace Grabli.DataStructures
{
	public class DefaultTreeFactory<T> : TreeFactory<T>
	{
		public TreeNode<T> CreateRootNode(T item) => new DefaultTreeNode<T>(this, item);

		public TreeNodeChildren<T> CreateNodeChildren(TreeNode<T> owner)
		{
			return new DefaultTreeNodeChildren<T>(this, owner);
		}

		public TreeNode<T> CreateNode(T item, TreeNode<T> parent)
		{
			return new DefaultTreeNode<T>(this, parent, item);
		}
	}
}
