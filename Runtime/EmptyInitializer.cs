using System;

namespace Grabli
{
	public abstract class EmptyInitializer : Initializer
	{
		public bool IsInitialized { get; protected set; }

		public void Init()
		{
			ThrowIfCantInit();
			RunInitActions();
			IsInitialized = true;
		}

		private void ThrowIfCantInit()
		{
			if (IsInitialized)
			{
				throw new InvalidOperationException("To call Init() object should be not initialized");
			}
		}

		protected abstract void RunInitActions();

		public void Deinit()
		{
			ThrowIfCantDeinit();
			RunDeinitActions();
			IsInitialized = false;
		}

		private void ThrowIfCantDeinit()
		{
			if (!IsInitialized)
			{
				throw new InvalidOperationException("To call Deinit() object should be initialized first");
			}
		}

		protected abstract void RunDeinitActions();
	}
}
