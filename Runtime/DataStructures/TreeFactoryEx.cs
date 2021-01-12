namespace Grabli.DataStructures
{
	public static class TreeFactoryEx
	{
		public static TreeNode<T> CreateRootNode<T>(this TreeFactory<T> factory) => factory.CreateRootNode(default);
	}
}
