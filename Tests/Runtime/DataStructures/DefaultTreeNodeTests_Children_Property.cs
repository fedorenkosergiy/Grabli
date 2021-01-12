using NUnit.Framework;

namespace Grabli.DataStructures
{
	public partial class DefaultTreeNodeTests
	{
		[Test]
		public void CheckChildrenIfNotNull()
		{
			var node = new DefaultTreeNode<object>(CreateFakeFactory<object>(), new object());
			Assert.IsNotNull(node.Children);
		}

		[Test]
		public void CheckChildrenIfDoesNotThrow()
		{
			var node = new DefaultTreeNode<object>(CreateFakeFactory<object>(), new object());
			Assert.DoesNotThrow(() =>
			{
				var children = node.Children;
			});
		}
	}
}
