using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BE_2505.Common.Netcore
{
	public static class Validation
	{
		public static bool CheckInputData(string inputString)
		{
			if (string.IsNullOrEmpty(inputString))
			{
				return false;
			}

			return true;
		}

		public static bool CheckXSSInput(string input)
		{
			if (string.IsNullOrEmpty(input)) return false;

			if (string.IsNullOrWhiteSpace(input))
			{
				return false;
			}

			try
			{
				// Regular expression pattern to match dangerous HTML tags or attributes
				var dangerousPattern = new Regex(@"<\s*(applet|body|embed|frame|script|frameset|html|iframe|img|style|layer|link|ilayer|meta|object|h\d|input|a)\b|&lt;|&gt;", RegexOptions.IgnoreCase);

				// Check if the input matches the pattern
				if (dangerousPattern.IsMatch(input.Trim()))
				{
					return false;
				}

				return true;
			}
			catch (Exception ex)
			{
				// Log the exception if necessary
				Console.WriteLine(ex.Message);
				return false;
			}
		}
	}
}
