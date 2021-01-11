using NUnit.Framework;

namespace Grabli.DataStructures
{
	public partial class DefaultTreeNodeChildrenTests
	{
		[Test]
		public void CheckIfNodesFirstElementIsTheOnlyAddedItem()
		{
			var item = new object();
			var children = new DefaultTreeNodeChildren<object>(CreateFakeFactory<object>());
			var node = children.Add(item);
			Assert.AreEqual(node, children.Nodes[0]);
		}

		[Test]
		public void CheckIfNodesContainsTwoDifferentElementsAfterAddedTheSameItemTwice()
		{
			var item = new object();
			var children = new DefaultTreeNodeChildren<object>(CreateFakeFactory<object>());
			children.Add(item);
			children.Add(item);
			Assert.AreNotEqual(children.Nodes[0], children.Nodes[1]);
		}

		[Test]
		public void CheckIfNodesIsNotNullWhenEmpty()
		{
			var children = new DefaultTreeNodeChildren<object>(CreateFakeFactory<object>());
			Assert.IsNotNull(children.Nodes);
		}

		[Test]
		public void CheckIfNodesHasNoElementsRightAfterCreation()
		{
			var children = new DefaultTreeNodeChildren<object>(CreateFakeFactory<object>());
			Assert.IsEmpty(children.Nodes);
		}
	}
}
