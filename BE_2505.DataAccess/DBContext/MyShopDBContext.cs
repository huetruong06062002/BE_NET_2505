using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_2505.DataAccess.DTO;


namespace BE_2505.DataAccess.DBContext
{
	public class MyShopDBContext : DbContext
	{
		public MyShopDBContext() : base("name=MyConnectionString")
		{

		}


		public DbSet<Student> student { get; set; }



	}
}
