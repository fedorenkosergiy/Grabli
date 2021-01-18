using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Grabli.DataStructures
{
	public partial class TreeNodeChildrenExTests
	{
		[Test]
		public void CheckIsNotEmptyIfNoChildren()
		{
			Mock<TreeNodeChildren<int>> mock = new Mock<TreeNodeChildren<int>>();
			mock.Setup(children => children.Nodes).Returns(new List<TreeNode<int>>());
			var notEmpty = mock.Object.IsNotEmpty();
			Assert.False(notEmpty);
		}

		[Test]
		public void CheckIsNotEmptyIfThereAreChildren()
		{
			Mock<TreeNodeChildren<int>> mock = new Mock<TreeNodeChildren<int>>();
			mock.Setup(children => children.Nodes).Returns(new List<TreeNode<int>>() {null});
			var notEmpty = mock.Object.IsNotEmpty();
			Assert.True(notEmpty);
		}
	}
}
