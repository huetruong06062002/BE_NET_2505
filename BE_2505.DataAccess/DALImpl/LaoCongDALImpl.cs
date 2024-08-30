using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_2505.DataAccess.DTO;

namespace BE_2505.DataAccess.DALImpl
{
	public class LaoCongDALImpl : Employeer
	{
		public override string working()
		{
			return "clean";
		}

		public string OtherWorking()
		{
			return "otherwork";
		}
	}
}
