using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505_Common
{

	
	public abstract class Animal
	{
		//Ko dùng abstract hoạc virtual thì ko đc override
		public string Name { get; set; }
		

		//Hàm này k đc ghi đè, đc hiểu riêng của 1 mình hàm này
		public string Eat13()
		{
			return "";
		}

		//abstract phải ghi đè
		public abstract string Eat();

		public abstract string Sound();

		//virtual có thể ghi đè hoặc không ghi đè
		public virtual string Sound2()
		{
			return "123";
		}
		
	}
}
