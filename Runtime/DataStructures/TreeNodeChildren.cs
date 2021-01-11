using System.Collections.Generic;

namespace Grabli.DataStructures
{
	public interface TreeNodeChildren<T>
	{
		IReadOnlyList<TreeNode<T>> Nodes { get; }
		TreeNode<T> Add(T value);
		bool RemoveFirst(T value);
		bool Contains(T value);
	}
}
