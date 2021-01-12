namespace Grabli.DataStructures
{
	public static class TreeNodeEx
	{
		public static bool IsLeaf<T>(this TreeNode<T> value) => value.Children.IsEmpty();

		public static int Depth<T>(this TreeNode<T> value) => IsRoot(value) ? 0 : value.Parent.Depth() + 1;

		public static bool IsRoot<T>(this TreeNode<T> value) => value.Parent.IsNull();

		public static TreeNode<T> Root<T>(this TreeNode<T> node) => node.IsRoot() ? node : Root(node.Parent);

		public static int Count<T>(this TreeNode<T> localRoot)
		{
			int result = 1;
			for(int i = 0; i < localRoot.Children.Count(); ++i)
			{
				result += localRoot.Children.Nodes[i].Count();
			}
			return result;
		}
	}
}
