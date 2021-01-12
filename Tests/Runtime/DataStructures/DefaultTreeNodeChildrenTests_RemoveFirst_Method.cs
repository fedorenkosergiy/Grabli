using NUnit.Framework;

namespace Grabli.DataStructures
{
	public partial class DefaultTreeNodeChildrenTests
	{
		[Test]
		public void CheckIfRemoveFirstReturnsFalseWhenChildrenIsEmpty()
		{
			var factory = CreateFakeFactory<object>();
			var node = factory.CreateRootNode();
			var children = new DefaultTreeNodeChildren<object>(factory, node);
			var success = children.RemoveFirst(new object());
			Assert.IsFalse(success);
		}

		[Test]
		public void CheckIfRemoveFirstReturnsTrueWhenRemovingChild()
		{
			var factory = CreateFakeFactory<object>();
			var node = factory.CreateRootNode();
			var children = new DefaultTreeNodeChildren<object>(factory, node);
			var item = new object();
			children.Add(item);
			var success = children.RemoveFirst(item);
			Assert.IsTrue(success);
		}

		[Test]
		public void CheckIfRemoveFirstDoesntRemoveSecond()
		{
			var factory = CreateFakeFactory<object>();
			var node = factory.CreateRootNode();
			var children = new DefaultTreeNodeChildren<object>(factory, node);
			var item = new object();
			children.Add(item);
			children.Add(item);
			children.RemoveFirst(item);
			var success = children.RemoveFirst(item);
			Assert.IsTrue(success);
		}

		[Test]
		public void CheckIfRemoveFirstWorksWithNull()
		{
			var factory = CreateFakeFactory<object>();
			var node = factory.CreateRootNode();
			var children = new DefaultTreeNodeChildren<object>(factory, node);
			children.Add(default);
			var success = children.RemoveFirst(default);
			Assert.IsTrue(success);
		}
	}
}
