using Moq;

namespace Grabli.DataStructures
{
	public partial class DefaultTreeNodeChildrenTests
	{
		private TreeFactory<T> CreateFakeFactory<T>()
		{
			Mock<TreeFactory<T>> factoryMock = new Mock<TreeFactory<T>>();
			factoryMock.Setup(factory => factory.CreateRootNode(
				It.IsAny<T>()))
				.Returns<T>(item =>
				{
					Mock<TreeNode<T>> nodeMock = new Mock<TreeNode<T>>();
					nodeMock.Setup(node => node.Item).Returns(item);
					return nodeMock.Object;
				});
			factoryMock.Setup(factory => factory.CreateNode(
				It.IsAny<T>(),
				It.IsAny<TreeNode<T>>()))
				.Returns<T, TreeNode<T>>((item, parent) =>
				{
					Mock<TreeNode<T>> nodeMock = new Mock<TreeNode<T>>();
					nodeMock.Setup(node => node.Item).Returns(item);
					nodeMock.Setup(node => node.Parent).Returns(parent);
					return nodeMock.Object;
				});
			return factoryMock.Object;
		}
	}
}