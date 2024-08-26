using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505_Common
{
	public class ValidateData
	{
		public bool CheckInputData(string inputString)
		{
			if (string.IsNullOrEmpty(inputString))
			{
				return false;
			}
			return true;
		}
	}
}
