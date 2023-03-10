using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Grabli.DataStructures
{
	public partial class TreeNodeChildrenExTests
	{
		[Test]
		public void CheckCountIfNoChildren()
		{
			Mock<TreeNodeChildren<int>> mock = new Mock<TreeNodeChildren<int>>();
			mock.Setup(children => children.Nodes).Returns(new List<TreeNode<int>>());
			var count = mock.Object.Count();
			Assert.Zero(count);
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(100)]
		public void CheckIsEmptyIfThereAreChildren(int expected)
		{
			Mock<TreeNodeChildren<int>> mock = new Mock<TreeNodeChildren<int>>();
			mock.Setup(children => children.Nodes).Returns(() =>
			{
				var nodes = new List<TreeNode<int>>();
				for (int i = 0; i < expected; nodes.Add(null), ++i)
                {
                    
                }

                return nodes;
			});
			var count = mock.Object.Count();
			Assert.AreEqual(expected, count);
		}
	}
}
