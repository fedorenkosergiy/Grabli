using System;

namespace UnityEngine
{
	internal class PingAwaiter : BoolAwaiter
	{
		private Ping ping;
		private Action callback;
		private bool used;

		public bool IsCompleted => TryCallCallback();

		public PingAwaiter(Ping ping)
		{
			this.ping = ping;
		}

		private bool TryCallCallback()
		{
			"try".Log();
			if (used)
			{
				return false;
			}
			if (ping.isDone)
			{
				used = true;
				callback();
			}
			return false;
		}

		public bool GetResult() => ping.time >= 0;
		public void OnCompleted(Action continuation) => callback = continuation;
	}
}
