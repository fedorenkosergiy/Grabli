namespace Grabli.DataStructures
{
	public static class TreeNodeChildrenEx
	{
		public static bool IsNotEmpty<T>(this TreeNodeChildren<T> value) => !IsEmpty(value);

		public static bool IsEmpty<T>(this TreeNodeChildren<T> value) => Count(value) == 0;

		public static int Count<T>(this TreeNodeChildren<T> value) => value.Nodes.Count;

		public static bool TryAddUnique<T>(this TreeNodeChildren<T> value, T item)
		{
			bool result = !value.Contains(item);
			if (result)
			{
				value.Add(item);
			}
			return result;
		}
	}
}
