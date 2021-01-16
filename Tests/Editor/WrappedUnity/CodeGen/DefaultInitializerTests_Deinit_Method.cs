using System;
using NUnit.Framework;

namespace Grabli.WrappedUnity.CodeGen
{
	public partial class DefaultInitializerTests
	{
		[Test]
		public void CheckIfDeinitDoesntThrowAfterInitialized()
		{
			Assert.DoesNotThrow(() =>
			{
				using (new FileContext(CreateFakeIOFile()))
				using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
				{
					var initializer = new DefaultInitializer(CreateFakeFactory(), rootTypesFilePath,DefaultConfigsSetter);
					initializer.Init();
					initializer.Deinit();
				}
			});
		}

		[Test]
		public void CheckIfDeinitThrowsTheSecondTime()
		{
			Assert.Catch<InvalidOperationException>(() =>
			{
				using (new FileContext(CreateFakeIOFile()))
				using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
				{
					var initializer = new DefaultInitializer(CreateFakeFactory(), rootTypesFilePath, DefaultConfigsSetter);
					initializer.Init();
					initializer.Deinit();
					initializer.Deinit();
				}
			});
		}

		[Test]
		public void CheckIfDeinitThrowsIfNotInitialized()
		{
			Assert.Catch<InvalidOperationException>(() =>
			{
				using (new FileContext(CreateFakeIOFile()))
				using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
				{
					var initializer = new DefaultInitializer(CreateFakeFactory(), rootTypesFilePath, DefaultConfigsSetter);
					initializer.Deinit();
				}
			});
		}
	}
}
