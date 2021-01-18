using Moq;
using NUnit.Framework;
namespace Grabli.DataStructures
{
	public partial class TreeNodeExTests
	{
		[Test]
		public void CheckDepthWhereThereIsNoParent()
		{
			Mock<TreeNode<int>> mock = new Mock<TreeNode<int>>();
			mock.Setup(node => node.Parent).Returns(() => null);
			var depth = mock.Object.Depth();
			Assert.AreEqual(0, depth);
		}

		[Test]
		public void CheckDepthWhereThereIsParent()
		{
			Mock<TreeNode<int>> parent = new Mock<TreeNode<int>>();

			Mock<TreeNode<int>> mock = new Mock<TreeNode<int>>();
			mock.Setup(node => node.Parent).Returns(() => parent.Object);
			var depth = mock.Object.Depth();
			Assert.AreEqual(1, depth);
		}
	}
}
