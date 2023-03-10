using System;

namespace Grabli.DataStructures
{
	public partial class PostOrderTraversalTests
	{
		private int [] ParseNumbers(string raw)
		{
			string [] rawNumbers = raw.Split(',');
			int[] numbers = new int[rawNumbers.Length];
			for(int i = 0; i < numbers.Length; ++i)
			{
				numbers[i] = int.Parse(rawNumbers[i]);
			}
			return numbers;
		}

		private TreeNode<int> CreateBinaryTree(int[] numbers)
		{
			var factory = new DefaultTreeFactory<int>();
			TreeNode<int> root = factory.CreateRootNode(numbers[0]);
			for (int i = 1; i < numbers.Length; ++i)
			{
				AddSubNode(root, numbers[i]);
			}
			return root;
		}

		private void AddSubNode(TreeNode<int> localRoot, int value)
		{
			if (value < localRoot.Item)
			{
				var leftSubtree = GetLeftSubtree(localRoot);
				if (leftSubtree.IsNull())
				{
					localRoot.Children.Add(value);
				}
				else
				{
					AddSubNode(leftSubtree, value);
				}
			}
			else
			{
				var rightSubtree = GetRightSubtree(localRoot);
				if (rightSubtree.IsNull())
				{
					localRoot.Children.Add(value);
				}
				else
				{
					AddSubNode(rightSubtree, value);
				}
			}
		}

		private TreeNode<int> GetLeftSubtree(TreeNode<int> localRoot) => GetSubTree(localRoot, Math.Min);

		private TreeNode<int> GetSubTree(TreeNode<int> localRoot, Func<int, int, int> comparison)
		{
			if (localRoot.Children.IsEmpty())
            {
                return null;
            }

            int firstChild = localRoot.Children.Nodes[0].Item;
			if (localRoot.Children.Count() == 2)
			{
				int secondChild = localRoot.Children.Nodes[1].Item;
				int index = comparison(firstChild, secondChild) == firstChild ? 0 : 1;
				return localRoot.Children.Nodes[index];
			}
			return comparison(firstChild, localRoot.Item) == firstChild ? localRoot.Children.Nodes[0] : null;
		}
		private TreeNode<int> GetRightSubtree(TreeNode<int> localRoot) => GetSubTree(localRoot, Math.Max);
	}
}
