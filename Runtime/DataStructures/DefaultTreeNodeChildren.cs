using System.Collections.Generic;

namespace Grabli.DataStructures
{
	public class DefaultTreeNodeChildren<T> : TreeNodeChildren<T>
	{
		private TreeFactory<T> factory;
		private TreeNode<T> owner;
		private List<TreeNode<T>> nodes = new List<TreeNode<T>>();
		private IList<T> items = new List<T>();
		private Dictionary<T, int> counts = new Dictionary<T, int>();
		private int nullsCount;

		public IReadOnlyList<TreeNode<T>> Nodes => nodes;

		public DefaultTreeNodeChildren(TreeFactory<T> factory, TreeNode<T> owner)
		{
			this.factory = factory;
			this.owner = owner;
		}

		public TreeNode<T> Add(T value)
		{
			TreeNode<T> node = factory.CreateRootNode(value);
			nodes.Add(node);
			items.Add(value);
			if (value == null)
			{
				nullsCount++;
			}
			else if (Contains(value))
			{
				AddDuplicatedItem(value);
			}
			else
			{
				AddUniqueItem(value);
			}

			return node;
		}

		private void AddDuplicatedItem(T value)
		{
			counts[value]++;
		}

		private void AddUniqueItem(T value)
		{
			counts.Add(value, 1);
			Queue<int> indecesOfItem = new Queue<int>();
			indecesOfItem.Enqueue(nodes.LastIndex());
		}

		public bool Contains(T value)
		{
			return value == null ? nullsCount > 0 : counts.ContainsKey(value);
		}

		public bool RemoveFirst(T value)
		{
			bool shouldBeRemoved = value == null ? ShouldBeRemovedNullItem() : ShouldBeRemovedItem(value);

			if (shouldBeRemoved)
			{
				int index = items.IndexOf(value);
				nodes.RemoveAt(index);
				items.RemoveAt(index);
			}
			return shouldBeRemoved;
		}

		private bool ShouldBeRemovedNullItem()
		{
			bool shouldBeRemoved = nullsCount > 0;
			if (shouldBeRemoved)
			{
				nullsCount--;
			}
			return shouldBeRemoved;
		}

		private bool ShouldBeRemovedItem(T value)
		{
			bool shouldBeRemoved = counts.TryGetValue(value, out int count);
			if (shouldBeRemoved)
			{
				if (count == 1)
				{
					counts.Remove(value);
				}
				else
				{
					counts[value] = count - 1;
				}
			}

			return shouldBeRemoved;
		}
	}
}
