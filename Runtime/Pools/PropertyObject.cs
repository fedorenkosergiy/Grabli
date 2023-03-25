namespace Grabli.Pools
{
	internal abstract class PropertyObject : Property
	{
		protected object Owner { get; private set; }

		public bool ResetOwner(object owner)
		{
			if (owner != Owner)
			{
				return false;
			}
			Owner = default;
			OnResetOwner();
			return true;
		}

		protected abstract void OnResetOwner();

		public bool SetOwner(object owner)
		{
			if (Owner != null)
			{
				return false;
			}
			Owner = owner;
			OnSetOwner();
			return true;
		}

		protected abstract void OnSetOwner();
	}
}
