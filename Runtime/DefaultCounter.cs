namespace Grabli
{
	public class DefaultCounter : Counter
	{
		public virtual int Count {get; protected set;}

		public virtual bool Down()
		{
			if (Count > 0)
			{
				Count--;
				return true;
			}
			return false;
		}

		public virtual bool Up()
		{
			if (Count < int.MaxValue)
			{
				Count++;
				return true;
			}
			return false;
		}
	}
}
