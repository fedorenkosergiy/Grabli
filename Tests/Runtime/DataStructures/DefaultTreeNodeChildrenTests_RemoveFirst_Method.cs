using NUnit.Framework;

namespace Grabli.DataStructures
{
	public partial class DefaultTreeNodeChildrenTests
	{
		[Test]
		public void CheckIfRemoveFirstReturnsFalseWhenChildrenIsEmpty()
		{
			var children = new DefaultTreeNodeChildren<object>(CreateFakeFactory<object>());
			var success = children.RemoveFirst(new object());
			Assert.IsFalse(success);
		}

		[Test]
		public void CheckIfRemoveFirstReturnsTrueWhenRemovingChild()
		{
			var item = new object();
			var children = new DefaultTreeNodeChildren<object>(CreateFakeFactory<object>());
			children.Add(item);
			var success = children.RemoveFirst(item);
			Assert.IsTrue(success);
		}

		[Test]
		public void CheckIfRemoveFirstDoesntRemoveSecond()
		{
			var item = new object();
			var children = new DefaultTreeNodeChildren<object>(CreateFakeFactory<object>());
			children.Add(item);
			children.Add(item);
			children.RemoveFirst(item);
			var success = children.RemoveFirst(item);
			Assert.IsTrue(success);
		}

		[Test]
		public void CheckIfRemoveFirstWorksWithNull()
		{
			var children = new DefaultTreeNodeChildren<object>(CreateFakeFactory<object>());
			children.Add(default);
			var success = children.RemoveFirst(default);
			Assert.IsTrue(success);
		}
	}
}
