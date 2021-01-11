using NUnit.Framework;

namespace Grabli.DataStructures
{
	public partial class DefaultTreeNodeChildrenTests
	{
		[Test]
		public void CheckIfContainsRetunrsFalseInCaseOfEmptyChildren()
		{
			var children = new DefaultTreeNodeChildren<object>(CreateFakeFactory<object>());
			bool contains = children.Contains(null);
			Assert.IsFalse(contains);
		}

		[Test]
		public void CheckIfContainsReturnsTrueIfChildWasAdded()
		{
			var item = new object();
			var children = new DefaultTreeNodeChildren<object>(CreateFakeFactory<object>());
			children.Add(item);
			bool contains = children.Contains(item);
			Assert.IsTrue(contains);
		}

		[Test]
		public void CheckIfContainsReturnsTrueIfTheSameChildWasAddedTwice()
		{
			var item = new object();
			var children = new DefaultTreeNodeChildren<object>(CreateFakeFactory<object>());
			children.Add(item);
			children.Add(item);
			bool contains = children.Contains(item);
			Assert.IsTrue(contains);
		}

		[Test]
		public void CheckIfContainsWorksWithNullItem()
		{
			var children = new DefaultTreeNodeChildren<object>(CreateFakeFactory<object>());
			children.Add(default);
			bool contains = children.Contains(default);
			Assert.IsTrue(contains);
		}
	}
}
