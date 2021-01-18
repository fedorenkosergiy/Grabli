﻿using System;

namespace Grabli.WrappedUnity.CodeGen
{
	public abstract class DummyTypeReader : TypeReader
	{
		public ReadonlyTypeConfig Read(string guid)
		{
			if (guid.IsNull())
			{
				throw new ArgumentNullException(nameof(guid));
			}

			if (guid.IsEmpty())
			{
				string argumentName = nameof(guid);
				throw new ArgumentException(argumentName, $"{argumentName} is empty");
			}

			return DoRead(guid);
		}

		protected abstract ReadonlyTypeConfig DoRead(string guid);
	}
}