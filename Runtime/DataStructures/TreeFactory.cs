namespace Grabli.DataStructures
{
	public interface TreeFactory<T>
	{
		TreeNode<T> CreateRootNode(T value);
		TreeNode<T> CreateNode(T value, TreeNode<T> parrent);
		TreeNodeChildren<T> CreateNodeChildren(TreeNode<T> owner);
	}
}
