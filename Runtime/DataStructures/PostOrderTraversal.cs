using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grabli.DataStructures
{
	public class PostOrderTraversal<T> : IEnumerable<T>
	{
		private TreeNode<T> localRoot;

		public PostOrderTraversal(TreeNode<T> localRoot)
		{
			this.localRoot = localRoot;
		}

		public IEnumerator<T> GetEnumerator()
		{
			int count = localRoot.Count();
			List<T> list = new List<T>(count);
			PopulateCollectionWithItems(list, localRoot);
			return list.GetEnumerator();
		}

		private void PopulateCollectionWithItems(ICollection<T> list, TreeNode<T> node)
		{
			for (int i = 0; i < node.Children.Nodes.Count; ++i)
			{
				PopulateCollectionWithItems(list, node.Children.Nodes[i]);
			}
			list.Add(node.Item);
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}