using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace Grabli.DataStructures
{
	public partial class TreeNodeChildrenExTests
	{
		[TestCase(1,1, false)]
		[TestCase(1,2, true)]
		public void CheckTryAddUnique(int first, int second, bool expected)
		{
			List<int> added = new List<int>();
			Mock<TreeNodeChildren<int>> mock = new Mock<TreeNodeChildren<int>>();
			mock.Setup(children => children.Nodes).Returns(new List<TreeNode<int>>() {});
			mock.Setup(children => children.Add(It.IsAny<int>())).Callback<int>(added.Add);
			mock.Setup(children => children.Contains(It.IsAny<int>())).Returns<int>(added.Contains);
			mock.Object.TryAddUnique(first);
			bool actual = mock.Object.TryAddUnique(second);
			Assert.AreEqual(expected, actual);
		}
	}
}
