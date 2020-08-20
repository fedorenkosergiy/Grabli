using System;

namespace UnityEngine
{
	internal abstract class YieldInstructionAwaiter<InstructionType> : VoidAwaiter where InstructionType : YieldInstruction
	{
		protected InstructionType instruction;
		private Action callback;
		private bool used;

		public YieldInstructionAwaiter(InstructionType instruction)
		{
			this.instruction = instruction;
		}

		public bool IsCompleted => TryCallCallback();

		private bool TryCallCallback()
		{
			if (used)
			{
				return false;
			}
			if (CheckIfCompleted())
			{
				used = true;
				callback();
			}
			return true;
		}

		protected abstract bool CheckIfCompleted();

		public void GetResult() { }

		public void OnCompleted(Action continuation) => callback = continuation;
	}
}