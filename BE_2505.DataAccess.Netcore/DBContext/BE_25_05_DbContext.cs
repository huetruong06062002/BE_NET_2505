using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_2505.DataAccess.Netcore.DTO;
using Microsoft.EntityFrameworkCore;
namespace BE_2505.DataAccess.Netcore.DBContext
{
	public class BE_25_05_DbContext : DbContext
	{
		public BE_25_05_DbContext(DbContextOptions options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

		}
		public DbSet<Product>? product { get; set; }

		public DbSet<Account> account { get; set; }
	}
}