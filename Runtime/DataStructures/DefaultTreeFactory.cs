namespace Grabli.DataStructures
{
	public class DefaultTreeFactory<T> : TreeFactory<T>
	{
		public TreeNode<T> CreateNode(T item) => new DefaultTreeNode<T>(item);

		public TreeNodeChildren<T> CreateNodeChildren() => new DefaultTreeNodeChildren<T>(this);
	}
}
