namespace Grabli.DataStructures
{
	public interface TreeFactory<T>
	{
		TreeNode<T> CreateNode(T value);
		TreeNodeChildren<T> CreateNodeChildren();
	}
}
