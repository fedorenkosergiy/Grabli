namespace Grabli.DataStructures
{
	public interface TreeNode<T>
	{
		T Item { get; }
		TreeNodeChildren<T> Children { get; }
		TreeNode<T> Parent { get; }
	}
}
