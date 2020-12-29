using System;

namespace UnityEngine
{
	internal abstract class CustomYieldInstructionAwaiter<InstructionType> : VoidAwaiter where InstructionType : CustomYieldInstruction
	{
		protected InstructionType instruction;
		private Action callback;
		private bool used;

		public CustomYieldInstructionAwaiter(InstructionType instruction)
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
			$"keep = {instruction.keepWaiting}".Log();
			if (instruction.keepWaiting)
			{
				return false;
			}
			used = true;
			$"callback".Log();
			callback();
			return true;
		}

		public void GetResult() {
			"result".Log();
		}

		public void OnCompleted(Action continuation) => callback = continuation;
	}
}
