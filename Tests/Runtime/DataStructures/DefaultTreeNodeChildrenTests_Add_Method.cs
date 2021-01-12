using NUnit.Framework;
using System;

namespace Grabli.DataStructures
{
	public partial class DefaultTreeNodeChildrenTests
	{
		[Test]
		public void CheckIfAddReturnsNodeWithRightItem()
		{
			var factory = CreateFakeFactory<object>();
			var node = factory.CreateRootNode();
			var item = new object();
			var children = new DefaultTreeNodeChildren<object>(factory, node);
			var child = children.Add(item);
			Assert.AreEqual(item, child.Item);
		}

		[Test]
		public void CheckIfAddWorksWhenParameterIsNull()
		{
			var factory = CreateFakeFactory<object>();
			var node = factory.CreateRootNode();
			var children = new DefaultTreeNodeChildren<object>(factory, node);
			var child = children.Add(null);
			Assert.IsNull(child.Item);
		}

		[Test]
		public void CheckIfAddWorksWhenParameterIsDefaultStruct()
		{
			var factory = CreateFakeFactory<DateTime>();
			var node = factory.CreateRootNode();
			var children = new DefaultTreeNodeChildren<DateTime>(factory, node);
			var child = children.Add(default);
			Assert.AreEqual(default(DateTime), child.Item);
		}

		[Test]
		public void CheckIfAddWorksTwice()
		{
			var factory = CreateFakeFactory<object>();
			var node = factory.CreateRootNode();
			var item = new object();
			var children = new DefaultTreeNodeChildren<object>(factory, node);
			var childA = children.Add(item);
			var childB = children.Add(item);
			Assert.AreNotEqual(childA, childB);
			Assert.AreEqual(item, childB.Item);
		}

		[Test]
		public void CheckIfAddProvidesNewNodeWithParent()
		{
			var factory = CreateFakeFactory<object>();
			var root = factory.CreateRootNode();
			var children = new DefaultTreeNodeChildren<object>(factory, root);
			var node = children.Add(null);
			Assert.AreSame(node.Parent, root);
		}
	}
}
