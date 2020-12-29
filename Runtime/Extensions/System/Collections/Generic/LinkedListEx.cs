namespace System.Collections.Generic
{
	public static class LinkedListEx
	{
		public static bool IsEmpty<T>(this LinkedList<T> list)
		{
			return ((ICollection)list).IsEmpty();
		}
	}
}
