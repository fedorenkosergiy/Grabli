using NUnit.Framework;

namespace Grabli.DataStructures
{
	public partial class DefaultTreeNodeChildrenTests
	{
		[Test]
		public void CheckIfContainsRetunrsFalseInCaseOfEmptyChildren()
		{
			var factory = CreateFakeFactory<object>();
			var node = factory.CreateRootNode();
			var children = new DefaultTreeNodeChildren<object>(factory, node);
			bool contains = children.Contains(null);
			Assert.IsFalse(contains);
		}

		[Test]
		public void CheckIfContainsReturnsTrueIfChildWasAdded()
		{
			var factory = CreateFakeFactory<object>();
			var node = factory.CreateRootNode();
			var children = new DefaultTreeNodeChildren<object>(factory, node);
			var item = new object();
			children.Add(item);
			bool contains = children.Contains(item);
			Assert.IsTrue(contains);
		}

		[Test]
		public void CheckIfContainsReturnsTrueIfTheSameChildWasAddedTwice()
		{
			var factory = CreateFakeFactory<object>();
			var node = factory.CreateRootNode();
			var children = new DefaultTreeNodeChildren<object>(factory, node);
			var item = new object();
			children.Add(item);
			children.Add(item);
			bool contains = children.Contains(item);
			Assert.IsTrue(contains);
		}

		[Test]
		public void CheckIfContainsWorksWithNullItem()
		{
			var factory = CreateFakeFactory<object>();
			var node = factory.CreateRootNode();
			var children = new DefaultTreeNodeChildren<object>(factory, node);
			children.Add(default);
			bool contains = children.Contains(default);
			Assert.IsTrue(contains);
		}
	}
}
