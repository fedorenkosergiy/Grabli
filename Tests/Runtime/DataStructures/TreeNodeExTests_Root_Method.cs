using Moq;
using NUnit.Framework;

namespace Grabli.DataStructures
{
	public partial class TreeNodeExTests
	{
		[Test]
		public void CheckRootWhereThereIsNoParent()
		{
			Mock<TreeNode<int>> mock = new Mock<TreeNode<int>>();
			mock.Setup(node => node.Parent).Returns(() => null);
			TreeNode<int> root = mock.Object.Root();
			Assert.AreSame(root, mock.Object);
		}

		[Test]
		public void CheckRootWhereThereIsParent()
		{
			Mock<TreeNode<int>> parent = new Mock<TreeNode<int>>();
			Mock<TreeNode<int>> mock = new Mock<TreeNode<int>>();
			mock.Setup(node => node.Parent).Returns(() => parent.Object);
			TreeNode<int> root = mock.Object.Root();
			Assert.AreSame(root, parent.Object);
		}
	}
}
