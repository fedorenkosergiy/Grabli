using System;
using System.Collections.Generic;

namespace Grabli.WrappedUnity
{
	public class Context<CType, T, I> : IDisposable where CType : Context<CType, T, I>, new() where T : I, new()
	{
		private I instance;
		private bool isDisposed;
		private static Stack<Context<CType, T, I>> contexts = new Stack<Context<CType, T, I>>();

		public static I Instance => contexts.Peek().instance;

		static Context()
		{
			CType basicItem = new CType();
			basicItem.instance = new T();
		}

		public Context(I instance):this()
		{
			this.instance = instance;
		}

		public Context()
		{
			isDisposed = false;
			contexts.Push(this);
		}

		public void Dispose()
		{
			if (isDisposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
			Context<CType, T, I> context = contexts.Pop();
			if (context != this)
			{
				throw new InvalidOperationException("Wrong context");
			}
			instance = default;
			isDisposed = true;
		}
	}
}
