using NUnit.Framework;

namespace Grabli.DataStructures
{
	public partial class DefaultTreeNodeTests
	{
		[Test]
		public void CheckItemIfDoesNotThrow()
		{
			var node = new DefaultTreeNode<object>(CreateFakeFactory<object>(), new object());
			Assert.DoesNotThrow(() =>
			{
				var item = node.Item;
			});
		}

		[Test]
		public void CheckItemIfItemIsTheSameObjectAsParameter()
		{
			var item = new object();
			var node = new DefaultTreeNode<object>(CreateFakeFactory<object>(), item);
			Assert.AreSame(item, node.Item);
		}
	}
}
