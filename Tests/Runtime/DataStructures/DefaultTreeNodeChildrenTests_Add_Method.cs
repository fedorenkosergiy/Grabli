using NUnit.Framework;
using System;

namespace Grabli.DataStructures
{
	public partial class DefaultTreeNodeChildrenTests
	{
		[Test]
		public void CheckIfAddReturnsNodeWithRightItem()
		{
			var item = new object();
			var children = new DefaultTreeNodeChildren<object>(CreateFakeFactory<object>());
			var child = children.Add(item);
			Assert.AreEqual(item, child.Item);
		}

		[Test]
		public void CheckIfAddWorksWhenParameterIsNull()
		{
			var children = new DefaultTreeNodeChildren<object>(CreateFakeFactory<object>());
			var child = children.Add(null);
			Assert.IsNull(child.Item);
		}

		[Test]
		public void CheckIfAddWorksWhenParameterIsDefaultStruct()
		{
			var children = new DefaultTreeNodeChildren<DateTime>(CreateFakeFactory<DateTime>());
			var child = children.Add(default);
			Assert.AreEqual(default(DateTime), child.Item);
		}

		[Test]
		public void CheckIfAddWorksTwice()
		{
			var item = new object();
			var children = new DefaultTreeNodeChildren<object>(CreateFakeFactory<object>());
			var childA = children.Add(item);
			var childB = children.Add(item);
			Assert.AreNotEqual(childA, childB);
			Assert.AreEqual(item, childB.Item);
		}
	}
}
