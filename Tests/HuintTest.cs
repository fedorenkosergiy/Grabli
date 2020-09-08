using NUnit.Framework;
using System;
using UnityEngine;

namespace Grabli
{
	public partial class HuintTest
	{
		[Test]
		public static void CastZeroIntToHuintAndBack()
		{
			int zeroBeforeCast = 0;
			Huint hZero = zeroBeforeCast;
			int zeroAfterCast = hZero;
			Assert.AreEqual(zeroBeforeCast, zeroAfterCast);
		}

		[Test]
		public static void CastNegativeIntToHuint()
		{
			int value = -1;
			Huint hValue;
			Assert.Catch<InvalidCastException>(() => hValue = value);
		}

		[Test]
		public static void CastOneMoreThanIntMaxToHuint()
		{
			uint value = int.MaxValue;
			value++;
			Huint hValue;
			Assert.Catch<InvalidCastException>(() => hValue = value);
		}

		[Test]
		public static void JsonSerialization()
		{
			Huint value = 12345;
			string actual = JsonUtility.ToJson(value);
			const string EXPECTED = "{\"_value\":12345}";
			Assert.AreEqual(EXPECTED, actual);
		}

		[Test]
		public static void JsonDeserialization()
		{
			const string VALUE = "{\"_value\":12345}";
			Huint actual = JsonUtility.FromJson<Huint>(VALUE);
			Huint expected = 12345;
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public static void JsonDeserializationWithInvalidData()
		{
			const string TEXT = "{\"_value\":-12345}";
			Huint hValue = JsonUtility.FromJson<Huint>(TEXT);
			int value;
			Assert.Catch<InvalidCastException>(() => value = hValue);
		}
	}
}
