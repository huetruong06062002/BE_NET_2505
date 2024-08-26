using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505_Common
{
	public static class StaticClass
	{
		//Tat ca cac ham va thuoc tinh ben trong class static phai la static
		public static int Id { get; set; }
		
		public static string TestStatic()
		{
			return "123";
		}
	}
}
