using NUnit.Framework;
using System;

namespace Grabli.DataStructures
{
	public partial class DefaultTreeNodeTests
	{
		[Test]
		public void CheckConsturctorIfDoesntThrow()
		{
			Assert.DoesNotThrow(() => new DefaultTreeNode<object>(CreateFakeFactory<object>(), new object()));
		}

		[Test]
		public void CheckConstructorIfWorksWithNullItem()
		{
			var node = new DefaultTreeNode<object>(CreateFakeFactory<object>(), null);
			Assert.IsNull(node.Item);
		}

		[Test]
		public void CheckConstructorIfItemIsTheSameObjectAsParameter()
		{
			var item = new object();
			var node = new DefaultTreeNode<object>(CreateFakeFactory<object>(), item);
			Assert.AreSame(item, node.Item);
		}

		[Test]
		public void CheckContructorIfWorksWithValueType()
		{
			var item = DateTime.Now;
			var node = new DefaultTreeNode<DateTime>(CreateFakeFactory<DateTime>(), item);
			Assert.AreEqual(item, node.Item);
		}

		[Test]
		public void CheckConstructorIfThrowsWhenFactoryIsNull()
		{
			Assert.Throws<ArgumentNullException>(() => new DefaultTreeNode<object>(null, new object()));
		}
	}
}
