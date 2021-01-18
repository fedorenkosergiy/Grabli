using Moq;
using NUnit.Framework;

namespace Grabli.DataStructures
{
	public partial class TreeNodeExTests
	{
		[Test]
		public void CheckIsRootWhereThereIsNoParent()
		{
			Mock<TreeNode<int>> mock = new Mock<TreeNode<int>>();
			mock.Setup(node => node.Parent).Returns(() => null);
			bool isRoot = mock.Object.IsRoot();
			Assert.True(isRoot);
		}

		[Test]
		public void CheckIsRootWhereThereIsParent()
		{
			Mock<TreeNode<int>> parent = new Mock<TreeNode<int>>();

			Mock<TreeNode<int>> mock = new Mock<TreeNode<int>>();
			mock.Setup(node => node.Parent).Returns(() => parent.Object);
			bool isRoot = mock.Object.IsRoot();
			Assert.False(isRoot);
		}
	}
}
