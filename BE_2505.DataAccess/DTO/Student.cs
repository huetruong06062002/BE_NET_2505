using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.DTO
{
	public class Student
	{
		public Guid Id { get; set; }
		public string Name { get; set; }

		public DateTime DateOfBirth { get; set; }

		private int GPA { get; set; } = 4;
		private string FullName { get; set; }

		public void setFullName(string _fullName)
		{
			FullName = _fullName;
		}

		public string GetFullName()
		{
			return FullName;
		}
	}
}
