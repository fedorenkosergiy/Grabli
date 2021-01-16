using System;

namespace Grabli
{
	public class EmptyInitializer : Initializer
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

		protected virtual void RunInitActions()
		{

		}

		public void Deinit()
		{
			CheckIfCanDeinit();
			RunDeinitActions();
			IsInitialized = false;
		}

		private void CheckIfCanDeinit()
		{

		}

		protected virtual void RunDeinitActions()
		{
			if (!IsInitialized)
			{
				throw new InvalidOperationException("To call Deinit() object should be initialized first");
			}
		}
	}
}
