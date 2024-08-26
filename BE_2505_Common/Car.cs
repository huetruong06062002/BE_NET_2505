using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505_Common
{
	public class Car
	{
		public string brand { get; set; }
		public string model { get; set; }
		public int year { get; set; }


		public Car()
		{
		
		}
		public Car(string brand, string model, int year)
		{
			this.brand = brand;
			this.model = model;
			this.year = year;
		}

		public string display_info()
		{
			return brand + " " + model + " " + year;
		}


	}
}
