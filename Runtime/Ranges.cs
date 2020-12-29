using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Grabli.Source
{
	public class Ranges
	{
		public int[] generateRange(int min, int max, int step)
		{
			int count = (max - min) / step;
			int[] result = new int[count];
			for (int value = min, i = 0; value < max; value += step, i++)
			{
				result[i] = value;
			}
			return result;
		}
	}
}
