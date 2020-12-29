using System;
using System.Collections.Generic;

namespace Grabli.WrappedUnity
{
	public class TimeContext : IDisposable
	{
		private Time time;
		private bool isDisposed;
		private static Stack<TimeContext> contexts = new Stack<TimeContext>();

		public static Time Time => contexts.Peek().time;

		static TimeContext()
		{
			new TimeContext(new DefaultTime());
		}

		public TimeContext(Time time)
		{
			this.time = time;
			isDisposed = false;
			contexts.Push(this);
		}

		public void Dispose()
		{
			if (isDisposed)
			{
				throw new ObjectDisposedException(nameof(TimeContext));
			}
			TimeContext context = contexts.Pop();
			if (context != this)
			{
				throw new InvalidOperationException("Wrong context");
			}
			isDisposed = true;
		}
	}
}
