using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Grabli.DataStructures
{
	public partial class TreeNodeChildrenExTests
	{
		[Test]
		public void CheckIsEmptyIfNoChildren()
		{
			Mock<TreeNodeChildren<int>> mock = new Mock<TreeNodeChildren<int>>();
			mock.Setup(children => children.Nodes).Returns(new List<TreeNode<int>>());
			var empty = mock.Object.IsEmpty();
			Assert.True(empty);
		}

		[Test]
		public void CheckIsEmptyIfThereAreChildren()
		{
			Mock<TreeNodeChildren<int>> mock = new Mock<TreeNodeChildren<int>>();
			mock.Setup(children => children.Nodes).Returns(new List<TreeNode<int>>() {null});
			var empty = mock.Object.IsEmpty();
			Assert.False(empty);
		}
	}
}
