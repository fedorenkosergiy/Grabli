namespace System.Collections.Generic
{
	public static class IDictionaryEx
	{
		public static IReadOnlyList<KeyValuePair<TKey, TValue>> ToReadOnlyPairs<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
		{
			return new List<KeyValuePair<TKey, TValue>>(dictionary);
		}
	}
}
