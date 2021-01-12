using NUnit.Framework;

namespace Grabli.DataStructures
{
	public partial class PostOrderTraversalTests
	{
		[TestCase("5,2,1,4,3,0,8,6,9,10,7", "0,1,3,4,2,7,6,10,9,8,5")]
		public void CheckGetEumeratorIfNodesOrderOkInBinaryTree(string raw, string expected)
		{
			var rawNumbers = ParseNumbers(raw);
			var tree = CreateBinaryTree(rawNumbers);
			var expectedNumbers = ParseNumbers(expected);
			var traversal = new PostOrderTraversal<int>(tree);
			int i = 0;
			foreach(int item in traversal)
			{
				Assert.AreEqual(expectedNumbers[i++], item);
			}
		}
	}
}
