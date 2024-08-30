using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_NetFamework
{
	public class myDemoClass
	{
		//Thuộc tính
		public int Id { get; set; } //private

		public string Name { get; set; }

		//constructor
		public myDemoClass()
		{

		}

		public myDemoClass(int id)
		{

		}


		//Phương thức
		public void Run()
		{
			Console.WriteLine("running" + Id);		}
	}
}
