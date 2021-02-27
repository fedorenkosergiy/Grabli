using System;

namespace UnityEngine
{
	internal abstract class AsyncOperationAwaiter<OperationType, Result> where OperationType : AsyncOperation
	{
		protected OperationType request;
		private Action callback;

		public AsyncOperationAwaiter(OperationType request)
		{
			this.request = request;
			request.completed += OnRequestCompleted;
		}

		public bool IsCompleted => request.isDone;

		public abstract Result GetResult();

		public void OnCompleted(Action continuation) => callback = continuation;

		private void OnRequestCompleted(AsyncOperation operation) => callback?.Invoke();

    }

    internal class AsyncOperationAwaiter : VoidAwaiter
	{
		protected AsyncOperation operation;
		private Action callback;

		public AsyncOperationAwaiter(AsyncOperation operation)
		{
			this.operation = operation;
			operation.completed += OnRequestCompleted;
		}

		public bool IsCompleted => operation.isDone;

		public void GetResult() { }

		public void OnCompleted(Action continuation) => callback = continuation;

		private void OnRequestCompleted(AsyncOperation operation) => callback?.Invoke();
	}
}
