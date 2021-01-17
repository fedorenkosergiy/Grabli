using System;
using NUnit.Framework;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
	public partial class RootTypesInitializerTests
	{
		[Test]
		public void CheckIfDeinitDoesntThrowAfterInitialized()
		{
			Assert.DoesNotThrow(() =>
			{
				using (new FileContext(CreateFakeIOFile()))
				using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
				{
					var initializer = new RootTypesInitializer(CreateFakeFactory(), RootTypesFilePath,DefaultConfigsSetter);
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
					var initializer = new RootTypesInitializer(CreateFakeFactory(), RootTypesFilePath, DefaultConfigsSetter);
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
					var initializer = new RootTypesInitializer(CreateFakeFactory(), RootTypesFilePath, DefaultConfigsSetter);
					initializer.Deinit();
				}
			});
		}
	}
}
