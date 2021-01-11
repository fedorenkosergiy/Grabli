using System;

namespace Grabli.DataStructures
{
	public class DefaultTreeNode<T> : TreeNode<T>
	{
		public T Item => throw new NotImplementedException();

		public TreeNodeChildren<T> Children => throw new NotImplementedException();

		public TreeNode<T> Parent => throw new NotImplementedException();

		public DefaultTreeNode(T item)
		{
			throw new NotImplementedException();
		}
	}
}
