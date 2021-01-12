using NUnit.Framework;

namespace Grabli.DataStructures
{
	public partial class DefaultTreeNodeChildrenTests
	{
		[Test]
		public void CheckIfNodesFirstElementIsTheOnlyAddedItem()
		{
			var factory = CreateFakeFactory<object>();
			var node = factory.CreateRootNode();
			var children = new DefaultTreeNodeChildren<object>(factory, node);
			var subNode = children.Add(new object());
			Assert.AreEqual(subNode, children.Nodes[0]);
		}

		[Test]
		public void CheckIfNodesContainsTwoDifferentElementsAfterAddedTheSameItemTwice()
		{
			var factory = CreateFakeFactory<object>();
			var node = factory.CreateRootNode();
			var children = new DefaultTreeNodeChildren<object>(factory, node);
			var item = new object();
			children.Add(item);
			children.Add(item);
			Assert.AreNotEqual(children.Nodes[0], children.Nodes[1]);
		}

		[Test]
		public void CheckIfNodesIsNotNullWhenEmpty()
		{
			var factory = CreateFakeFactory<object>();
			var node = factory.CreateRootNode();
			var children = new DefaultTreeNodeChildren<object>(factory, node);
			Assert.IsNotNull(children.Nodes);
		}

		[Test]
		public void CheckIfNodesHasNoElementsRightAfterCreation()
		{
			var factory = CreateFakeFactory<object>();
			var node = factory.CreateRootNode();
			var children = new DefaultTreeNodeChildren<object>(factory, node);
			Assert.IsEmpty(children.Nodes);
		}
	}
}
