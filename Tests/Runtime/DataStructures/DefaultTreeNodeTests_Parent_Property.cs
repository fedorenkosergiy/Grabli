using NUnit.Framework;

namespace Grabli.DataStructures
{
	public partial class DefaultTreeNodeTests
	{
		[Test]
		public void CheckParrentIfIsNull()
		{
			var node = new DefaultTreeNode<object>(CreateFakeFactory<object>(), null);
			Assert.IsNull(node.Parent);
		}

		[Test]
		public void CheckParrentIfIsNotRoot()
		{
			var factory = CreateFakeFactory<object>();
			var root = factory.CreateRootNode(new object());
			var node = new DefaultTreeNode<object>(factory, root, new object());
			Assert.AreSame(root, node.Parent);
		}
	}
}
