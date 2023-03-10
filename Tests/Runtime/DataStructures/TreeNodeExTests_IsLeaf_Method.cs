using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Grabli.DataStructures
{
	public partial class TreeNodeExTests
	{
		[TestCase(0, true)]
		[TestCase(1, false)]
		[TestCase(2, false)]
		public void CheckIsLeafWhenThereAreSomeChildren(int childrenCound, bool expected)
		{
			Mock<TreeNode<int>> mock = new Mock<TreeNode<int>>();
			mock.Setup(node => node.Children).Returns(() =>
			{
				Mock<TreeNodeChildren<int>> childrenMock = new Mock<TreeNodeChildren<int>>();
				childrenMock.Setup(children => children.Nodes).Returns(() =>
				{
					var nodes = new List<TreeNode<int>>();
					for (int i = 0; i < childrenCound; nodes.Add(null), ++i)
                    {
                        
                    }

                    return nodes;
				});
				return childrenMock.Object;
			});
			bool actual = mock.Object.IsLeaf();
			Assert.AreEqual(expected, actual);
		}
	}
}
