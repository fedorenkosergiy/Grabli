using System;
using NUnit.Framework;

namespace Grabli.WrappedUnity.CodeGen
{
	public partial class DefaultInitializerTests
	{
		[Test]
		public void CheckIfInitDoesntThrow()
		{
			Assert.DoesNotThrow(() =>
			{
				using (new FileContext(CreateFakeIOFile()))
				using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
				{
					var initializer = new DefaultInitializer(CreateFakeFactory(), rootTypesFilePath, DefaultConfigsSetter);
					initializer.Init();
				}
			});
		}

		[Test]
		public void CheckIfInitThrowsTheSecontTime()
		{
			Assert.Catch<InvalidOperationException>(() =>
			{
				using (new FileContext(CreateFakeIOFile()))
				using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
				{
					var initializer = new DefaultInitializer(CreateFakeFactory(), rootTypesFilePath, DefaultConfigsSetter);
					initializer.Init();
				}
			});
		}
	}
}
