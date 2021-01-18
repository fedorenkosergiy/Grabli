using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Grabli.DataStructures
{
	public partial class TreeNodeExTests
	{
		[TestCase(1, 0, 2)]
		[TestCase(1, 5, 7)]
		[TestCase(2, 2, 7)]
		public void CheckCountWhenThereAreSomeChildren(int childrenOnZeroLevel, int childrenOnFirstLevel, int expected)
		{
			Mock<TreeNode<int>> mock = new Mock<TreeNode<int>>();
			mock.Setup(node => node.Children).Returns(() =>
			{
				Mock<TreeNodeChildren<int>> childrenMock = new Mock<TreeNodeChildren<int>>();
				childrenMock.Setup(children => children.Nodes).Returns(() =>
				{
					var nodes = new List<TreeNode<int>>();
					for (int i = 0; i < childrenOnZeroLevel; ++i)
					{
						Mock<TreeNode<int>> firtLevelNodeMock = new Mock<TreeNode<int>>();
						firtLevelNodeMock.Setup(node1 => node1.Children).Returns(() =>
						{
							Mock<TreeNodeChildren<int>> childrenMock1 = new Mock<TreeNodeChildren<int>>();
							childrenMock1.Setup(children1 => children1.Nodes).Returns(() =>
							{
								var nodes1 = new List<TreeNode<int>>();
								for (int j = 0; j < childrenOnFirstLevel; ++j)
								{
									Mock<TreeNode<int>> secondLevelNodeMock = new Mock<TreeNode<int>>();
									secondLevelNodeMock.Setup(node1 => node1.Children)
										.Returns(() =>
										{
											Mock<TreeNodeChildren<int>> childrenMock2 =
												new Mock<TreeNodeChildren<int>>();
											childrenMock2.Setup(children2 => children2.Nodes)
												.Returns(new List<TreeNode<int>>());
											return childrenMock2.Object;
										});
									nodes1.Add(secondLevelNodeMock.Object);
								}

								return nodes1;
							});
							return childrenMock1.Object;
						});
						nodes.Add(firtLevelNodeMock.Object);
					}

					return nodes;
				});
				return childrenMock.Object;
			});
			var actual = mock.Object.Count();
			Assert.AreEqual(expected, actual);
		}
	}
}
