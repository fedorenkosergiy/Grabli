using NUnit.Framework;
using UnityEngine;
namespace System
{
	public partial class TypeExTest
	{
		[Test]
		public void IsUnityComponentCheckMonoBehaviour()
		{
			Assert.IsTrue(typeof(MonoBehaviour).IsUnityComponent());
		}

		[Test]
		public void IsUnityComponentCheckComponent()
		{
			Assert.IsTrue(typeof(Component).IsUnityComponent());
		}

		[Test]
		public void IsUnityComponentCheckTransform()
		{
			Assert.IsTrue(typeof(Transform).IsUnityComponent());
		}

		[Test]
		public void IsUnityComponentCheckGameObject()
		{
			Assert.IsFalse(typeof(GameObject).IsUnityComponent());
		}

		[Test]
		public void IsUnityComponentCheckTextAsset()
		{
			Assert.IsFalse(typeof(TextAsset).IsUnityComponent());
		}

		[Test]
		public void IsUnityComponentCheckSystemObject()
		{
			Assert.IsFalse(typeof(object).IsUnityComponent());
		}

		[Test]
		public void IsUnityComponentCheckFloat()
		{
			Assert.IsFalse(typeof(float).IsUnityComponent());
		}

		[Test]
		public void IsUnityComponentCheckIDisposable()
		{
			Assert.IsFalse(typeof(IDisposable).IsUnityComponent());
		}

		[Test]
		public void IsUnityComponentCheckTypeCode()
		{			
			Assert.IsFalse(typeof(TypeCode).IsUnityComponent());
		}

		[Test]
		public void IsUnityComponentCheckAction()
		{
			Assert.IsFalse(typeof(Action).IsUnityComponent());
		}
	}
}