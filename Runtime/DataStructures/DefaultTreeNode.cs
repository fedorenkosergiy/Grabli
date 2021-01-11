using System;
using System.Collections.Generic;

namespace Grabli.DataStructures
{
	public class DefaultTreeNode<T> : TreeNode<T>
	{
		public T Item => throw new NotImplementedException();

		public bool IsLeaf => throw new NotImplementedException();

		public bool IsRoot => throw new NotImplementedException();

		public IReadOnlyList<TreeNode<T>> Children => throw new NotImplementedException();

		public TreeNode<T> Parent => throw new NotImplementedException();

		public TreeNode<T> AddChild(T value)
		{
			throw new NotImplementedException();
		}

		public bool RemoveChild(T value)
		{
			throw new NotImplementedException();
		}
	}
}
