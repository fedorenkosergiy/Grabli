using System;
using System.Globalization;
using UnityEngine;

namespace Grabli
{
	[Serializable]
	public struct Huint : IComparable, IComparable<Huint>, IConvertible, IEquatable<Huint>, IFormattable
	{
		private static readonly string _typeName = nameof(Huint);
		public static readonly Huint MinValue = uint.MinValue;
		public static readonly Huint MaxValue = int.MaxValue;

		[SerializeField]
		private int _value;

		public static implicit operator uint(Huint value)
		{
			CheckInternalDataBeforeCast(value);
			return (uint)value._value;
		}

		private static void CheckInternalDataBeforeCast(Huint value)
		{
			if (value._value < uint.MinValue)
			{
				throw CreateWrongInternalDataException(value);
			}
		}

		private static Exception CreateWrongInternalDataException(Huint value)
		{
			const string messageFormat = "Internal value={0} is less than UInt32.MinValue";
			return new InvalidCastException(string.Format(messageFormat, value));
		}

		public static implicit operator int(Huint value)
		{
			CheckInternalDataBeforeCast(value);
			return value._value;
		}

		public static implicit operator Huint(int value)
		{
			if (value < uint.MinValue)
			{
				const string messageFormat = "{0} is less than {1}.{2}";
				throw new InvalidCastException(string.Format(messageFormat, value, _typeName, nameof(MinValue)));
			}
			return new Huint { _value = value };
		}

		public static implicit operator Huint(uint value)
		{
			if (value > int.MaxValue)
			{
				const string messageFormat = "{0} is more than {1}.{2}";
				throw new InvalidCastException(string.Format(messageFormat, value, _typeName, nameof(MaxValue)));
			}
			return new Huint { _value = (int)value };
		}

		public static implicit operator float(Huint value)
		{
			return (int)value;
		}

		public override string ToString()
		{
			return _value.ToString();
		}

		public override int GetHashCode()
		{
			return _value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			Huint value = (Huint)obj;
			return _value.Equals(value._value);
		}

		public int CompareTo(object obj)
		{
			Huint other = (Huint)obj;
			return CompareTo(other);
		}

		public int CompareTo(Huint other)
		{
			return _value.CompareTo(other._value);
		}

		TypeCode IConvertible.GetTypeCode()
		{
			return TypeCode.UInt32;
		}

		bool IConvertible.ToBoolean(IFormatProvider provider)
		{
			return ((IConvertible)_value).ToBoolean(provider);
		}

		byte IConvertible.ToByte(IFormatProvider provider)
		{
			return ((IConvertible)_value).ToByte(provider);
		}

		char IConvertible.ToChar(IFormatProvider provider)
		{
			return ((IConvertible)_value).ToChar(provider);
		}

		DateTime IConvertible.ToDateTime(IFormatProvider provider)
		{
			return ((IConvertible)_value).ToDateTime(provider);
		}

		decimal IConvertible.ToDecimal(IFormatProvider provider)
		{
			return ((IConvertible)_value).ToDecimal(provider);
		}

		double IConvertible.ToDouble(IFormatProvider provider)
		{
			return ((IConvertible)_value).ToDouble(provider);
		}

		short IConvertible.ToInt16(IFormatProvider provider)
		{
			return ((IConvertible)_value).ToInt16(provider);
		}

		int IConvertible.ToInt32(IFormatProvider provider)
		{
			return ((IConvertible)_value).ToInt32(provider);
		}

		long IConvertible.ToInt64(IFormatProvider provider)
		{
			return ((IConvertible)_value).ToInt64(provider);
		}

		sbyte IConvertible.ToSByte(IFormatProvider provider)
		{
			return ((IConvertible)_value).ToSByte(provider);
		}

		float IConvertible.ToSingle(IFormatProvider provider)
		{
			return ((IConvertible)_value).ToSingle(provider);
		}

		string IConvertible.ToString(IFormatProvider provider)
		{
			return _value.ToString(provider);
		}

		object IConvertible.ToType(Type conversionType, IFormatProvider provider)
		{
			return ((IConvertible)_value).ToType(conversionType, provider);
		}

		ushort IConvertible.ToUInt16(IFormatProvider provider)
		{
			return ((IConvertible)_value).ToUInt16(provider);
		}

		uint IConvertible.ToUInt32(IFormatProvider provider)
		{
			return ((IConvertible)_value).ToUInt32(provider);
		}

		ulong IConvertible.ToUInt64(IFormatProvider provider)
		{
			return ((IConvertible)_value).ToUInt64(provider);
		}

		public bool Equals(Huint other)
		{
			return _value.Equals(other._value);
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			return _value.ToString(format, formatProvider);
		}

		public static Huint Parse(string s, IFormatProvider provider)
		{
			return int.Parse(s, provider);
		}

		public static Huint Parse(string s, NumberStyles style, IFormatProvider provider)
		{
			return int.Parse(s, style, provider);
		}

		public static Huint Parse(string s, NumberStyles style)
		{
			return int.Parse(s, style);
		}

		public static Huint Parse(string s)
		{
			return int.Parse(s);
		}

		public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out Huint result)
		{
			bool value = int.TryParse(s, style, provider, out int tempResult);
			result = tempResult;
			return value;
		}

		public static bool TryParse(string s, out Huint result)
		{
			bool value = int.TryParse(s, out int tempResult);
			result = tempResult;
			return value;
		}
	}
}
