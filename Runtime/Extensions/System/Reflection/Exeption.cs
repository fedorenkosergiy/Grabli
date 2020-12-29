using System.Runtime.Serialization;

namespace System.Reflection
{
	[Serializable]
	internal class Exeption : Exception
	{
		public Exeption()
		{
		}

		public Exeption(string message) : base(message)
		{
		}

		public Exeption(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected Exeption(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}