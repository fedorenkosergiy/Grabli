using Moq;

namespace Grabli.DataStructures
{
	public partial class DefaultTreeNodeTests
	{
		private TreeFactory<T> CreateFakeFactory<T>()
		{
			Mock<TreeFactory<T>> factoryMock = new Mock<TreeFactory<T>>();
			factoryMock.Setup(factory => factory.CreateNodeChildren(
				It.IsAny<TreeNode<T>>()))
				.Returns(() => new Mock<TreeNodeChildren<T>>().Object
			);
			return factoryMock.Object;
		}
	}
}
