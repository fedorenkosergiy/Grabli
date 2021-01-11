using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Grabli.DataStructures
{
	public partial class DefaultTreeNodeTests
	{
		[Test]
		public void CheckIfAddChildReturnsNodeWithRightItem()
		{
			object item = new object();
			DefaultTreeNode<object> node = new DefaultTreeNode<object>();
			TreeNode<object> child = node.AddChild(item);
			Assert.AreEqual(item, child.Item);
		}

		[Test]
		public void CheckIfAddChildWorksWhenParameterIsDefaultClass()
		{
			DefaultTreeNode<object> node = new DefaultTreeNode<object>();
			TreeNode<object> child = node.AddChild(default);
			Assert.AreEqual(default, child.Item);
		}

		[Test]
		public void CheckIfAddChildWorksWhenParameterIsDefaultStruct()
		{
			DefaultTreeNode<DateTime> node = new DefaultTreeNode<DateTime>();
			TreeNode<DateTime> child = node.AddChild(default);
			Assert.AreEqual(default, child.Item);
		}
	}
}
