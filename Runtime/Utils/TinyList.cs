using System.Collections.Generic;

namespace Grabli.Utils
{
	public sealed class ListOfUniqs<T>
	{
		public const int MaxCapacity = 16;

		private List<T> list;

		public T this[int index] { get => list[index]; set => list[index] = value; }

		public int Count => list.Count;

		public ListOfUniqs() { list = new List<T>(); }

		public ListOfUniqs(int count)
		{
			CheckCount(count);
			list = new List<T>(count);
		}

		public ListOfUniqs(ICollection<T> collection)
		{
			CheckCount(collection.Count);
			list = new List<T>(collection);
		}

		private static void CheckCount(int targetCount)
		{
			if (targetCount > MaxCapacity) throw null;
		}

		public bool Add(T item)
		{
			if (Contains(item)) return false;
			CheckCount(Count + 1);
			list.Add(item);
			return true;
		}

		public void Clear() => list.Clear();

		public bool Contains(T item) => list.Contains(item);

		public IEnumerator<T> GetEnumerator() => list.GetEnumerator();

		public int IndexOf(T item) => list.IndexOf(item);

		public bool Remove(T item) => list.Remove(item);

		public void RemoveAt(int index) => list.RemoveAt(index);

		public T[] ToArray() => list.ToArray();
	}
}
