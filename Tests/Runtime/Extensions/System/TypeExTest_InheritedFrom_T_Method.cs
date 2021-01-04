using NUnit.Framework;
namespace System
{
	public partial class TypeExTest
	{
		[Test]
		public void StringInheritedFromObject_Generic()
		{
			Type stringType = typeof(string);
			Assert.IsTrue(stringType.InheritedFrom<object>());
		}

		[Test]
		public void ObjectIsNotInheritedFromString_Generic()
		{
			Type objectType = typeof(object);
			Assert.IsFalse(objectType.InheritedFrom<string>());
		}

		[Test]
		public void StringIsNotInheritedFromString_Generic()
		{
			Type stringType = typeof(string);
			Assert.IsFalse(stringType.InheritedFrom<string>());
		}
	}
}