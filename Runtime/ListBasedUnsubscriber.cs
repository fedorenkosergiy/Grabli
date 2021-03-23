using System;
using System.Collections.Generic;

namespace save
{
	public class ListBasedUnsubscriber<T> : IDisposable
	{
		private IList<IObserver<T>> observers;
		private IObserver<T> observer;

		public ListBasedUnsubscriber(IList<IObserver<T>> observers, IObserver<T> observer)
		{
			this.observers = observers;
			this.observer = observer;
		}

		public void Dispose()
		{
			if (observer != null && observers.Contains(observer))
				observers.Remove(observer);
		}
	}
}
