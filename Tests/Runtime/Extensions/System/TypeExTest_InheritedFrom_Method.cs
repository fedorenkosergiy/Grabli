using NUnit.Framework;
namespace System
{
	public partial class TypeExTest
	{
		[Test]
		public void StringInheritedFromObject()
		{
			Type stringType = typeof(string);
			Type objectType = typeof(object);
			Assert.IsTrue(stringType.InheritedFrom(objectType));
		}

		[Test]
		public void ObjectIsNotInheritedFromString()
		{
			Type stringType = typeof(string);
			Type objectType = typeof(object);
			Assert.IsFalse(objectType.InheritedFrom(stringType));
		}

		[Test]
		public void StringIsNotInheritedFromString()
		{
			Type stringType = typeof(string);
			Assert.IsFalse(stringType.InheritedFrom(stringType));
		}
	}
}