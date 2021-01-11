using System.Collections.Generic;

namespace Grabli.DataStructures
{
	public interface TreeNode<T>
	{
		T Item { get; }
		bool IsLeaf { get; }
		bool IsRoot { get; }
		IReadOnlyList<TreeNode<T>> Children { get; }
		TreeNode<T> Parent { get; }
		TreeNode<T> AddChild(T value);
		bool RemoveChild(T value);
	}
}
