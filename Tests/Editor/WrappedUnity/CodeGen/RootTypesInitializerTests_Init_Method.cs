using System;
using NUnit.Framework;

namespace Grabli.WrappedUnity.CodeGen
{
	public partial class RootTypesInitializerTests
	{
		[Test]
		public void CheckIfInitDoesntThrow()
		{
			Assert.DoesNotThrow(() =>
			{
				using (new FileContext(CreateFakeIOFile()))
				using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
				{
					var initializer = new RootTypesInitializer(CreateFakeFactory(), rootTypesFilePath, DefaultConfigsSetter);
					initializer.Init();
				}
			});
		}

		[Test]
		public void CheckIfInitThrowsTheSecondTime()
		{
			Assert.Catch<InvalidOperationException>(() =>
			{
				using (new FileContext(CreateFakeIOFile()))
				using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
				{
					var initializer = new RootTypesInitializer(CreateFakeFactory(), rootTypesFilePath, DefaultConfigsSetter);
					initializer.Init();
					initializer.Init();
				}
			});
		}
	}
}
