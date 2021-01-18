using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace Grabli.DataStructures
{
	public partial class TreeNodeChildrenExTests
	{
		[TestCase(1, 1, 1, 0)]
		[TestCase(1, 2, 1, 1)]
		public void CheckRemoveAll(int first, int second, int toRemove, int expectedCount)
		{
			List<int> added = new List<int>();
			Mock<TreeNodeChildren<int>> mock = new Mock<TreeNodeChildren<int>>();
			mock.Setup(children => children.Nodes).Returns(() =>
			{
				var nodes = new List<TreeNode<int>>();

				for (int i = 0; i < added.Count; ++i)
				{
					Mock<TreeNode<int>> nodeMock = new Mock<TreeNode<int>>();
					nodes.Add(nodeMock.Object);
				}
				return nodes;
			});
			mock.Setup(children => children.Add(It.IsAny<int>())).Callback<int>(added.Add);
			mock.Setup(children => children.RemoveFirst(It.IsAny<int>())).Returns<int>(added.Remove);
			mock.Object.Add(first);
			mock.Object.Add(second);
			mock.Object.RemoveAll(toRemove);
			int actualCount = mock.Object.Count();
			Assert.AreEqual(expectedCount, actualCount);
		}
	}
}
