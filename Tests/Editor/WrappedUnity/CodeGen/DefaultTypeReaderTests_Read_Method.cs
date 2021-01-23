using System;
using System.IO;
using NUnit.Framework;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
	public partial class DefaultTypeReaderTests
	{
		[Test]
		public void CheckIfReadDoesntThrow()
		{
			Assert.DoesNotThrow(() =>
			{
				using (new FileContext(CreateFakeIOFile()))
				using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
				{
					var reader = new DefaultTypeReader(CreateFakeFactory());
					reader.Read(RootTypeGuidApplication);
				}
			});
		}

		

		[Test]
		public void CheckIfReadWorks()
		{
			using (new FileContext(CreateFakeIOFile()))
			using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
			{
				var reader = new DefaultTypeReader(CreateFakeFactory());
				var config = reader.Read(RootTypeGuidApplication);
				Assert.IsNotNull(config);
			}
		}

		[Test]
		public void CheckIfReadThrowsWhenGuidIsNull()
		{
			Assert.Throws<ArgumentNullException>(() =>
			{
				using (new FileContext(CreateFakeIOFile()))
				using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
				{
					var reader = new DefaultTypeReader(CreateFakeFactory());
					reader.Read(null);
				}
			});
		}

		[Test]
		public void CheckIfReadThrowsWhenGuidIsEmpty()
		{
			Assert.Throws<ArgumentException>(() =>
			{
				using (new FileContext(CreateFakeIOFile()))
				using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
				{
					var reader = new DefaultTypeReader(CreateFakeFactory());
					reader.Read(string.Empty);
				}
			});
		}
	}
}
