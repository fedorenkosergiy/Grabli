namespace Grabli
{
	public class DefaultCounter : Counter
	{
		public virtual Huint Count {get; protected set;}

		public virtual bool Down()
		{
			if (Count > Huint.MinValue)
			{
				Count--;
				return true;
			}
			return false;
		}

		public virtual bool Up()
		{
			if (Count < Huint.MaxValue)
			{
				Count++;
				return true;
			}
			return false;
		}
	}
}
