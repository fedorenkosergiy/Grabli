using System;
using System.Collections;
using System.Text;
using Grabli.Pools;

namespace Grabli.WrappedUnity.CodeGen
{
	[Serializable]
	public struct RawTypeConfig
	{
		public string FullTypeName;
		public string Namespace;
		public string InterfaceName;
		public string ClassName;
		public bool UnityVersionSpecific;
		public string PackageId;
		public Approach Approach;
		public string[] Dependencies;

		public override bool Equals(object obj) => obj != null && Equals((RawTypeConfig) obj);

		public bool Equals(RawTypeConfig other)
		{
			if (Dependencies.Is() != other.Dependencies.Is())
			{
				return false;
			}
			if (Dependencies.Length != other.Dependencies.Length)
			{
				return false;
			}

			for (int i = 0; i < Dependencies.Length; ++i)
			{
				if (Dependencies[i] != other.Dependencies[i])
				{
					return false;
				}
			}

			return FullTypeName == other.FullTypeName &&
			       Namespace == other.Namespace &&
			       InterfaceName == other.InterfaceName &&
			       ClassName == other.ClassName &&
			       UnityVersionSpecific == other.UnityVersionSpecific &&
			       PackageId == other.PackageId &&
			       Approach == other.Approach;

		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (FullTypeName != null ? FullTypeName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Namespace != null ? Namespace.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (InterfaceName != null ? InterfaceName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (ClassName != null ? ClassName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ UnityVersionSpecific.GetHashCode();
				hashCode = (hashCode * 397) ^ (PackageId != null ? PackageId.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (int) Approach;
				hashCode = (hashCode * 397) ^ (Dependencies != null ? Dependencies.GetHashCode() : 0);
				return hashCode;
			}
		}

		public override string ToString()
		{
			StringBuilder builder = StringBuilderPool.Get();
			builder.Append('{');
			builder.Append('\n');
			AppendStringField(builder, nameof(FullTypeName), FullTypeName);
			AppendStringField(builder, nameof(Namespace), Namespace);
			AppendStringField(builder, nameof(InterfaceName), InterfaceName);
			AppendStringField(builder, nameof(ClassName), ClassName);
			AppendValueTypeField(builder, nameof(UnityVersionSpecific), UnityVersionSpecific);
			AppendStringField(builder, nameof(PackageId), PackageId);
			AppendValueTypeField(builder, nameof(Approach), Approach);
			AppendEnumerableField(builder, nameof(Dependencies), Dependencies);
			builder.Append('}');
			return StringBuilderPool.GetValueAndRelease(builder);
		}

		private void AppendStringField(StringBuilder builder, string name, string value)
		{
			AppendField(builder, name, value.IsNull() ? "NULL" : value);
		}

		private void AppendField(StringBuilder builder, string name, string value)
		{
			builder.Append(name);
			builder.Append(' ');
			builder.Append(':');
			builder.Append(' ');
			builder.Append(value);
			builder.Append('\n');
		}

		private void AppendValueTypeField(StringBuilder builder, string name, ValueType value)
		{
			AppendField(builder, name, value.ToString());
		}

		private void AppendEnumerableField(StringBuilder builder, string name, IEnumerable value)
		{
			StringBuilder arrayBuilder = StringBuilderPool.Get();
			arrayBuilder.Append('[');
			arrayBuilder.Append('\n');
			foreach (var item in value)
			{
				arrayBuilder.Append(item);
				arrayBuilder.Append('\n');
			}

			arrayBuilder.Append(']');
			string arrayValue = StringBuilderPool.GetValueAndRelease(arrayBuilder);
			AppendField(builder, name, arrayValue);
		}
	}
}