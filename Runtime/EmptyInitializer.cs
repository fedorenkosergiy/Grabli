using System;

namespace Grabli
{
	public abstract class EmptyInitializer : Initializer
	{
		public bool IsInitialized { get; protected set; }

		public void Init()
		{
			CheckIfCanInit();
			RunInitActions();
			IsInitialized = true;
		}

		private void CheckIfCanInit()
		{
			if (IsInitialized)
			{
				throw new InvalidOperationException("To call Init() object should be not initialized");
			}
		}

		protected abstract void RunInitActions();

		public void Deinit()
		{
			CheckIfCanDeinit();
			RunDeinitActions();
			IsInitialized = false;
		}

		private void CheckIfCanDeinit()
		{
			if (!IsInitialized)
			{
				throw new InvalidOperationException("To call Deinit() object should be initialized first");
			}
		}

		protected abstract void RunDeinitActions();
	}
}
